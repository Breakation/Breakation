using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoKlasse : MonoBehaviour
{
    private int x = 0, y = 0;
    private LightsOutManager GMInstance = LightsOutManager.Instance; // verwaltet den Rätsel
    private bool ArrowRight, ArrowLeft, ArrowUp, ArrowDown, select;
    private string position = "B-O-00";
   
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

        if (SampleUserPolling_ReadWrite.arrowright)
        {
            if (y < 7)
            {
                y++;
                position = position.Remove(5);
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            SampleUserPolling_ReadWrite.arrowright = false;
        }
        if (SampleUserPolling_ReadWrite.arrowleft)
        {
            if (y > 0)
            {
                y--;
                position = position.Remove(5);
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            SampleUserPolling_ReadWrite.arrowleft = false;
        }
        if (SampleUserPolling_ReadWrite.arrowup)
        {
            if (x < 7)
            {
                x++;
                position = position.Remove(4);
                position += x;
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            SampleUserPolling_ReadWrite.arrowup = false;
        }
        if (SampleUserPolling_ReadWrite.arrowdown)
        {
            if (x > 0)
            {
                x--;
                position = position.Remove(4);
                position += x;
                position += y;
                SampleUserPolling_ReadWrite.sendtext = position;
            }
            SampleUserPolling_ReadWrite.arrowdown = false;
        }

        if ((Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            select = true;
        }
        if (SampleUserPolling_ReadWrite.buttonX)
        {
            GMInstance.ArrayOfCells[7-x, 7-y].AffectCells();
            SampleUserPolling_ReadWrite.buttonX = false;
        }
    }
    
}
