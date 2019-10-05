using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float curHealth;

    public virtual void Awake()
    {
        curHealth = maxHealth;
    }

    private float getHealth()
    {
        return curHealth;
    }

    public void takeDamage(float dmg)
    {
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            curHealth = 0;
            objectDeath();
            
        }
        Debug.Log("Damaged health down to: " + curHealth + " on " + transform.name);
    }

    public void healDamage(float heal)
    {
        curHealth += heal;
        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
        Debug.Log("Healed health up to: " + curHealth + " on " + transform.name);
    }

    public virtual void objectDeath()
    {
        Debug.Log("This object ran out of health: " + transform.name);
    }


}
