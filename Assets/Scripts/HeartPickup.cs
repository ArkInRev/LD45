using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : AutoPickup
{
    [SerializeField]
    private float healAmount = 20;

     public override void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.name + " Tag: " + other.tag);
        if (other.CompareTag("Player"))
        {

            Instantiate(collectPS, transform.position, Quaternion.identity);

            // Add Health
            other.GetComponent<hp>().healDamage(healAmount);

            Destroy(gameObject);
        }
    }
}
