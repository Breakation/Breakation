using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class sc_InventorySlotController : MonoBehaviour
{ //This Script will store the item corresponding to the Slot it is attached to.


    public sc_item item;

    // Use this for initialization
    void Start()
    {
        updateInfo(); //rufen der Methode beim Anfang
    }

    /*
     *
    we'll get the Text component by looking for a Text type component in its children
    and the Image component by finding a child named "Image" and using its Image component
     */
    public void updateInfo()
    {
        //eine Textreferenz des Canvas-Kindes speichern
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image displayImage = transform.Find("Image").GetComponent<Image>(); //find sucht in der Objekthierarchie und getComponent im Objekt selber


        if (item)//Wenn der Slot einen Item hat, dann  könnten display name and image geupdated werden...
        {
            displayText.text = item.itemName;
            displayImage.sprite = item.icon;
            displayImage.color = Color.white;//makes it colourless
        }
        else// wenn der Slot leer ist (hat keinen Item)
        {
            displayText.text = "";
            displayImage.sprite = null;
            displayImage.color = Color.clear;//makes it colourless
        }
    }

    public void Use()
    {
        if (item)//Only if there is an item of course
        {
            //for testing purposes:
            Debug.Log("You clicked : " + item.itemName);
            //actaul call:
            item.Use();
        }
    }
}
