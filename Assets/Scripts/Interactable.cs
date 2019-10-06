using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 3.0f;
    private bool interacted = false;
    [SerializeField]
    TMP_Text tmtext;
    [SerializeField]
    Color textColor;

    

    bool isFocused = false;
    protected Transform player;

    public virtual void Start()
    {
        if (tmtext != null)
        {
            tmtext.color = Color.clear;
        }
    }

    public virtual void interact()
    {
        Debug.Log("Interacting with " + transform.name);
        
    }

    public virtual void Update()
    {

        if (isFocused && !interacted)
        {
            float dist = Vector3.Distance(player.position, transform.position);
            if (dist <= pickupRange)
            {
                interact();
                interacted = true;
            }
        }


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }

    public float GetPickupRange()
    {
        return pickupRange;
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        interacted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        interacted = false;
    }

}
