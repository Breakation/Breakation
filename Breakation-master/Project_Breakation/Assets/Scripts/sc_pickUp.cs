using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *this script will tell the Gamemanager how many  Items (aka Gold bars for the demo) the player has picked
 */
public class sc_pickUp : MonoBehaviour
{
    public sc_item item;
    public int valueOfItem;
    public GameObject pickUpEffekt; //Particle effekt hier einfügen!!

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")//Spieler ist mit diesem Tag getaggt
        {
            FindObjectOfType<GameManager>().addItem(valueOfItem);//find object that has the gamemanager script attached to it

            //Instantiate creates a copy of whatever object we give its refrence to; here the pickUp object
            Instantiate(pickUpEffekt, transform.position, transform.rotation); //the position and rotation are those of the pickup object attached to the script
            sc_Inventory.instance.Add(item);
            Destroy(gameObject);
        }
    }
}
