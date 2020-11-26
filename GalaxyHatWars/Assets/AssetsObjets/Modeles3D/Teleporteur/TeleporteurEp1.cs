using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleporteurEp1 : MonoBehaviour
{
    public string actualPiece;
    public string linkedPiece;
    [HideInInspector] public Transform arrivee;

    // Start is called before the first frame update
    void Start()
    {
        arrivee = this.transform.Find("Arrivee");
        this.transform.name = this.transform.name + "_" + actualPiece + "_" + linkedPiece;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportationCoroutine(other.gameObject));
        }
    }


    public IEnumerator TeleportationCoroutine(GameObject _monGO)
    {
        Image noirImage = GameObject.Find("Main Camera").GetComponent<FonctionsVariablesGenerales>().noirImage;
        StartCoroutine(GameObject.Find("Main Camera").GetComponent<FonctionsVariablesGenerales>().FadePlusNoirImage(2));
        while(noirImage.color.a < 1)
        {
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }

        for(int ii=0;ii< this.transform.parent.parent.childCount; ii++)
        {
            if(this.transform.parent.parent.GetChild(ii).name == linkedPiece)
            {
                this.transform.parent.parent.GetChild(ii).gameObject.SetActive(true);
                //this.transform.parent.gameObject.SetActive(false);
            }
        }

        Transform newPiece = GameObject.Find(linkedPiece).transform;
        DrBob_Ep1 drbob_script = _monGO.GetComponent<DrBob_Ep1>();
        drbob_script.DrBob_StopMove();
        drbob_script.enabled = false;

        drbob_script.actualPiece = linkedPiece;
        drbob_script.CameraInitialisationSalle_Episode1();


        _monGO.transform.position = newPiece.Find("Teleporteur_" + linkedPiece + "_" + actualPiece).GetComponent<TeleporteurEp1>().arrivee.position;
        _monGO.transform.rotation = newPiece.Find("Teleporteur_" + linkedPiece + "_" + actualPiece).GetComponent<TeleporteurEp1>().arrivee.rotation;


        yield return new WaitForSeconds(1);
        StartCoroutine(GameObject.Find("Main Camera").GetComponent<FonctionsVariablesGenerales>().FadeMoinsNoirImage(2));
        while (noirImage.color.a > 0)
        {
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        drbob_script.enabled = true;

    }

}
