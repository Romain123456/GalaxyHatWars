using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaillassonRaZObjects : MonoBehaviour
{
    public List<Transform> objectMoving = new List<Transform>();
    public List<Vector3> objectMovingPos0 = new List<Vector3>();
    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        for(int ii = 0; ii < transform.parent.childCount; ii++)
        {
            if (transform.parent.GetChild(ii).CompareTag("PousseObject"))
            {
                objectMoving.Add(transform.parent.GetChild(ii));
                objectMovingPos0.Add(transform.parent.GetChild(ii).position);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DrBob>().isOnTriggerSpecial = true;
            if(other.GetComponent<DrBob>().actionTriggerSpecial && !isActivated)
            {
                isActivated = true;
                for(int ii = 0; ii < objectMoving.Count; ii++)
                {
                    objectMoving[ii].position = objectMovingPos0[ii];
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DrBob>().isOnTriggerSpecial = false;
            isActivated = false;
        }
    }
}
