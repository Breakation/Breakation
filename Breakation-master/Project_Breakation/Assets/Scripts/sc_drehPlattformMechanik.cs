using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_drehPlattformMechanik : MonoBehaviour
{
   
    void Update()
    {
        if (SampleUserPolling_ReadWrite.encoderright)
        {
            SampleUserPolling_ReadWrite.encoderright = false;
            transform.Rotate(new Vector3(0f, 20f, 0f));
        }
        if (SampleUserPolling_ReadWrite.encoderleft)
        {
            SampleUserPolling_ReadWrite.encoderleft = false;
            transform.Rotate(new Vector3(0f, -20f, 0f));
        }
        if (sc_psuedoDrehModul.leftRotation)
        {
            transform.Rotate(new Vector3(0, -5, 0));
            sc_psuedoDrehModul.leftRotation = false;
        }
        if (sc_psuedoDrehModul.rightRotation)
        {
            transform.Rotate(new Vector3(0, 5, 0));
            sc_psuedoDrehModul.rightRotation = false;
        }
    }
}
