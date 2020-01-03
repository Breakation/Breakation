using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoInput : ScriptableObject
{
    private int row, column;

    public ArduinoInput(int row, int column) // row: joystick, column Knopf
    {
        this.row = row;
        this.column = column;
    }

    public int getRow()
    {
        return 1;//this.row;
    }
    public int getColumn()
    {
        return 1;//this.column;
    }
}
