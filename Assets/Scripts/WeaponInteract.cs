using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteract : Interactable
{
    private GameObject oldWeaponInteractablePrefab;
    [SerializeField]
    private GameObject newWeaponPrefab;
    private Sword newSword;

    public override void interact()
    {
        if (oldWeaponInteractablePrefab != null)
        {
            //instantiate the old weapon at the player's current position
        }

        Debug.Log("Interacting and instantiating with " + transform.name);
        // instantiate a new weapon with the player as a parent. 
        GameObject newWeapon =Instantiate(newWeaponPrefab, player);
        newSword = newWeapon.GetComponent<Sword>();
        player.GetComponent<ClickToMove>().equipped = newSword;
        Destroy(gameObject);
    }


}
