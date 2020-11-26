using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rat_Ep1 : Ennemis
{
    #region Variables

    #region Initialisation
    [HideInInspector] public Transform[] coinsSalle;
    [HideInInspector] public float[] sizesSalle;
    public LayerMask initMask;
    #endregion

    #endregion


    #region Méthodes
    // Start is called before the first frame update
    void Start()
    {
        #region Initialisations
        Initialisation("RatBlend");
        EnnemiInitialisation();
        RatInitialisation();
        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = monAnimator.GetCurrentAnimatorStateInfo(0);
        if (phaseIA == "Marche")
        {
            RatMarche();
            KeepDestination();
            EnnemiVision();
        } else if(phaseIA == "Poursuite")
        {
            EnnemiPoursuite();
            EnnemiChangePoursuiteIA();
        } else if(phaseIA == "Attaque")
        {
            RatAttaque();
            RatChangeAttaqueIA();
        } else if(phaseIA == "Mort")
        {
            EnnemiMort();
        }

        if(isDead && phaseIA != "Mort")
        {
            phaseIA = "Mort";
        }

    }

    #region Collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("PlayerArme"))
        {
            CollisionArmeDrBob(other.gameObject, other.GetComponent<ColliderAttaque>().mainParent.GetComponent<DrBob_Ep1>()._currentAttackBaton);
        }
    }

    #endregion



    #region Initialisation
    public void RatInitialisation()
    {
        RaycastHit hitEyesRat;
        Ray eyeRay = new Ray(eyes.transform.position, -eyes.transform.up);
        coinsSalle = new Transform[2];
        sizesSalle = new float[2];
        Debug.DrawRay(eyes.transform.position, -eyes.transform.up * 10);
        if (Physics.Raycast(eyeRay, out hitEyesRat, 10, initMask))
        {
            for (int ii = 0; ii < coinsSalle.Length; ii++)
            {
                coinsSalle[ii] = hitEyesRat.transform.GetChild(ii);
            }
            sizesSalle[0] = Mathf.Abs(coinsSalle[1].position.x - coinsSalle[0].position.x);
            sizesSalle[1] = Mathf.Abs(coinsSalle[1].position.z - coinsSalle[0].position.z);
        }
        MoveDestinationRat();

        phaseIA = "Marche";
    }
    #endregion



    #region Marche
    public void MoveDestinationRat()
    {
        int indX = 0;
        if (coinsSalle[1].position.x - coinsSalle[0].position.x < 0)
        {
            indX = 1;
        }


        int indZ = 0;
        if (coinsSalle[1].position.z - coinsSalle[0].position.z < 0)
        {
            indZ = 1;
        }

        NavMeshPath path = new NavMeshPath();

        while (path.status != NavMeshPathStatus.PathComplete)
        {
            float posX = coinsSalle[indX].position.x + Random.Range(0, sizesSalle[0]);
            float posZ = coinsSalle[indZ].position.z + Random.Range(0, sizesSalle[1]);

            destinationEnnemi.position = new Vector3(posX, 0, posZ);

            ennemiNavMesh.CalculatePath(destinationEnnemi.position, path);
        }
        destinationPosition = destinationEnnemi.position;
        ennemiNavMesh.destination = destinationEnnemi.position;
        monAnimator.SetBool("isWalking", true);
    }

    public void RatMarche()
    {
        if (ennemiNavMesh.remainingDistance == 0 && ennemiNavMesh.velocity.magnitude == 0 && !isWaiting)
        {
            StartCoroutine(RatWaitGoing());
            isWaiting = true;
        }
    }

    public IEnumerator RatWaitGoing()
    {
        monAnimator.SetBool("isWalking", false);
        yield return new WaitForSeconds(3);         //Temps de l'animation ensuite
        MoveDestinationRat();
        isWaiting = false;
    }
    #endregion



    #region Attaque
    public void RatAttaque()
    {
        if (!isAttaque && ennemiNavMesh.remainingDistance < distAttaque)
        { 
            monAnimator.SetBool("isAttack", true);
            StartCoroutine(RatMorsure());
            isAttaque = true;
        }
        
    }

    public IEnumerator RatMorsure()
    {
        while (stateInfo.normalizedTime < 1.1f)
        {
            if (stateInfo.normalizedTime > 0.7f && !colliderAttaque.enabled)
            {
                colliderAttaque.enabled = true;
            }
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        monAnimator.SetBool("isAttack", false);
        colliderAttaque.enabled = false;
        yield return new WaitForSeconds(0.3f);
        isAttaque = false;
    }


    public void RatChangeAttaqueIA()
    {
        ennemiNavMesh.destination = drBobGO.transform.position;
        if (ennemiNavMesh.remainingDistance > distAttaque)
        {
            phaseIA = "Poursuite";
            monAnimator.SetBool("isWalking", true);
        }
    }
    #endregion



    #endregion


}
