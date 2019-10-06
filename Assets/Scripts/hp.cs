using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float curHealth;
    
    [SerializeField]
    private float chanceToDropSpirit = .75f;
    [SerializeField]
    GameObject spiritPrefab;

    public virtual void Awake()
    {
        curHealth = maxHealth;
    }

    private float getHealth()
    {
        return curHealth;
    }

    public float getHealthPercent()
    {
        return curHealth/maxHealth;
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

    protected bool spiritLoot()
    {
        bool loot = false;
        float lootcheck = Random.value;
        if (lootcheck <= chanceToDropSpirit) loot = true;


        return loot;
    }

    protected GameObject GetSpiritPrefab()
    {
        return spiritPrefab;
    }

}
