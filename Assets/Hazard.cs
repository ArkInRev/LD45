using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    [SerializeField]
    private float dmgPerSecond = 2f;
    [SerializeField]
    private ParticleSystem enemyHitPS;
    [SerializeField]
    private ParticleSystem objectHitPS;

    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy was hit with the sword. ");
            Instantiate(objectHitPS, other.ClosestPoint(transform.position), Quaternion.identity);

        }
        else if (other.CompareTag("Player"))
        {
            Instantiate(objectHitPS, other.ClosestPoint(transform.position), Quaternion.identity);

        }
        damageObject(dmgPerSecond*Time.deltaTime, other);
    }

    private void damageObject(float dmg, Collider other)
    {
        hp otherHP = other.GetComponent<hp>();

        if (otherHP != null)
        {
            otherHP.takeDamage(dmg);
        }
    }
}
