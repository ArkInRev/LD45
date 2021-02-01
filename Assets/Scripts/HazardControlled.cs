using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardControlled : Hazard
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Collider col;
    [SerializeField]
    private bool isTimed;
    [SerializeField]
    private float interval;
    private float timeSinceLastActivate;

    public bool isPowered = false;
    public bool isActive = false;

    public float timeOffset = 0f;
    [SerializeField]


    public void Awake()
    {
        timeSinceLastActivate = timeOffset; // this delays the start of a hazard to make timing traps. 
    }

    public void Update()
    {

            if (isTimed)
            {
                if (timeSinceLastActivate <= 0)
                {
                    isPowered = !isPowered;
                    timeSinceLastActivate = interval;
                }
                timeSinceLastActivate -= Time.deltaTime;
            }


            if (isPowered && isActive)
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
    }

    public virtual void ResetPowered()
    {
        //Debug.Log("Trap Reset");
        anim.ResetTrigger("Powered");
        anim.SetTrigger("Idle");
    }

}
