using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireLevierScript : MonoBehaviour
{
    [HideInInspector] public Vector3 position0;
    public float extensionLevier;
    [HideInInspector] public bool isTire;
    public float speedRetour;


    // Start is called before the first frame update
    void Start()
    {
        position0 = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTire && this.transform.position != position0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, position0, speedRetour * FonctionsVariablesGenerales.deltaTime);
            if(Vector3.Magnitude(this.transform.position-position0) < 0.1f)
            {
                this.transform.position = position0;
            }
        }
    }
}
