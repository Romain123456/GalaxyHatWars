using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araignee_Ep1 : Ennemis
{
    #region Variables
    public Transform toileAraignee;

    #region Marche
    public float stopDistanceMarche;
    #endregion

    #region Attente
    public float speedRotatingWait;
    #endregion

    #region Poursuite
    public float speedRotatingPoursuite;
    #endregion

    #region CracheToile
    private float countCracheToile;
    public float freqCracheToile;
    public GameObject toileMunitionPrefab;
    public int nbToileMunition;
    public Transform tirPosition;
    private List<GameObject> toileMunitionList;
    private bool isTir;
    #endregion

    #region Animations
    [HideInInspector] public int hashAttack;
    #endregion

    #endregion





    #region Methodes
    // Start is called before the first frame update
    void Start()
    {
        #region Initialisations
        Initialisation("AraigneeBlend");
        EnnemiInitialisation();
        AraigneeInitialisation();
        InitialisationPooling();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = monAnimator.GetCurrentAnimatorStateInfo(0);
        if(phaseIA == "Marche")
        {
            if (ennemiNavMesh.velocity.magnitude == 0 && Vector3.Magnitude(ennemiNavMesh.destination-monTransform.position) <= stopDistanceMarche)
            {
                StartCoroutine(AraigneePositionWait());
                phaseIA = "Attente";
            }
        } else if(phaseIA == "Attente")
        {
            EnnemiVision();
        } else if(phaseIA == "Poursuite")
        {
            AraigneePoursuite();
            if(ennemiNavMesh.velocity.magnitude == 0 && Vector3.Magnitude(ennemiNavMesh.destination - monTransform.position) <= stopDistPoursuite)
            {
                phaseIA = "CracheToile";
                StartCoroutine(AraigneeCracheToileStart());
            }
        } else if(phaseIA == "CracheToile")
        {
            AraigneeCracheToile();
        } else if(phaseIA == "Mort")
        {
            EnnemiMort();
        }

        if (isDead && phaseIA != "Mort")
        {
            phaseIA = "Mort";
        }
    }


    #region Initialisation
    public void AraigneeInitialisation()
    {
        AraigneeMarche();
        hashAttack = Animator.StringToHash("Base Layer.Araignee_Attack");
    }

    public void InitialisationPooling()
    {
        toileMunitionList = new List<GameObject>();
        for(int ii = 0; ii < nbToileMunition; ii++)
        {
            GameObject objBullet = (GameObject)Instantiate(toileMunitionPrefab, tirPosition);
            objBullet.GetComponent<MunitionEnnemi>().monParent = tirPosition;
            objBullet.SetActive(false);
            toileMunitionList.Add(objBullet);
        }
    }
    
    #endregion


    #region Marche
    public void AraigneeMarche()
    {
        ennemiNavMesh.destination = toileAraignee.position;
        phaseIA = "Marche";
        monAnimator.SetBool("isWalking", true);
        ennemiNavMesh.stoppingDistance = stopDistanceMarche;
        ennemiNavMesh.speed = speedMvt;
        ennemiNavMesh.angularSpeed = speedRot;
    }
    #endregion

    #region Attente
    public IEnumerator AraigneePositionWait()
    {
        float rotY = monTransform.rotation.eulerAngles.y;
        float rotY0 = rotY;
        while(rotY > rotY0 - 180)
        {
            rotY -= speedRotatingWait;
            monTransform.rotation = Quaternion.Euler(monTransform.rotation.eulerAngles.x, rotY, monTransform.rotation.eulerAngles.z);
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
            if(phaseIA =="Poursuite" || phaseIA == "CracheToile")
            {
                break;
            }
        }
        if (phaseIA != "Poursuite" && phaseIA != "CracheToile")
        {
            monAnimator.SetBool("isWalking", false);
        }
    }
    #endregion


    #region Poursuite
    public void AraigneePoursuite()
    {
        ennemiNavMesh.destination = drBobGO.transform.position;
        EnnemiRotateToTarget(speedRotatingPoursuite);
        if (Vector3.Magnitude(ennemiNavMesh.destination - monTransform.position) > distRetourMarche)
        {
            AraigneeMarche();
        }
    }
    #endregion

    #region Crache Toile
    public IEnumerator AraigneeCracheToileStart()
    {
        monAnimator.SetBool("isWalking", false);
        yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        monAnimator.SetBool("isAttack", true);
    }

    public void AraigneeCracheToile()
    {

        if (stateInfo.fullPathHash == hashAttack) {
            if (stateInfo.normalizedTime - (int)stateInfo.normalizedTime > 0.7f)
            {
                monAnimator.SetBool("isAttack", false);
            }
            if(stateInfo.normalizedTime - (int)stateInfo.normalizedTime > 0.8f && !isTir)
            {
                isTir = true;
                AraigneeTir();
            }
        }

        if (stateInfo.fullPathHash != hashAttack)
        {
            EnnemiRotateToTarget(speedRotatingPoursuite);
            countCracheToile += FonctionsVariablesGenerales.deltaTime;
            if (countCracheToile >= freqCracheToile)
            {
                countCracheToile = 0;
                monAnimator.SetBool("isAttack", true);
                isTir = false;
            }

            if (Vector3.Magnitude(drBobGO.transform.position - monTransform.position) > stopDistPoursuite)
            {
                countCracheToile = 0;
                isTir = false;
                monAnimator.SetBool("isAttack", false);
                phaseIA = "Poursuite";
                monAnimator.SetBool("isWalking", true);
            }
        }
    }

    public void AraigneeTir()
    {
        for(int ii = 0; ii < toileMunitionList.Count; ii++)
        {
            if (!toileMunitionList[ii].activeInHierarchy)
            {
                toileMunitionList[ii].transform.position = tirPosition.position;
                toileMunitionList[ii].transform.rotation = tirPosition.rotation;
                toileMunitionList[ii].transform.parent = null;
                toileMunitionList[ii].SetActive(true);
                break;
            }
        }
    }
    #endregion


    #region Collision ArmeDrBob
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("PlayerArme"))
        {
            CollisionArmeDrBob(other.gameObject, other.GetComponent<ColliderAttaque>().mainParent.GetComponent<DrBob_Ep1>()._currentAttackBaton);
        }
    }
    #endregion


    #endregion
}
