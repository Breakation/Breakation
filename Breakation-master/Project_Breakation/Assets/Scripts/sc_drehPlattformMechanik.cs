using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_drehPlattformMechanik : MonoBehaviour
{
   
    void Update()
    {
        if (sc_psuedoDrehModul.rightRotation)
        {
            sc_psuedoDrehModul.rightRotation = false;
            transform.Rotate(new Vector3(0f, 2f, 0f));
        }
        if (sc_psuedoDrehModul.leftRotation)
        {
            sc_psuedoDrehModul.leftRotation = false;
            transform.Rotate(new Vector3(0f, -2f, 0f));
        }
    }
}
