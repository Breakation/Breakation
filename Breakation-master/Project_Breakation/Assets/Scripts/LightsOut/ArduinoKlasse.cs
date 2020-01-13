using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoKlasse : MonoBehaviour
{
    private int x = 0, y = 0;
    private LightsOutManager GMInstance = LightsOutManager.Instance; // verwaltet den Rätsel
    private bool ArrowRight, ArrowLeft, ArrowUp, ArrowDown, select;
    private string position = "B-O-xy";
   
    // Update is called once per frame
    void Update()
    {
        this.navigation();
    }

    public void navigation()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow)))
        {
            ArrowRight = true;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            ArrowLeft = true;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)))
        {
            ArrowUp = true;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow)))
        {
            ArrowDown = true;
        }

        if (ArrowRight)
        {
            if (y < 7)
            {
                y++;
                position.Remove(5);
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            ArrowRight = false;
        }
        if (ArrowLeft)
        {
            if (y > 0)
            {
                y--;
                position.Remove(5);
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            ArrowLeft = false;
        }
        if (ArrowUp)
        {
            if (x < 7)
            {
                x++;
                position.Remove(4);
                position += x;
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            ArrowUp = false;
        }
        if (ArrowDown)
        {
            if (x > 0)
            {
                x--;
                position.Remove(4);
                position += x;
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            ArrowDown = false;
        }

        if ((Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            select = true;
        }
        if (select)
        {
            GMInstance.ArrayOfCells[7-x, 7-y].cellController.AffectCells();
            select = false;
        }
    }
    
}
