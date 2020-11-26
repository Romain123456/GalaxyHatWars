using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FonctionsVariablesGenerales : MonoBehaviour
{
    static public float deltaTime;
    static public bool isPause;
    static public string langage;       //french / english / ...
    static public int nbEpisode;

    [HideInInspector] public GameObject maCamera;
    public Image noirImage;

    #region Interface
    public GameObject _PanelInterfaceJoueur;
    public GameObject _PanelVie;
    public GameObject _CoeurImagePrefab;
    [HideInInspector] public Image[] _VieImages;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        if (noirImage != null)
        {
            StartCoroutine(FadeMoinsNoirImage(2));
        }
        maCamera = GameObject.Find("Main Camera").gameObject;

        #region Interface Vie
        if (_PanelInterfaceJoueur != null)
        {
            _VieImages = new Image[3];
            for (int ii = 0; ii < 3; ii++)
            {
                GameObject monImage = Instantiate(_CoeurImagePrefab, _PanelVie.transform);
                monImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-45 + ii * 70, 0);
                _VieImages[ii] = monImage.transform.GetChild(0).GetComponent<Image>();
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = Time.deltaTime;
    }



    #region FadeNoirImage
    public IEnumerator FadeMoinsNoirImage(float speedFade)
    {
        float alpha = noirImage.color.a;

        while (alpha > 0)
        {
            alpha -= deltaTime * speedFade;
            noirImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(deltaTime);
        }
    }

    public IEnumerator FadePlusNoirImage(float speedFade)
    {
        float alpha = noirImage.color.a;

        while (alpha < 1)
        {
            alpha += deltaTime * speedFade;
            noirImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(deltaTime);
        }
    }
    #endregion

    #region ShakeCamera
    public IEnumerator ShakeCamera(float _ShakeDuration, float _ShakeAmount, float _DecreaseFactor)
    {
        Vector3 originalPosCam;                                     //Position d'origine de la Camera

        float shakeDuration = _ShakeDuration;
        originalPosCam = maCamera.transform.position;
        while (shakeDuration > 0)
        {
            //Tremblement de la caméra. L'amplitude du tremblement dépend des pv du Bobulator
            if (!isPause)
            {
                maCamera.transform.position = maCamera.transform.position + Random.insideUnitSphere * _ShakeAmount;
                shakeDuration -= _DecreaseFactor;
                yield return new WaitForSeconds(deltaTime);
            }
        }

    }
    #endregion


    
}
