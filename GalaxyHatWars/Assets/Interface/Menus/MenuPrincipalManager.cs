using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    private GameObject lastBoutonSelected;
    [HideInInspector] public Mouse mse;
    [HideInInspector] public GalaxyHatWars_Inputs controls;

    #region Panel Commandes
    public GameObject imageRetour;
    #endregion


    #region Panels Menu Principal
    public GameObject panelLangage;
    public GameObject panelMenuPrincipal;
    public GameObject panelChoixNiveau;
    public BaseEventData eventData;
    [HideInInspector] public EventSystem myEventSystem;
    public GameObject boutonJouer;
    #endregion


    #region Liste Episodes
    public GameObject boutonChoixNiveau;
    public string[] titresEpisodes;
    [HideInInspector] public float axisInputEpisode;
    public Text textTitreEpisode;
    private bool canMoveEpisode = true;
    [HideInInspector] public int choixEpisode = 0;
    public Sprite spriteFlecheUnSelected;
    public Sprite spriteFlecheSelected;
    public Image imageFlecheUp;
    public Image imageFlecheDown;
    [HideInInspector] public AnimatorStateInfo stateInfoMenu;
    public Animator episodeChoiceAnimator;
    [HideInInspector] public bool inCharge;
    #endregion

    private void Awake()
    {
        controls = new GalaxyHatWars_Inputs();
        controls.Menu.Retour.performed += ctx => RetourMenuPrincipal();
    }


    // Start is called before the first frame update
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        mse = InputSystem.GetDevice<Mouse>();
        controls.Menu.Enable();

        //Premier Episode Sélectionné
        inCharge = false;
        textTitreEpisode.text = titresEpisodes[choixEpisode];
    }

    // Update is called once per frame
    void Update()
    {
        DebugClicSouris();

        //Uniquement dans le panel ChoixEpisode
        if (panelChoixNiveau.activeInHierarchy && !inCharge)
        {
            MoveListeEpisode();
        }
    }


    #region Selection Boutons Langage
    public void OnSelectLangage(GameObject _monBouton)
    {
        _monBouton.transform.Find("ImageSelected").gameObject.SetActive(true);
    }

    public void OnDeSelectLangage(GameObject _monBouton)
    {
        _monBouton.transform.Find("ImageSelected").gameObject.SetActive(false);
    }

    public void ChooseLangage(string _Langue)
    {
        FonctionsVariablesGenerales.langage = _Langue;
        panelLangage.SetActive(false);
        panelMenuPrincipal.SetActive(true);
        myEventSystem.SetSelectedGameObject(boutonJouer);
    }
    #endregion


    #region Menu Principal
    public void ChooseJouer()
    {
        panelMenuPrincipal.SetActive(false);
        panelChoixNiveau.SetActive(true);
        imageRetour.SetActive(true);
        myEventSystem.SetSelectedGameObject(boutonChoixNiveau);
    }

    public void RetourMenuPrincipal()
    {
        if (panelChoixNiveau.activeInHierarchy)
        {
            panelMenuPrincipal.SetActive(true);
            panelChoixNiveau.SetActive(false);
            imageRetour.SetActive(false);
            myEventSystem.SetSelectedGameObject(boutonJouer);
        }
    }
    #endregion


    #region Choix Episode
    public void MoveListeEpisode()
    {
        axisInputEpisode = controls.Menu.UpDownManual.ReadValue<float>();
        if (!canMoveEpisode && axisInputEpisode == 0)
        {
            canMoveEpisode = true;
            imageFlecheDown.sprite = spriteFlecheUnSelected;
            imageFlecheUp.sprite = spriteFlecheUnSelected;
        } else if (canMoveEpisode && axisInputEpisode != 0)
        {
            canMoveEpisode = false;
            choixEpisode += (int)Mathf.Sign(axisInputEpisode);
            if((int)Mathf.Sign(axisInputEpisode) == 1)
            {
                imageFlecheDown.sprite = spriteFlecheUnSelected;
                imageFlecheUp.sprite = spriteFlecheSelected;
            } else if((int)Mathf.Sign(axisInputEpisode) == -1)
            {
                imageFlecheDown.sprite = spriteFlecheSelected;
                imageFlecheUp.sprite = spriteFlecheUnSelected;
            }
            if(choixEpisode < 0)
            {
                choixEpisode = titresEpisodes.Length - 1;
            } else if(choixEpisode >= titresEpisodes.Length)
            {
                choixEpisode = 0;
            }
            textTitreEpisode.text = titresEpisodes[choixEpisode];
        }

        
    }

    public void ChoixEpisode()
    {
        myEventSystem.SetSelectedGameObject(null);
        FonctionsVariablesGenerales.nbEpisode = choixEpisode + 1;
        StartCoroutine(ChargementGenerique());
    }

    public IEnumerator ChargementGenerique()
    {
        inCharge = true;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Generique");
        operation.allowSceneActivation = false;
        stateInfoMenu = episodeChoiceAnimator.GetCurrentAnimatorStateInfo(0);

        while (stateInfoMenu.normalizedTime < 1.2f)
        {
            stateInfoMenu = episodeChoiceAnimator.GetCurrentAnimatorStateInfo(0);
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        operation.allowSceneActivation = true;
    }
    #endregion



    #region Debug Clic Souris
    public void DebugClicSouris()
    {
        if (myEventSystem.currentSelectedGameObject != null)
        {
            lastBoutonSelected = myEventSystem.currentSelectedGameObject;
        }
        if (mse.wasUpdatedThisFrame)
        {
            myEventSystem.SetSelectedGameObject(lastBoutonSelected);
        }
    }
    #endregion
}
