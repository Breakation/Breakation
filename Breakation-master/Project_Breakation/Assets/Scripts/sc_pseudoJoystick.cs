using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_pseudoJoystick : MonoBehaviour
{

    public static int xAxis;
    public static int zAxis;



    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            xAxis = 1000 ;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xAxis = 0;
        }
        else
        {
            xAxis = 500;
        }


        if (Input.GetKey(KeyCode.W))
        {
            zAxis = 1000;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zAxis = 0;
        }
        else
        {
            zAxis = 500;
        }

        
    }
}
