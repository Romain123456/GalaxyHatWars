using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : MonoBehaviour
{
    public GameObject interactionZone;
    [HideInInspector] public bool isOpen;
    public GameObject couvercle;
    private Animation coffreAnimation;
    public Transform positionOuverture;
    public string animOuverture;
    public float timeAnim;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        coffreAnimation = couvercle.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchOuverture()
    {
        coffreAnimation.Play();     //L'audio est géré automatiquement dans l'animation
        Destroy(interactionZone);
    }

}
