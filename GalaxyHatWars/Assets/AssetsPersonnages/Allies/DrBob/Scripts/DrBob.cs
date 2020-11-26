using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class DrBob : Personnage
{
    /*Classe DrBob, qui regroupe les caractéristiques générales de DrBob sur tous les épisodes*/

    #region Variables
    #region Composants
    [HideInInspector] public CharacterController drBobCharacterController;
    #endregion

    #region Animations
    [HideInInspector] public int idle1Hash;
    [HideInInspector] public int hit1Hash;
    [HideInInspector] public int hit2Hash;
    [HideInInspector] public int hit3Hash;
    [HideInInspector] public int walkHash;
    [HideInInspector] public int runHash;
    [HideInInspector] public int jumpHash;
    [HideInInspector] public int rangeBatonHash;
    [HideInInspector] public int allumeBatonHash;
    [HideInInspector] public int tourneMirroirHash;

    [HideInInspector] public float countIdle;
    [HideInInspector] public int choixAnimIdle;
    #endregion

    #region Controles
    [HideInInspector] public GalaxyHatWars_Inputs controls;
    [HideInInspector] public string deviceUsed;
    [HideInInspector] public string deviceKeyboardMouse = "ClavierSouris";
    [HideInInspector] public string deviceGamepad = "Gamepad";
    [HideInInspector] public Keyboard kb;
    [HideInInspector] public Gamepad gp;
    [HideInInspector] public Mouse mse;
    #endregion

    #region Deplacement Horizontal
    [HideInInspector] public bool isrun_kb;
    public float coeffInertie;
    [HideInInspector] public float moving;
    [HideInInspector] public Vector2 sensForward = new Vector2();
    [HideInInspector] public bool canWalk;
    [HideInInspector] public float coeffWalk;
    [HideInInspector] public float factorRun = 2;
    [HideInInspector] public float factorWalk = 1;
    [HideInInspector] public float factorSneak = 0.5f;
    [HideInInspector] public int switchWalkHit = 1;
    [HideInInspector] public Vector3 directionToMove = new Vector3();
    #endregion

    #region Rotation
    Vector3 dirToRotate = new Vector3();
    [HideInInspector] public float turnDiffAngle;
    public float seuilTurnDiffAngle;
    [HideInInspector] public float coeffTurnAngle = 10;
    #endregion

    #region Saut
    public float gravity;
    public float jumpForce;
    public bool isJump;
    [HideInInspector] public bool launchJump;
    #endregion

    #region Combat Baton
    [HideInInspector] public bool ishit;
    [HideInInspector] public bool nextHitBaton;
    [HideInInspector] public bool goNextHit;
    public float timeRangeBaton;
    public GameObject batonDos;
    public GameObject batonMain;
    [HideInInspector] public int batonVisible;
    [HideInInspector] public float countRangeBaton;
    public GameObject slashEffect;
    public AudioSource audioSourceBaton;
    public AudioClip[] hitBatonSound;
    public AudioClip[] hitVoice;
    [HideInInspector] public float _currentAttackBaton;
    #endregion

    #region Interraction Objects
    public float eyesPortee;
    [HideInInspector] public RaycastHit hitEyesRay;
    private Transform objectInterractions;
    [HideInInspector] public bool isPousseBloc;
    [HideInInspector] public bool isTourneObject;
    [HideInInspector] public bool isTireLevier;
    public float factorInertiePousse;
    public float factorSpeedPousse;
    [HideInInspector] public int senseRotateObject = 1;
    public float speedRotateObject;
    #endregion

    #region Autres GameObject
    [HideInInspector] public GameObject mainCamera;
    public GameObject feuBaton;
    #endregion

    #region Interaction Zone
    [HideInInspector] public bool isInInteraction;
    [HideInInspector] public bool isActionInteraction;
    [HideInInspector] public string tagInterractionObject;
    [HideInInspector] public Transform transformZoneInteract;
    #endregion

    #region OnTrigger Special
    [HideInInspector] public bool isOnTriggerSpecial;
    [HideInInspector] public bool actionTriggerSpecial;
    #endregion

    #region Dialogues
    //Dialogue System
    public DialogueSystem dialogueScript;
    public Sprite imageScript;
    public Vector2 imageScriptSize;
    public Sprite[] imagePersoSpeaker;
    public string[] nomPersoSpeaker;
    public string[] dialogueTexte;
    public float[] speedDialPerso;
    public AudioClip[] voixDialPerso;
    #endregion


    #endregion






    #region Méthodes
    public void DrBob_Initialisation()
    {
        mainCamera = GameObject.Find("Main Camera");
        drBobCharacterController = monTransform.GetComponent<CharacterController>();
    }

    
    public void DetectDeviceUsed()
    {
        if (gp != null)
        {
            if (deviceUsed != deviceKeyboardMouse && (kb.anyKey.wasPressedThisFrame || mse.wasUpdatedThisFrame))
            {
                deviceUsed = deviceKeyboardMouse;
            }
            else if (deviceUsed != deviceGamepad && gp.wasUpdatedThisFrame)
            {
                deviceUsed = deviceGamepad;
            }
        }
        else
        {
            deviceUsed = deviceKeyboardMouse;
        }
    }


    #region Inputs Management
    public void ControlsInitialisation()
    {
        kb = InputSystem.GetDevice<Keyboard>();
        gp = InputSystem.GetDevice<Gamepad>();
        mse = InputSystem.GetDevice<Mouse>();
        controls = new GalaxyHatWars_Inputs();
    }

    public void ActivationGameplay()
    {
        controls.Gameplay.Enable();
        controls.DialogueSystem.Disable();
    }

    public void RunKeyBoardInput()
    {
        controls.Gameplay.RunKeyboard.performed += ctx => RunKeyboard();
    }

    public void BatonFightInput()
    {
        controls.Gameplay.BatonFight.performed += ctx => FightBaton();
        controls.Gameplay.BatonFight.canceled += ctx => StopFight();
    }


    public void InterractionZoneInput()
    {
        controls.Gameplay.InteractionZone.started += ctx => DrBob_ActionZoneInteraction();
        controls.Gameplay.InteractionZone.canceled += ctx => DrBob_ActionZoneInteractionCancelled();
        controls.Gameplay.InteractionZone.performed += ctx => OnTriggerSpecial();
        controls.Gameplay.InteractionZone.canceled += ctx => DesactiveTriggerSpecial();
    }


  

    public void JumpInput()
    {
        controls.Gameplay.Jump.started += ctx => DrBob_JumpAction();
    }

    public void InterractionObjetInput()
    {
        controls.Gameplay.InterractObject.performed += ctx => ActiveInterractObject();
        controls.Gameplay.InterractObject.canceled += ctx => DesactiveInterractObject();
    }

    public void ReverseTourneObjectInput()
    {
        controls.Gameplay.ReverseTourneObject.performed += ctx => ReverseTourneObject();
        controls.Gameplay.ReverseTourneObject.canceled += ctx => CancelledReverseTourneObject();
    }
    #endregion



    #region ActionZone
    public void DrBob_ActionZoneInteraction()
    {
        if (isInInteraction && !isActionInteraction)
        {
            isActionInteraction = true;
        }
        else
        {
            isActionInteraction = false;
            
        }

        if(tagInterractionObject == "Coffre")
        {
            StartCoroutine(DrBob_OuvertureCoffres());
        }

        if(tagInterractionObject == "Panneau")      //Ou pour les PNJ
        {
            DrBob_PanneauDialogue();
        }
    }

    public void DrBob_ActionZoneInteractionCancelled()
    {
        if (isInInteraction && isActionInteraction)
        {
            isActionInteraction = false;
        }
    }



    #endregion

    #region Trigger Special
    public void OnTriggerSpecial()
    {
        if(isOnTriggerSpecial && !actionTriggerSpecial)
        {
            actionTriggerSpecial = true;
        }
        else
        {
            actionTriggerSpecial = false;
        }
    }

    public void DesactiveTriggerSpecial()
    {
        if(isOnTriggerSpecial && actionTriggerSpecial)
        {
            actionTriggerSpecial = false;
        }
    }
    #endregion



    #region Coffres
    #region Ouverture Petits Coffres
    public IEnumerator DrBob_OuvertureCoffres()
    {
        Coffre coffreScript = transformZoneInteract.GetComponent<Coffre>();
        controls.Gameplay.Disable();
        yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        monTransform.position = coffreScript.positionOuverture.position;
        monTransform.rotation = coffreScript.positionOuverture.rotation;
        batonVisible = 0;
        SwitchBatonVisible();
        monAnimator.SetBool(coffreScript.animOuverture, true);
        while(stateInfo.normalizedTime < coffreScript.timeAnim)
        {
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        monAnimator.SetBool(coffreScript.animOuverture, false);
        coffreScript.LaunchOuverture();

        if (transformZoneInteract.GetComponent<DialogueObject>() != null)
        {
            yield return new WaitForSeconds(1.5f);
            ActivationDialogue();
        } else
        {
            transformZoneInteract = null;
            tagInterractionObject = "";
            controls.Gameplay.Enable();
        }
    }
    #endregion
    #endregion


    #region Dialogues
    public void DialoguesInput()
    {
        controls.DialogueSystem.ToTheNext.started += ctx => NextPageDialogue();
        controls.DialogueSystem.SkipDial.started += ctx => CancelNextPage();
    }
    void NextPageDialogue()
    {
        dialogueScript.inputSuite = true;
    }
    void CancelNextPage()
    {
        dialogueScript.enAmarre = true;
    }

    void ActivationDialogue()
    {
        controls.Gameplay.Disable();
        controls.DialogueSystem.Enable();

        DialogueObject monDialogue = transformZoneInteract.GetComponent<DialogueObject>();

        #region Attribution Caractéristiques Dialogue
        imageScript = monDialogue.imageSecondaire;
        imageScriptSize = monDialogue.imageSecondaireSize;
        imagePersoSpeaker = monDialogue.imagesSpeakers;
        nomPersoSpeaker = monDialogue.nomsSpeakers;
        dialogueTexte = monDialogue.dialogueTextes;
        speedDialPerso = monDialogue.speedDialSpeakers;
        voixDialPerso = monDialogue.voixDialSpeakers;
        #endregion

        if (monDialogue.imageSecondaire == null)
        {
            dialogueScript.ActivateDialogue(imagePersoSpeaker, nomPersoSpeaker, dialogueTexte, speedDialPerso, voixDialPerso, true);
        } else
        {
            dialogueScript.ActivateDialogue(true, imageScript, imageScriptSize, imagePersoSpeaker, nomPersoSpeaker, dialogueTexte, speedDialPerso, voixDialPerso, true);
        }
    }

    public void DesActiavtionDialogue()
    {
        controls.Gameplay.Enable();
        controls.DialogueSystem.Disable();
        transformZoneInteract = null;
        tagInterractionObject = "";
    }
    #endregion



    #region Panneaux
    public void DrBob_PanneauDialogue()
    {
        ActivationDialogue();
    }

    #endregion



    #region Interraction Objects
    public void InterractionEyesActions()
    {
        // On lance le Raycast à une distance raisonnable
        Vector3 seeDirection = new Vector3();
        seeDirection = eyes.transform.forward * eyesPortee;
        Debug.DrawRay(eyes.transform.position, seeDirection, Color.black);
        if (Physics.Raycast(eyes.transform.position, seeDirection, out hitEyesRay, eyesPortee))
        {
            if (hitEyesRay.transform.CompareTag("PousseObject") && isPousseBloc)
            {
                batonVisible = 0;
                SwitchBatonVisible();
                monAnimator.SetBool("isPousseBloc", true);
                objectInterractions = hitEyesRay.transform;

            }
            else if (hitEyesRay.transform.CompareTag("TourneObject") && isTourneObject)
            {
                batonVisible = 0;
                SwitchBatonVisible();
                monAnimator.SetBool("isTourneMirroir", true);
                objectInterractions = hitEyesRay.transform;
                RotateObject();
            }
            else if (hitEyesRay.transform.CompareTag("TireLevier") && isTireLevier)
            {
                batonVisible = 0;
                SwitchBatonVisible();
                monAnimator.SetBool("isTireLevier", true);
                objectInterractions = hitEyesRay.transform;
            }
            else if (hitEyesRay.transform.CompareTag("Porte"))
            {
                objectInterractions = hitEyesRay.transform;
            }
        }
        else
        {
            monAnimator.SetBool("isTourneMirroir", false);
            monAnimator.SetBool("isPousseBloc", false);
            monAnimator.SetBool("isTireLevier", false);
            if (isTireLevier)
            {
                if (objectInterractions != null && objectInterractions.CompareTag("TireLevier"))
                {
                    hitEyesRay.transform.GetComponent<TireLevierScript>().isTire = false;
                }
            }
            objectInterractions = null;
        }

    }

    public void ActiveInterractObject()
    {
        if (hitEyesRay.transform != null)
        {
            if (hitEyesRay.transform.CompareTag("PousseObject"))
            {
                isPousseBloc = true;
            }
            else if (hitEyesRay.transform.CompareTag("TourneObject"))
            {
                isTourneObject = true;
            }
            else if (hitEyesRay.transform.CompareTag("TireLevier"))
            {
                isTireLevier = true;
                monTransform.rotation = Quaternion.Euler(Vector3.zero);
                monTransform.position = new Vector3(hitEyesRay.transform.GetChild(0).position.x, monTransform.position.y, hitEyesRay.transform.GetChild(0).position.z);
                hitEyesRay.transform.GetComponent<TireLevierScript>().isTire = true;
            } else if (hitEyesRay.transform.CompareTag("Porte"))
            {
                OuvrirPorte();
            }
        }
    }
    public void DesactiveInterractObject()
    {
        isPousseBloc = false;
        isTourneObject = false;
        isTireLevier = false;
        if (objectInterractions!=null && objectInterractions.CompareTag("TireLevier"))
        {
            hitEyesRay.transform.GetComponent<TireLevierScript>().isTire = false;
        }

        monAnimator.SetBool("isPousseBloc", false);
        monAnimator.SetBool("isTourneMirroir", false);
        monAnimator.SetBool("isTireLevier", false);
        objectInterractions = null;
    }

    public void ReverseTourneObject()
    {
        if (stateInfo.fullPathHash == tourneMirroirHash)
        {
            monAnimator.SetBool("isReverseMirroir", true);
            senseRotateObject = -1;
        }
        else
        {
            monAnimator.SetBool("isReverseMirroir", false);
            senseRotateObject = 1;
        }
    }

    public void CancelledReverseTourneObject()
    {
        monAnimator.SetBool("isReverseMirroir", false);
        senseRotateObject = 1;
    }

    public void RotateObject()
    {
        if (stateInfo.normalizedTime - (int)stateInfo.normalizedTime < 0.8f)
        {
            objectInterractions.Rotate(0, senseRotateObject * speedRotateObject * FonctionsVariablesGenerales.deltaTime, 0);
        }
    }


    public void OuvrirPorte()
    {
        Porte scriptPorte = objectInterractions.transform.GetComponent<Porte>();

        if (scriptPorte.isClosed)
        {
            if (!scriptPorte.porteAudio.isPlaying)
            {
                scriptPorte.porteAudio.PlayOneShot(scriptPorte.sonClose);
            }
        } else
        {
            if (!scriptPorte.isOpen)
            {
                StartCoroutine(scriptPorte.OuverturePorte(scriptPorte.speedOuvre*FonctionsVariablesGenerales.deltaTime));
                scriptPorte.isOpen = true;
            }
        }
    }

    #endregion


    #region Bruits de Pas
    public void BruitPasSound()
    {
        //Bruits de pas
        if (!monAudioSource.isPlaying && switchWalkHit == 1)
        {
            if (monAudioSource.clip != pasSon)
            {
                monAudioSource.clip = pasSon;
            }
            monAudioSource.loop = true;
            monAudioSource.Play();
            coeffWalk = factorWalk;
            monAudioSource.pitch = factorWalk;
        }
        else if (switchWalkHit == 0 && monAudioSource.isPlaying && !colliderAttaque.enabled)
        {
            StopSound();
        }
    }


    public void StopSound()
    {
        monAudioSource.clip = null;
        monAudioSource.Stop();
        monAudioSource.pitch = 1;
    }
    #endregion


    #region Combat 
    #region Combat Baton
    public void SwitchBatonVisible()
    {
        if (batonVisible == 0)
        {
            batonDos.SetActive(true);
            batonMain.SetActive(false);
        }
        else if (batonVisible == 1)
        {
            batonDos.SetActive(false);
            batonMain.SetActive(true);
        }
    }

    public void DrBob_RangeBaton()
    {
        if (stateInfo.fullPathHash == idle1Hash)
        {
            if (monAnimator.GetBool("isRangeBaton"))
            {
                monAnimator.SetBool("isRangeBaton", false);
            }
            countRangeBaton += FonctionsVariablesGenerales.deltaTime;
            if (countRangeBaton >= timeRangeBaton)
            {
                countRangeBaton = 0;
                monAnimator.SetBool("isRangeBaton", true);
            }
        }
        else if (stateInfo.fullPathHash != rangeBatonHash)
        {
            countRangeBaton = 0;
        }
        else if (stateInfo.fullPathHash == rangeBatonHash)
        {
            if (stateInfo.normalizedTime > 0.5f && batonVisible == 1)
            {
                batonVisible = 0;
                SwitchBatonVisible();
            }
        }
    }

    public void FightBaton()
    {
        if (!ishit)
        {
            monAnimator.SetBool("isRunning", false);
            monAudioSource.pitch = 1;
            ishit = true;
            batonVisible = 1;
            SwitchBatonVisible();
        }
        monAnimator.SetBool("isHit", ishit);
        //Debug.Log(nextHitBaton);
    }

    public void StopFight()
    {
        ishit = false;
        monAnimator.SetBool("isHit", ishit);
    }

    public void AnimationCombatBaton()
    {
        if (stateInfo.fullPathHash == hit1Hash)
        {
            DrBob_NextStepHitBaton(false, 0, true, 0.75f, 1.6f);
            DrBob_HitFX(0.25f, 1f, 0);
            _currentAttackBaton = attaque;
        }
        else if (stateInfo.fullPathHash == hit2Hash)
        {
            DrBob_NextStepHitBaton(true, 0.5f, true, 0.8f, 1.3f);
            DrBob_HitFX(0.45f, 1.2f, 1);
            _currentAttackBaton = attaque * 1.5f;
        }
        else if (stateInfo.fullPathHash == hit3Hash)
        {
            DrBob_NextStepHitBaton(true, 0.5f, false, 0, 0.95f);
            DrBob_HitFX(0.25f, 0.9f, 2);
            _currentAttackBaton = attaque * 2;
        }
        else
        {
            nextHitBaton = false;
            goNextHit = false;
            monAnimator.SetBool("goNextHit", goNextHit);
        }
    }

    public void DrBob_NextStepHitBaton(bool _IsPreviousAttack, float _PreviousAttackLock, bool _IsNextAttack, float _NextAttackTimeUnlock, float _InitialStateTime)
    {
        //On empêche de marcher pendant l'animation
        switchWalkHit = 0;

        //On remet l'enchaînement d'une prochaine attaque à zéro si on a une attaque avant
        if (_IsPreviousAttack)
        {
            if (goNextHit && stateInfo.normalizedTime < _PreviousAttackLock)
            {
                goNextHit = false;
                monAnimator.SetBool("goNextHit", goNextHit);
            }
        }



        //Prochaine attaque
        if (_IsNextAttack)
        {
            //On donne la possibilité d'enchaîner une nouvelle attaque
            if (stateInfo.normalizedTime > _NextAttackTimeUnlock)
            {
                nextHitBaton = true;
            }

            //On enchaine une nouvelle attaque si on a cliqué
            if (nextHitBaton && ishit)
            {
                goNextHit = true;
                monAnimator.SetBool("goNextHit", goNextHit);
            }
        }

        //On retourne à l'état initial si on n'enchaîne pas une nouvelle attaque
        if (stateInfo.normalizedTime > _InitialStateTime && !goNextHit)
        {
            switchWalkHit = 1;
        }


    }

    public void DrBob_HitFX(float _MinTime, float _MaxTime, int indEffect)
    {
        if (!slashEffect.activeSelf && stateInfo.normalizedTime < _MinTime)
        {
            colliderAttaque.enabled = true;

            slashEffect.SetActive(true);
            for (int ii = 0; ii < slashEffect.transform.childCount; ii++)
            {
                if (ii == indEffect)
                {
                    slashEffect.transform.GetChild(ii).gameObject.SetActive(true);
                    monAudioSource.clip = hitVoice[ii];
                    monAudioSource.PlayOneShot(monAudioSource.clip);
                    audioSourceBaton.PlayOneShot(hitBatonSound[ii]);
                }
                else
                {
                    slashEffect.transform.GetChild(ii).gameObject.SetActive(false);
                }
            }
        }

        if (slashEffect.activeSelf && stateInfo.normalizedTime > _MaxTime)
        {
            slashEffect.SetActive(false);
            colliderAttaque.enabled = false;
        }
    }

    #endregion


    #region Combat Pied

    #endregion


    #endregion


    #region Marche/Course

    public void DrBob_StopMove()
    {
        moving = 0;
        monAnimator.SetBool("isWalking", false);
        monAnimator.SetBool("isRunning", false);
    }

    public void DrBob_WalkRun()
    {
        if (drBobCharacterController.isGrounded && !monAnimator.GetBool("isAllumeBaton") && !colliderAttaque.enabled)
        {
            sensForward = controls.Gameplay.SensForward.ReadValue<Vector2>();
            float angleToRotate = Vector2.Angle(Vector2.up, sensForward);
            if (sensForward.x < 0)
            {
                angleToRotate = -angleToRotate;
            }
            dirToRotate.x = monTransform.rotation.eulerAngles.x;
            dirToRotate.z = monTransform.rotation.eulerAngles.z;
            dirToRotate.y = angleToRotate;

            if (sensForward != Vector2.zero)
            {
                monTransform.rotation = Quaternion.Slerp(monTransform.rotation, Quaternion.Euler(dirToRotate), coeffTurnAngle * speedRot * FonctionsVariablesGenerales.deltaTime);
                turnDiffAngle = monTransform.rotation.eulerAngles.y - dirToRotate.y;
                if (turnDiffAngle > 180)
                {
                    turnDiffAngle -= 360;
                }
                if (Mathf.Abs(turnDiffAngle) < seuilTurnDiffAngle)
                {
                    canWalk = true;
                    coeffTurnAngle = 1;
                }
            }


            
            if (sensForward.magnitude != 0 && canWalk)
            {
                
                moving += coeffInertie;
                if (moving >= 1)
                {
                    moving = 1;
                }
                if (deviceUsed == deviceKeyboardMouse)
                {
                    //Move clavier
                    monAnimator.SetBool("isWalking", true);
                    monAnimator.SetBool("isRunning", isrun_kb);
                }
                else
                {
                    //Move manette
                    monAnimator.SetBool("isWalking", true);
                    if (sensForward.magnitude > 0.8f)
                    {
                        monAnimator.SetBool("isRunning", true);
                    }
                    else
                    {
                        monAnimator.SetBool("isRunning", false);
                    }
                }



                if (monAnimator.GetBool("isWalking"))
                {
                    //Bruits de pas
                    BruitPasSound();


                    if (monAnimator.GetBool("isRunning"))
                    {
                        coeffWalk = factorRun;
                        monAudioSource.pitch = factorRun;
                    }
                    else
                    {
                        coeffWalk = factorWalk;
                        monAudioSource.pitch = factorWalk;
                    }
                }
            }
            else
            {
                monAnimator.SetBool("isWalking", false);
                isrun_kb = false;
                monAnimator.SetBool("isRunning", isrun_kb);
                moving -= coeffInertie;
                if (moving <= 0)
                {
                    canWalk = false;
                    coeffTurnAngle = 2.5f;
                    moving = 0;
                    if (!colliderAttaque.enabled)
                    {
                        StopSound();
                    }
                }
            }
        }
        else
        {
            if (!colliderAttaque.enabled)
            {
                StopSound();
            }
            monAnimator.SetBool("isWalking", false);
            monAnimator.SetBool("isRunning", false);
            monAudioSource.pitch = 1;
        }
        directionToMove.z = speedMvt * moving * coeffWalk * switchWalkHit;
    }


    public void WalkPousse()
    {
        sensForward = controls.Gameplay.SensForward.ReadValue<Vector2>();

        if (sensForward != Vector2.zero)
        {
            if (Mathf.Abs(objectInterractions.position.x - monTransform.position.x) > objectInterractions.GetComponent<BoxCollider>().bounds.extents.x && Mathf.Abs(objectInterractions.position.z - monTransform.position.z) < objectInterractions.GetComponent<BoxCollider>().bounds.extents.z)          //Cas où on est sur le côté droit ou gauche du bloc
            {
                if (objectInterractions.position.x > monTransform.position.x && sensForward.y == 0 && sensForward.x > 0)
                {
                    canWalk = true;
                }
                else if (objectInterractions.position.x < monTransform.position.x && sensForward.y == 0 && sensForward.x < 0)
                {
                    canWalk = true;
                }
            }
            else if (Mathf.Abs(objectInterractions.position.z - monTransform.position.z) > objectInterractions.GetComponent<BoxCollider>().bounds.extents.z && Mathf.Abs(objectInterractions.position.x - monTransform.position.x) < objectInterractions.GetComponent<BoxCollider>().bounds.extents.x)
            {
                if (objectInterractions.position.z > monTransform.position.z && sensForward.x == 0 && sensForward.y > 0)
                {
                    canWalk = true;
                }
                else if (objectInterractions.position.z < monTransform.position.z && sensForward.x == 0 && sensForward.y < 0)
                {
                    canWalk = true;
                }
            }
        }


        if (sensForward.magnitude != 0 && canWalk)
        {
            moving += coeffInertie / factorInertiePousse;
            if (moving >= 1)
            {
                moving = 0;
            }
            monAnimator.SetBool("isWalking", true);

            if (monAnimator.GetBool("isWalking"))
            {
                //Bruits de pas
                BruitPasSound();
            }
        }
        else
        {
            monAnimator.SetBool("isWalking", false);
            moving -= coeffInertie;
            if (moving <= 0)
            {
                canWalk = false;
                coeffTurnAngle = 2.5f;
                moving = 0;
                StopSound();
            }
        }


        directionToMove.z = speedMvt / factorSpeedPousse * moving * coeffWalk * switchWalkHit;
        if (objectInterractions != null)
        {
            objectInterractions.transform.Translate(monTransform.forward * directionToMove.z * FonctionsVariablesGenerales.deltaTime);
        }
    }


    public void TireLevier()
    {
        sensForward = controls.Gameplay.SensForward.ReadValue<Vector2>();

        if (sensForward.y < 0)
        {
            canWalk = true;
        }

        if (sensForward.magnitude != 0 && canWalk)
        {
            moving += coeffInertie / factorInertiePousse;
            if (moving >= 1)
            {
                moving = 1;
            }
            monAnimator.SetBool("isWalking", true);

            if (monAnimator.GetBool("isWalking"))
            {
                //Bruits de pas
                BruitPasSound();
            }
        }
        else
        {
            monAnimator.SetBool("isWalking", false);
            moving -= coeffInertie;
            if (moving <= 0)
            {
                canWalk = false;
                moving = 0;

                StopSound();
            }
        }


        directionToMove.z = -speedMvt / factorSpeedPousse * moving * coeffWalk * switchWalkHit;
        if (canWalk && Mathf.Abs(objectInterractions.transform.position.z - objectInterractions.GetComponent<TireLevierScript>().position0.z) < objectInterractions.GetComponent<TireLevierScript>().extensionLevier)
        {
            DrBob_MovePerso();
            if (objectInterractions != null)
            {
                objectInterractions.transform.Translate(monTransform.forward * directionToMove.z * FonctionsVariablesGenerales.deltaTime);
            }
        }
    }


    public void RunKeyboard()
    {
        isrun_kb = !isrun_kb;
    }


    public void DrBob_MovePerso()
    {
        drBobCharacterController.Move(transform.TransformDirection(directionToMove * FonctionsVariablesGenerales.deltaTime));
    }

    #endregion


    #region Saut
    public void AnimationSaut()
    {
        if (stateInfo.fullPathHash != jumpHash && launchJump && isJump)
        {
            monAnimator.SetBool("isJumping", true);
            launchJump = false;
        }
        else if (stateInfo.fullPathHash == jumpHash && !isJump && drBobCharacterController.isGrounded)
        {
            monAnimator.SetBool("isJumping", false);
            moving = 0;
        }
    }

    public void DrBob_VerticalMovement()
    {
        directionToMove.y -= gravity;
        if (directionToMove.y < -10f)
        {
            directionToMove.y = -10f;
        }

        //Mettre le saut ici si besoin (dans l'Update)
    }

    public void DrBob_Saut()
    {
        if (isJump && !launchJump)
        {
            launchJump = true;
            StartCoroutine(DrBob_LaunchJump());
        }
    }

    public IEnumerator DrBob_LaunchJump()
    {
        switchWalkHit = 0;
        yield return new WaitForSeconds(0.3f);
        directionToMove.y = jumpForce;
        isJump = false;
        switchWalkHit = 1;
    }

    public void DrBob_JumpAction()
    {
        if (drBobCharacterController.isGrounded && !isJump && !isPousseBloc && !isTourneObject)
        {
            isJump = true;
        }
    }

    #endregion


    #region Allumage Baton
    public void DrBob_AllumeBaton()
    {
        if (!monAnimator.GetBool("isAllumeBaton") && sensForward == Vector2.zero && !feuBaton.activeInHierarchy)
        {
            batonVisible = 1;
            SwitchBatonVisible();
            monAnimator.SetBool("isAllumeBaton", true);
            StartCoroutine(AllumageBaton());
        }
    }

    IEnumerator AllumageBaton()
    {
        while (stateInfo.normalizedTime < 1)
        {
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
            if (stateInfo.normalizedTime >= 0.9f)
            {
                feuBaton.SetActive(true);
                monAnimator.SetBool("isAllumeBaton", false);
                StartCoroutine(StopFeuBaton());
                break;
            }
        }
    }

    IEnumerator StopFeuBaton()
    {
        yield return new WaitForSeconds(5);
        feuBaton.SetActive(false);
    }


    #endregion


    #region Animations
    public void AnimationHashAttribution()
    {
        hit1Hash = Animator.StringToHash("Base Layer.DrBob_Hit1");
        hit2Hash = Animator.StringToHash("Base Layer.DrBob_Hit2");
        hit3Hash = Animator.StringToHash("Base Layer.DrBob_Hit3");
        walkHash = Animator.StringToHash("Base Layer.DrBob_Walk");
        runHash = Animator.StringToHash("Base Layer.DrBob_Run");
        idle1Hash = Animator.StringToHash("Base Layer.DrBob_Idle1");
        jumpHash = Animator.StringToHash("Base Layer.DrBob_Jump");
        rangeBatonHash = Animator.StringToHash("Base Layer.DrBob_RangeBaton");
        allumeBatonHash = Animator.StringToHash("Base Layer.DrBob_AllumeBaton");
        tourneMirroirHash = Animator.StringToHash("Base Layer.DrBob_TourneMirroir");
    }

    public void DrBob_IdleChange()
    {
        if (stateInfo.fullPathHash == idle1Hash && batonVisible == 0)
        {
            if (choixAnimIdle != 0)
            {
                choixAnimIdle = 0;
                monAnimator.SetInteger("IdleChange", choixAnimIdle);
            }
            countIdle += FonctionsVariablesGenerales.deltaTime;
            if (countIdle >= 2)
            {
                countIdle = 0;
                choixAnimIdle = Random.Range(1, 3);
                monAnimator.SetInteger("IdleChange", choixAnimIdle);
            }
        }
        else if (stateInfo.fullPathHash != idle1Hash || batonVisible != 0 && countIdle != 0)
        {
            countIdle = 0;
        }
        if (kb.anyKey.wasPressedThisFrame || mse.wasUpdatedThisFrame || (gp != null && gp.wasUpdatedThisFrame))
        {
            choixAnimIdle = 0;
            monAnimator.SetInteger("IdleChange", choixAnimIdle);
        }
    }

    public void AnimatorCheck()
    {
        stateInfo = monAnimator.GetCurrentAnimatorStateInfo(0);

        //Marche/Course switch combat
        AnimationMarche();

        //Saut
        AnimationSaut();

        //Combat
        AnimationCombatBaton();
    }

    public void AnimationMarche()
    {
        if (stateInfo.fullPathHash == walkHash || stateInfo.fullPathHash == runHash)
        {
            if (ishit)
            {
                switchWalkHit = 0;
            }
        }
    }

    #endregion


    #region Collisions Ennemis
    public void CollisionAttaqueEnnemi(GameObject _monCollider, float _attaque)
    {
        if (!isHurt)
        {
            StartCoroutine(PrendreCoupClignotte(_monCollider, _attaque,10));
            DrBob_InterfaceVie();
            isHurt = true;
        }
        
    }
    #endregion

    #region Interface Vie
    public void DrBob_InterfaceVie()
    {
        if((int)pv > 0)
        {
            for(int ii = 0; ii < (int)pv; ii++)
            {
                scriptGeneralites._VieImages[ii].fillAmount = 1;
            }
        }
        if (pv < pvMax)
        {
            scriptGeneralites._VieImages[(int)pv].fillAmount = pv - (int)pv;
        }
    }
    #endregion



    #region Mort DrBob
    public void DrBob_Mort()
    {
        Mort();

    }

    #endregion


    #region Bonus
    public void DrBob_RecupereBonus(GameObject _monCollider)
    {
        pv = pv + 1;
        if (pv > pvMax)
        {
            pv = pvMax;
        }
        Destroy(_monCollider);
        DrBob_InterfaceVie();
    }
    #endregion

    #endregion

}
