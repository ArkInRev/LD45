﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : hp
{
    public GameObject destroyedVersion;

    public override void objectDeath()
    {
        Instantiate(destroyedVersion, transform.position, Quaternion.identity);
        Debug.Log("This INHERITED object ran out of health from hp component: " + transform.name);

        if (spiritLoot())
        {
            Instantiate(GetSpiritPrefab(), transform.position, Quaternion.identity);
        }
        if (heartLoot())
        {
            Instantiate(GetHeartPrefab(), transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
