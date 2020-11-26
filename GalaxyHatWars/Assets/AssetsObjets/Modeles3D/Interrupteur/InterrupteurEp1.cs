using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurEp1 : MonoBehaviour
{
    public bool isActivated;
    public bool isCouvert;

    public bool needToCover;

    public float posZ_End;

    public BoxCollider triggerInterrupteur;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated && needToCover && !isCouvert)
        {
            StartCoroutine(RemonteeInterrupteur(0.0005f));
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            StartCoroutine(DescenteInterrupteur(0.0005f));
        }
    }


    IEnumerator DescenteInterrupteur (float speedDescente)
    {
        triggerInterrupteur.enabled = false;
        yield return new WaitForSeconds(0.5f);
        while (this.transform.localPosition.z > posZ_End)
        {
            float posZ = this.transform.localPosition.z;
            posZ -= speedDescente;
            this.transform.localPosition = new Vector3(0, 0, posZ);
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        this.transform.localPosition = new Vector3(0, 0, posZ_End);
        isActivated = true;
        triggerInterrupteur.enabled = true;
    }

    IEnumerator RemonteeInterrupteur(float speedRemonte)
    {
        isActivated = false;
        yield return new WaitForSeconds(2f);
        triggerInterrupteur.enabled = false;
        while (this.transform.localPosition.z < 0)
        {
            float posZ = this.transform.localPosition.z;
            posZ += speedRemonte;
            this.transform.localPosition = new Vector3(0, 0, posZ);
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
        this.transform.localPosition = new Vector3(0, 0, 0);
        triggerInterrupteur.enabled = true;
    }

}
