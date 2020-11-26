using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool isClosed;
    public AudioClip sonClose;
    public AudioClip sonOpen;
    [HideInInspector] public AudioSource porteAudio;
    [HideInInspector] public bool isOpen;
    public float speedOuvre;
    public bool isReverseSens;

    // Start is called before the first frame update
    void Start()
    {
        porteAudio = this.GetComponent<AudioSource>();
    }



    public IEnumerator OuverturePorte(float _SpeedOuvre)
    {
        float rotZ = this.transform.localRotation.eulerAngles.z;
        int sensRot = 1;
        if (isReverseSens)
        {
            sensRot = -1;
            rotZ -= 360;
        }
        porteAudio.PlayOneShot(sonOpen);

        while(Mathf.Abs(rotZ) < 100)
        {
            rotZ += _SpeedOuvre*sensRot;
            this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
            yield return new WaitForSeconds(FonctionsVariablesGenerales.deltaTime);
        }
    }


    public void PorteRaZ()
    {
        isOpen = false;
        this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
