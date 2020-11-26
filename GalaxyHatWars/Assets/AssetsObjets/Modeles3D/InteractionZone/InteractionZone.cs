using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionZone : MonoBehaviour
{
    public GameObject canvasInteraction;
    public GameObject imageBoutonVide;
    public GameObject imageBoutonAction;

    private Image imageBoutonVideImage;
    private Image imageBoutonActionImage;

    public Sprite spriteVideManette;
    public Sprite spriteVideClavier;
    public Sprite spriteManetteAction;
    public Sprite spriteClavierAction;

    private DrBob scriptDrBob;
    public string tagParent;

    private void Awake()
    {
        canvasInteraction.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        scriptDrBob = GameObject.Find("DrBob").GetComponent<DrBob>();
        imageBoutonVideImage = imageBoutonVide.GetComponent<Image>();
        imageBoutonActionImage = imageBoutonAction.GetComponent<Image>();
        tagParent = transform.parent.tag;
    }

    private void OnEnable()
    {

    }

    private void Update()
    {
        SwitchSpriteControl();
    }

    private void SwitchSpriteControl()
    {
        if(scriptDrBob.deviceUsed == scriptDrBob.deviceKeyboardMouse && imageBoutonVideImage.sprite == spriteVideManette)
        {
            imageBoutonVideImage.sprite = spriteVideClavier;
            imageBoutonActionImage.sprite = spriteClavierAction;
        } else if(scriptDrBob.deviceUsed == scriptDrBob.deviceGamepad && imageBoutonVideImage.sprite == spriteVideClavier)
        {
            imageBoutonVideImage.sprite = spriteVideManette;
            imageBoutonActionImage.sprite = spriteManetteAction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imageBoutonAction.SetActive(true);
            scriptDrBob.isInInteraction = true;
            scriptDrBob.tagInterractionObject = tagParent;
            scriptDrBob.transformZoneInteract = this.transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imageBoutonAction.SetActive(false);
            scriptDrBob.isInInteraction = false;
            scriptDrBob.isActionInteraction = false;
            scriptDrBob.tagInterractionObject = "";
        }
    }
}
