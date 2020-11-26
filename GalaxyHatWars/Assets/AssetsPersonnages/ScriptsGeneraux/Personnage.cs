using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    /*Classe Personnage, à la base de tous les personnages de GalaxyHat Wars*/

    #region Variables

    [HideInInspector] public FonctionsVariablesGenerales scriptGeneralites;

    #region Composants
    [HideInInspector] public Transform monTransform;
    [HideInInspector] public Animator monAnimator;
    [HideInInspector] public AnimatorStateInfo stateInfo;
    [HideInInspector] public AudioSource monAudioSource;
    public Renderer[] mesRenderer;
    #endregion

    #region Statistiques
    public float pvMax;
    [HideInInspector] public float pv;
    public float attaque;
    public float speedMvt;
    public float speedRot;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool isHurt;
    #endregion

    #region Autres GameObjects
    public GameObject eyes;
    public Collider colliderAttaque;
    #endregion

    #region Sons Généraux
    public AudioClip pasSon;
    #endregion

    #endregion



    #region Méthodes
    public void Initialisation(string _NomAnimatorGO)
    {
        scriptGeneralites = GameObject.Find("Main Camera").GetComponent<FonctionsVariablesGenerales>();

        #region Initialisation des Composants
        monTransform = this.transform;
        monAudioSource = this.GetComponent<AudioSource>();
        monAnimator = monTransform.Find(_NomAnimatorGO).GetComponent<Animator>();
        #endregion

        #region Initialisation des Statistiques
        isDead = false;
        pv = pvMax;
        #endregion

    }



    public float PrendreCoup(float _Attaque)
    {
        float pvTemp;
        pvTemp = pv - _Attaque;
        if (pvTemp <= 0)
        {
            pvTemp = 0;
            isDead = true;
        }
        return pvTemp;
    }

    public IEnumerator PrendreCoupClignotte(GameObject _moncollider, float _Attaque,int nbClignottement)
    {
        pv = PrendreCoup(_Attaque);
        if (!isDead)
        {
            int counter = 0;
            while (counter < nbClignottement)
            {
                for (int ii = 0; ii < mesRenderer.Length; ii++)
                {
                    mesRenderer[ii].enabled = false;
                }
                yield return new WaitForSeconds(0.1f);
                for (int ii = 0; ii < mesRenderer.Length; ii++)
                {
                    mesRenderer[ii].enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
                counter++;
            }
        }
        isHurt = false;
    }


    public void Mort()
    {
        monAnimator.SetBool("isDead", true);
    }

    #endregion



}
