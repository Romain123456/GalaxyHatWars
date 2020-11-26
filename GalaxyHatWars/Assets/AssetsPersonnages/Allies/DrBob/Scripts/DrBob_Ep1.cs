using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class DrBob_Ep1 : DrBob
{
    #region Variables
    #region Camera Episode1
    [HideInInspector] public Transform maPiece;
    public string actualPiece = "Piece1";
    [HideInInspector] public float ep1_newPosCamX;
    [HideInInspector] public float ep1_newPosCamY;
    [HideInInspector] public float ep1_newPosCamZ;
    [HideInInspector] public GameObject[] coinsSalle;
    [HideInInspector] public Vector3 ep1_Rot0_Cam;
    public float ep1_seuil_cam_dx;
    public float ep1_seuil_cam_dz;
    public float ep1_camMoveSpeed;
    #endregion

    #endregion





    #region Methodes
    private void Awake()
    {
        
        Initialisation("DrBobBlend");

        DrBob_Initialisation();

        ControlsInitialisation();
        RunKeyBoardInput();
        BatonFightInput();
        InterractionZoneInput();
        InterractionObjetInput();
        ReverseTourneObjectInput();
        DialoguesInput();

        ActivationGameplay();

        CameraInitialisationSalle_Episode1();

    }


    // Start is called before the first frame update
    void Start()
    {
        AnimationHashAttribution();
        SwitchBatonVisible();
    }

    // Update is called once per frame
    void Update()
    {
        DetectDeviceUsed();
        if (!isDead)
        {
            if (batonVisible == 1 && !feuBaton.activeInHierarchy)
            {
                DrBob_RangeBaton();
            }
            InterractionEyesActions();

            if (!isPousseBloc && !isTireLevier)
            {
                DrBob_WalkRun();
                DrBob_MovePerso();
            }
            else if (isPousseBloc)
            {
                WalkPousse();
                DrBob_MovePerso();
            }
            else if (isTireLevier)
            {
                TireLevier();
            }

            DrBob_VerticalMovement();
            AnimatorCheck();

            DrBob_IdleChange();


            #region Camera
            MouvementCamera_Episode1();
            #endregion
        } else
        {
            DrBob_Mort();
        }
    }


    #region Collisions 
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnnemiArme"))
        {
            float attaqueEnnemi = 0;
            if (other.transform.GetComponent<ColliderAttaque>() != null)
            {
                if (other.transform.GetComponent<ColliderAttaque>().mainParent.name == "Rat")
                {
                    attaqueEnnemi = other.transform.GetComponent<ColliderAttaque>().mainParent.GetComponent<Rat_Ep1
                        >().attaque;
                }
            }
            else if (other.transform.GetComponent<MunitionEnnemi>() != null)
            {
                attaqueEnnemi = other.transform.GetComponent<MunitionEnnemi>().attaque;
            }
            CollisionAttaqueEnnemi(other.gameObject,attaqueEnnemi);
        }

        if (other.transform.CompareTag("Bonus"))
        {
            DrBob_RecupereBonus(other.gameObject);
        }
    }

    #endregion


    #region Camera Episode 1
    public void CameraInitialisationSalle_Episode1()
    {
        maPiece = GameObject.Find(actualPiece).transform;
        Transform solPiece = maPiece.Find("Sol");
        ep1_newPosCamY = 30;
        coinsSalle = new GameObject[2];
        for (int ii = 0; ii < coinsSalle.Length; ii++)
        {
            if (solPiece.GetChild(ii).CompareTag("CoinEp1"))
            {
                coinsSalle[ii] = solPiece.GetChild(ii).gameObject;
            }
        }
        
        ep1_Rot0_Cam = mainCamera.transform.rotation.eulerAngles;
    }

    public void MouvementCamera_Episode1()
    {
        float cam_dx = mainCamera.transform.position.x - eyes.transform.position.x;

        if (eyes.transform.position.x > coinsSalle[0].transform.position.x && eyes.transform.position.x < coinsSalle[1].transform.position.x)
        {
            if (Mathf.Abs(cam_dx) > ep1_seuil_cam_dx)
            {
                ep1_newPosCamX = eyes.transform.position.x;
            }
        }
        else
        {
            ep1_newPosCamX = mainCamera.transform.position.x;
        }

        float cam_dz = mainCamera.transform.position.z - eyes.transform.position.z;
        if (eyes.transform.position.z > coinsSalle[0].transform.position.z && eyes.transform.position.z < coinsSalle[1].transform.position.z)
        {
            if (cam_dz != ep1_seuil_cam_dz)
            {
                ep1_newPosCamZ = eyes.transform.position.z - ep1_seuil_cam_dz;
            }
        }
        else
        {
            ep1_newPosCamZ = mainCamera.transform.position.z;
        }

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(ep1_newPosCamX, ep1_newPosCamY, ep1_newPosCamZ), ep1_camMoveSpeed * FonctionsVariablesGenerales.deltaTime);
    }

    #endregion

    #endregion



}
