using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoKlasse : ScriptableObject
{
    private int x = 0, y = 0;
    private LightsOutManager GMInstance = LightsOutManager.Instance; // verwaltet den Rätsel
    private bool right, left, up, down, select;
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
            right = true;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            left = true;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)))
        {
            up = true;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow)))
        {
            down = true;
        }

        if (right)
        {
            if (y < 7)
            {
                y++;
                position.Remove(5);
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            right = false;
        }
        if (left)
        {
            if (y > 0)
            {
                y--;
                position.Remove(5);
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            left = false;
        }
        if (up)
        {
            if (x < 7)
            {
                x++;
                position.Remove(4);
                position += x;
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            up = false;
        }
        if (down)
        {
            if (x > 0)
            {
                x--;
                position.Remove(4);
                position += x;
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            down = false;
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
