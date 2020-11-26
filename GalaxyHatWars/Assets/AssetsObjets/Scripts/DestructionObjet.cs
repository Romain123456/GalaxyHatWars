using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionObjet : MonoBehaviour
{
    public GameObject objetEntier;
    public GameObject objetDestruct;
    public Collider monCollider;
    public Rigidbody monRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("PlayerArme"))
        {
            Destruction();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name != "PlanchePiege")
        {
            Destruction();
        }
    }

    public void Destruction()
    {
        objetEntier.SetActive(false);
        objetDestruct.SetActive(true);
        monCollider.enabled = false;
        monRb.Sleep();
    }

}
