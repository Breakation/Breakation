using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string input, currentPassword = "123";
    public bool onTrigger, doorOpen, keypadScreen;
    public Transform doorHinge;

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    private void Update()
    {
        if(input == currentPassword)
        {
            doorOpen = true;

        }
        if (doorOpen)
        {
            doorHinge.rotation = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
        }
    }
    private void OnGUI()
    {
        if (!doorOpen)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press E to open Keypad!");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    onTrigger = false;
                }
            }

            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input); //tempInput

                generateScreenOutput(5, 35, "1");
                generateScreenOutput(110, 35, "2");
                generateScreenOutput(215, 35, "3");
                generateScreenOutput(5, 140, "4");
                generateScreenOutput(110, 140, "5");
                generateScreenOutput(215, 140, "6");
                generateScreenOutput(5, 245, "7");
                generateScreenOutput(110, 245, "8");
                generateScreenOutput(215, 245, "9");
                generateScreenOutput(110, 350, "0");
            }
        }

    }

    void generateScreenOutput(int x, int y, string i)
    {
        if (GUI.Button(new Rect(x, y, 100, 100), i))
        {
            input += i;
        }
    }

}
