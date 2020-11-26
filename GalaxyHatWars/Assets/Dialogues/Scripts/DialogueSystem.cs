using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //Initialisation
    [HideInInspector] public bool isDialogueActif;
    public GameObject imageSecondaire;
    [HideInInspector] public bool isImageSecondaire;

    //Perso Speaker
    public Image imagePersoSpeaker;
    public Text nomPersoSpeaker;

    //Texte Dialogue
    public Text textDialogue;

    //Audio du dialogue
    public AudioSource dialAudioSource;
    public AudioClip sonOuvertureDialogue;
    public AudioClip sonFermetureDialogue;
    public AudioClip sonNextPageDialogue;

    //Icone FinPanelDial
    public GameObject panelFinDialogue;
    public Image imageFinTexte;
    public Image imageCommande;
    public Sprite continueIcon;
    public Sprite finIcon;

    //DrBobInput
    [HideInInspector] public DrBob scriptDrBobInputs;

    private void Start()
    {
        scriptDrBobInputs = GameObject.FindWithTag("Player").GetComponent<DrBob>();
    }


    private void OnEnable()
    {
        //Est-ce qu'il y a une image secondaire ?
        imageSecondaire.SetActive(isImageSecondaire);

        //Le dialogue est actif
        isDialogueActif = true;

    }



    public void ActivateDialogue(Sprite[] _PersoSpeaker, string[] _NamePersoSpeaker, string[] _DialogueTexte, float[] _SpeedDialPerso, AudioClip[] _VoixDialPerso, bool _CanSkip)
    {
        if (!isDialogueActif)
        {
            //Activation du dialgue
            this.gameObject.SetActive(true);

            //Démarrage de la coroutine du dialogue
            StartCoroutine(StartingDialogue(_PersoSpeaker, _NamePersoSpeaker, _DialogueTexte, _SpeedDialPerso, _VoixDialPerso, _CanSkip));
        }

    }


    public void ActivateDialogue(bool _IsImageSecondaire, Sprite _SpriteImageSecondaire, Vector2 _SizeImageSecondaire, Sprite[] _PersoSpeaker, string[] _NamePersoSpeaker, string[] _DialogueTexte, float[] _SpeedDialPerso, AudioClip[] _VoixDialPerso, bool _CanSkip)
    {

        if (!isDialogueActif)
        {
            //Image Secondaire
            isImageSecondaire = _IsImageSecondaire;
            if (_IsImageSecondaire)
            {
                imageSecondaire.GetComponent<Image>().sprite = _SpriteImageSecondaire;
                imageSecondaire.GetComponent<RectTransform>().sizeDelta = _SizeImageSecondaire;
            }

            //Activation du dialgue
            this.gameObject.SetActive(true);

            //Démarrage de la coroutine du dialogue
            StartCoroutine(StartingDialogue(_PersoSpeaker, _NamePersoSpeaker, _DialogueTexte, _SpeedDialPerso, _VoixDialPerso, _CanSkip));
        }

    }




    public void DesactiveDialogue()
    {
        this.gameObject.SetActive(false);
    }

    [HideInInspector] public bool inputSuite = false;
    [HideInInspector] public bool enAmarre = false;
    public IEnumerator StartingDialogue(Sprite[] _PersoSpeaker, string[] _NamePersoSpeaker, string[] _DialogueTexte, float[] _SpeedDialPerso, AudioClip[] _VoixDialPerso, bool _CanSkip)
    {

        //Initialisation du dialogue
        int nbDialogue = _DialogueTexte.Length;
        int currentDial = 0;
        

        dialAudioSource.PlayOneShot(sonOuvertureDialogue);

        //Tant qu'on n'a des pages de dialogue
        while(currentDial < nbDialogue)
        {
            //Panel fin de dialogue est désactivé
            panelFinDialogue.SetActive(false);
            enAmarre = false;
            inputSuite = false;

            //On donne l'image et le nom du speaker
            imagePersoSpeaker.sprite = _PersoSpeaker[currentDial];
            nomPersoSpeaker.text = _NamePersoSpeaker[currentDial];

            while (dialAudioSource.isPlaying)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                if (!dialAudioSource.isPlaying)
                {
                    break;
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);

            //On donne le texte du dialogue
            string pageDialText = _DialogueTexte[currentDial];
            textDialogue.text = "";
            int indiceTexteDial = 0;

            //Défilement du texte
            while (indiceTexteDial < pageDialText.Length)
            {
                //Son de la voix du perso
                dialAudioSource.PlayOneShot(_VoixDialPerso[currentDial]);
                yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime/ (_SpeedDialPerso[currentDial] /100 ));


                //Incrémentation du texte
                textDialogue.text += pageDialText[indiceTexteDial];
                indiceTexteDial++;

                //Si on en a marre, on peut aller directement à la fin de la page de dialogue
                if (enAmarre)
                {
                    textDialogue.text = pageDialText;
                    indiceTexteDial = pageDialText.Length;
                }

                //A la fin, on attend que le joueur appuie sur la suite
                if(indiceTexteDial >= pageDialText.Length)
                {
                    dialAudioSource.Stop();
                    break;
                }
            }

            //Panel fin image est activé
            enAmarre = false;
            panelFinDialogue.SetActive(true);
            if(currentDial < nbDialogue - 1)
            {
                imageFinTexte.sprite = continueIcon;
            } else if(currentDial == nbDialogue - 1)
            {
                imageFinTexte.sprite = finIcon;
            }

            //Tant qu'on n'a pas appuyé sur le bouton de suite du dialogue, on ne passe pas à la page suivante et on attent
            while (!inputSuite)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                if (inputSuite)
                {
                    break;
                }

                //Désactive le dialogue si on en a marre
                if (enAmarre && _CanSkip)
                {
                    StartCoroutine(FermetureDialogue());
                }
            }

            //Page suivante
            currentDial++;
            if (currentDial < nbDialogue)
            {
                dialAudioSource.PlayOneShot(sonNextPageDialogue);
                while (dialAudioSource.isPlaying)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    if (!dialAudioSource.isPlaying)
                    {
                        break;
                    }
                }
            }
            inputSuite = false;
        }

        //Fin du dialogue
        yield return new WaitForSeconds(Time.deltaTime);
        StartCoroutine(FermetureDialogue());
    }


    public IEnumerator FermetureDialogue()
    {
        enAmarre = false;
        dialAudioSource.PlayOneShot(sonFermetureDialogue);
        while (dialAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            if (!dialAudioSource.isPlaying)
            {
                textDialogue.text = "";
                scriptDrBobInputs.DesActiavtionDialogue();
                isDialogueActif = false;
                DesactiveDialogue();
                break;
            }
        }
    }

}
