using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableSwitch : Interactable
{
    public HazardControlled[] ControlledObjects;
    public bool isPowered;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private TMP_Text interactText;
    [SerializeField]
    private string strPowered;
    [SerializeField]
    private string strUnpowered;

    public override void interact()
    {
        for(int i = 0; i < ControlledObjects.Length; i++)
        {
            ControlledObjects[i].isActive = !ControlledObjects[i].isActive;
        }
        isPowered = !isPowered;


    }

    public override void Update()
    {
        base.Update();

        if (isPowered)
        {
            SetPowered();
        }
        else
        {
            ResetPowered();
        }
    }

    public virtual void SetPowered()
    {
        //Debug.Log("Trap Powered");
        anim.SetTrigger("Powered");
        anim.ResetTrigger("Idle");
        interactText.text = strPowered;
        
    }

    public virtual void ResetPowered()
    {
        //Debug.Log("Trap Reset");
        anim.ResetTrigger("Powered");
        anim.SetTrigger("Idle");
        interactText.text = strUnpowered;
       
    }
}
