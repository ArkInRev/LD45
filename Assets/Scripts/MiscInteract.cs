using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscInteract : Interactable
{
    [SerializeField]
    private GameObject newMiscPrefab;


    public override void interact()
    {

        Debug.Log("Interacting and instantiating with " + transform.name);
        // instantiate a new weapon with the player as a parent. 
        GameObject newMisc = Instantiate(newMiscPrefab, player);
//        newSword = newWeapon.GetComponent<Sword>();
//        player.GetComponent<ClickToMove>().equipped = newSword;
        Destroy(gameObject);
    }


}
