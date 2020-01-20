using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_drehPlattformMechanik : MonoBehaviour
{
    public GameObject[] drehPlatformen;
    void Update()
    {
        if (SampleUserPolling_ReadWrite.encoderright)
        {
            SampleUserPolling_ReadWrite.encoderright = false;
             for (int i = 0; i < drehPlatformen.Length; i++)
            {
                drehPlatformen[i].transform.Rotate(new Vector3(0, 5, 0));
            }
        }
        if (SampleUserPolling_ReadWrite.encoderleft)
        {
            SampleUserPolling_ReadWrite.encoderleft = false;
            for (int i = 0; i < drehPlatformen.Length; i++)
            {
                drehPlatformen[i].transform.Rotate(new Vector3(0, -5, 0));
            }
        }
        /*if (sc_psuedoDrehModul.leftRotation)
        {
            for (int i = 0; i < drehPlatformen.Length; i++)
            {
                drehPlatformen[i].transform.Rotate(new Vector3(0, -5, 0));
            }
            sc_psuedoDrehModul.leftRotation = false;
        }
        if (sc_psuedoDrehModul.rightRotation)
        {
            for (int i = 0; i < drehPlatformen.Length; i++)
            {
                drehPlatformen[i].transform.Rotate(new Vector3(0, 5, 0));
            }
            sc_psuedoDrehModul.rightRotation = false;
        } */


    }
}
