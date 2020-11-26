using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionEnnemi : MonoBehaviour
{
    public Rigidbody monRB;
    public float speedMunition;
    public float attaque;
    public GameObject particuleExplode;
    public GameObject blendBullet;
    public Transform monParent;

    private void OnEnable()
    {
        monRB.WakeUp();
        monRB.AddForce(this.transform.up * speedMunition);
        StartCoroutine(HideBullet());
    }

    private void OnDisable()
    {
        monRB.Sleep();
        particuleExplode.SetActive(false);
        blendBullet.SetActive(true);
    }


    public IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(2);
        this.transform.parent = monParent;
        gameObject.SetActive(false);
    }

    public IEnumerator ExplodeBullet()
    {
        particuleExplode.SetActive(true);
        blendBullet.SetActive(false);
        this.transform.parent = monParent;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ExplodeBullet());
    }
}
