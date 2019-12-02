using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; 

//there can be many types of Items: weapons, consumables, keys etc...
[CreateAssetMenu (fileName ="new sc_Consumable", menuName = "Items/Consumable")]

// !!!! : this instance only refers to the slot and not to the item itself! Dafür gibt es das Script sc_pickUp
public class Consumable : sc_item //this object will inherit from Item
{

    //Consumable can do anything an Item can do, and has all of its properties; name, icon and the Use() method
    public int valueOfItem = 0; //Not every Consumable will heal the player, so the default value will be 0

    public override void Use()//This override function will replace the Use() method of the Item class.
    {
        //ask the inventory instance for the player
        //GameObject player = Inventory.instance.player;

        //do what is supposed to do

        //After the player is healed use the static Inventory instance to remove the consumable
        //Inventory.instance.Remove(this); // the item will remove itself form the list when you use it
    }

}
