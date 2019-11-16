using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is for:
 *  - keeping track of the score
 *  - respawning the player after dying
     */
public class GameManager : MonoBehaviour
{

    public int currentItem; // keep track of the number of picked up items
    public Text ItemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(int itemToAdd)//to add picked up item to the list
    {
        currentItem += itemToAdd;
        ItemText.text = "Points: " + currentItem;
    }
}
