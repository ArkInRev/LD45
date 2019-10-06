using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : hp
{
    public GameObject destroyedVersion;
    public override void objectDeath()
    {
        //Instantiate(destroyedVersion, transform.position, Quaternion.identity);
        //Debug.Log("This INHERITED object ran out of health from hp component: " + transform.name);
        //Destroy(gameObject);
    }

    
}
