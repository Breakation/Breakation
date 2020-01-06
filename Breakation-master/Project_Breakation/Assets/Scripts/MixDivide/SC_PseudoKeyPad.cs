using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PseudoKeyPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad0))
        {
            SampleUserPolling_ReadWrite.keypad11 = true;
        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            SampleUserPolling_ReadWrite.keypad1 = true;
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            SampleUserPolling_ReadWrite.keypad2 = true;
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            SampleUserPolling_ReadWrite.keypad3 = true;
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            SampleUserPolling_ReadWrite.keypad4 = true;
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            SampleUserPolling_ReadWrite.keypad5 = true;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            SampleUserPolling_ReadWrite.keypad6 = true;
        }
        if (Input.GetKey(KeyCode.Keypad7))
        {
            SampleUserPolling_ReadWrite.keypad7 = true;
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            SampleUserPolling_ReadWrite.keypad8 = true;
        }
        if (Input.GetKey(KeyCode.Keypad9))
        {
            SampleUserPolling_ReadWrite.keypad9 = true;
        }
        if (Input.GetKey(KeyCode.KeypadMultiply))
        {
            SampleUserPolling_ReadWrite.keypad10 = true;
        }
        if (Input.GetKey(KeyCode.KeypadDivide))
        {
            SampleUserPolling_ReadWrite.keypad12 = true;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            SampleUserPolling_ReadWrite.keypad13 = true;
        }
    }
}
