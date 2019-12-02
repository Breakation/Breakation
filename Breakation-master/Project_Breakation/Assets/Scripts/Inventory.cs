using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    public List<sc_item> list = new List<sc_item>();
    public GameObject player;
    public GameObject inventoryPanel;

    public static Inventory instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
        updatePanelSlots(); //When the game starts we update the panel slot's displayName and icon
    }

    // to populate all of the InventoryPanel's Slots with the items in our list
    public void updatePanelSlots()
    {
        int i = 0; //index to count which slot number we are on during the loop 
        //Each child of the panel corresponds with one of the slots.
        foreach (Transform child in inventoryPanel.transform)// child sind also die Objekte Slot, Slot1, Slot2 etc...
        {
            //update slot[i]'s name and icon to the name and icon of the corresponding Item by calling slot[i]'s updateInfo() method
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if(i < list.Count) //If the list contains an item at this index
            {
                slot.item = list[i]; //set the Slot's item to the item at list[index]:
            }
            else
            {
                slot.item = null;  //if list[index] does not contain an item we need to set the Slot's item to null
            }
            slot.updateInfo();
            i++;
        }
    }

    public void Add(sc_item item)
    {
        if(list.Count < 4) //Momentan nur vier slots sind angezeigt
        {
            list.Add(item);
        }
        updatePanelSlots();
    }

    public void Remove(sc_item item)
    {
        list.Remove(item);
        updatePanelSlots();
    }

}
