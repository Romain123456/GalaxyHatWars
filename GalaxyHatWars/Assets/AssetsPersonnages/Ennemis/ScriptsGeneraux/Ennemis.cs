using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemis : Personnage
{
    #region Variables

    #region DrBob/Elements extérieurs
    [HideInInspector] public GameObject drBobGO;
    public LayerMask drBob_LayerMask;
    
    #endregion


    #region Intelligence Artificielle
    [HideInInspector] public string phaseIA;
    public Transform destinationEnnemi;
    [HideInInspector] public Vector3 destinationPosition;
    [HideInInspector] public NavMeshAgent ennemiNavMesh;
    #endregion

    #region Statistiques
    public float speedPoursuite;
    public float speedRotPoursuite;
    public float stopDistPoursuite;
    #endregion

    #region Autres Composants
    public Collider ennemiCollider;
    #endregion

    #region Hit Particules
    public Transform hitParticulesParent;
    [HideInInspector] public GameObject[] hitParticules;
    #endregion

    #region Bonus
    public GameObject heartBonusPrefab;
    #endregion

    #region Marche
    [HideInInspector] public bool isWaiting;
    public float rayonVision;
    public float angleVueEnnemi;
    #endregion


    #region Poursuite
    public float distRetourMarche;
    public float distAttaque;
    #endregion


    #region Attaque
    [HideInInspector] public bool isAttaque;
    #endregion

    #endregion



    #region Méthodes

    public void EnnemiInitialisation()
    {
        ennemiNavMesh = this.GetComponent<NavMeshAgent>();
        ennemiNavMesh.speed = speedMvt;
        ennemiNavMesh.angularSpeed = speedRot;
        drBobGO = GameObject.FindGameObjectWithTag("Player");
        hitParticules = new GameObject[hitParticulesParent.childCount];
        for(int ii = 0; ii < hitParticules.Length; ii++)
        {
            hitParticules[ii] = hitParticulesParent.GetChild(ii).gameObject;
            hitParticules[ii].SetActive(false);
        }
    }


    public void EnnemiChangeStatistiques (float _SpeedMvt,float _SpeedRot,float _DistStop)
    {
        ennemiNavMesh.speed = _SpeedMvt;
        ennemiNavMesh.angularSpeed = _SpeedRot;
        ennemiNavMesh.stoppingDistance = _DistStop;
    }


    public void EnnemiRotateToTarget(float _SpeedRotation)
    {
        Vector3 directionToLook = drBobGO.transform.position - monTransform.position;
        monTransform.rotation = Quaternion.Slerp(monTransform.rotation, Quaternion.LookRotation(directionToLook), FonctionsVariablesGenerales.deltaTime * _SpeedRotation);
    }

    #region Marche
    public void KeepDestination()
    {
        destinationEnnemi.position = destinationPosition;
    }


    public void EnnemiVision()
    {
        Collider[] hitColliders;
        hitColliders = Physics.OverlapSphere(eyes.transform.position, rayonVision, drBob_LayerMask);

        if (hitColliders.Length > 0)
        {
            Vector2 posEyesV2 = new Vector2(eyes.transform.position.x, eyes.transform.position.z);
            Vector3 posDrBobV3 = new Vector3(hitColliders[0].transform.position.x, eyes.transform.position.y, hitColliders[0].transform.position.z);
            float angle = Vector3.Angle(eyes.transform.forward, posDrBobV3 - eyes.transform.position);
            Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 3);
            Debug.DrawLine(eyes.transform.position, posDrBobV3);
            if (angle < angleVueEnnemi)
            {
                phaseIA = "Poursuite";
                monAnimator.SetBool("isWalking", true);
                EnnemiChangeStatistiques(speedPoursuite, speedRotPoursuite,stopDistPoursuite);
            }
        }

    }
    #endregion


    #region Poursuite
    public void EnnemiPoursuite()
    {
        ennemiNavMesh.destination = drBobGO.transform.position;
    }


    public void EnnemiChangePoursuiteIA()
    {
        if (ennemiNavMesh.remainingDistance > distRetourMarche)
        {
            phaseIA = "Marche";
            monAnimator.SetBool("isWalking", true);
            EnnemiChangeStatistiques(speedMvt, speedRot,0);
        }
        else if (ennemiNavMesh.remainingDistance < distAttaque)
        {
            phaseIA = "Attaque";
            monAnimator.SetBool("isWalking", false);
        }
    }

    #endregion


    #region Collision Arme DrBob
    public void CollisionArmeDrBob(GameObject _monCollider, float _attaque)
    {
        //pv = PrendreCoup(_attaque);
        if (!isHurt)
        {
            StartCoroutine(scriptGeneralites.ShakeCamera(0.3f, 1f, 0.5f));
            StartCoroutine(PrendreCoupClignotte(_monCollider, _attaque,4));
            StartCoroutine(ParticulesHitCoups());
            _monCollider.GetComponent<AudioSource>().PlayOneShot(_monCollider.GetComponent<ColliderAttaque>().sonCollision);
            if(phaseIA != "Poursuite" || phaseIA != "Attaque")
            {
                phaseIA = "Poursuite";
            }
            isHurt = true;
        }
    }

    public IEnumerator ParticulesHitCoups()
    {
        int indParticule = 0;
        if(pv == 0)
        {
            indParticule = 1;
        }
        hitParticules[indParticule].SetActive(true);
        yield return new WaitForSeconds(1);
        hitParticules[indParticule].SetActive(false);
    }
    #endregion


    #region Mort
    public void EnnemiMort()
    {
        Mort();
        if (ennemiCollider.enabled)
        {
            ennemiCollider.enabled = false;
            EnnemiDonBonus();
            StartCoroutine(WaitMortAnim());
        }
    }

    public IEnumerator WaitMortAnim()
    {
        while (stateInfo.normalizedTime < 1)
        {
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        ennemiNavMesh.destination = this.transform.position;
        ennemiNavMesh.enabled = false;
        yield return new WaitForSeconds(1);
        this.enabled = false;
    }

    public void EnnemiDonBonus()
    {
        bool isDonBonus = false;
        int chanceDonBonus = 0;
        
        float pvDrBobRelatif = drBobGO.GetComponent<DrBob>().pv / drBobGO.GetComponent<DrBob>().pvMax;
        if (pvDrBobRelatif < 1 && pvDrBobRelatif < 0.75f)
        {
            chanceDonBonus = 1;
        } else if (pvDrBobRelatif <= 0.75f && pvDrBobRelatif > 0.5f)
        {
            chanceDonBonus = 2;
        } else if(pvDrBobRelatif <= 0.5f && pvDrBobRelatif > 0.25f)
        {
            chanceDonBonus = 3;
        } else if(pvDrBobRelatif <= 0.25f)
        {
            chanceDonBonus = 4;
        }

        int hasardBonus = Random.Range(0, 6);
        //if(hasardBonus <= chanceDonBonus)
        //{
            GameObject heartBonus = Instantiate(heartBonusPrefab);
            heartBonus.transform.localScale = Vector3.one * 40;
            heartBonus.transform.position = new Vector3(monTransform.position.x, monTransform.position.y+3, monTransform.position.z);
        //}
    }

    #endregion

    #endregion

}
