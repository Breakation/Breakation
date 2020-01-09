using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PseudoKeyPad : MonoBehaviour
{

    private bool keyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!keyPressed)
        {
            if (Input.GetKey(KeyCode.Keypad0))
            {
                SampleUserPolling_ReadWrite.keypad11 = true;
                keyPressed = true;
            }

            if (Input.GetKey(KeyCode.Keypad1))
            {
                SampleUserPolling_ReadWrite.keypad1 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                SampleUserPolling_ReadWrite.keypad2 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad3))
            {
                SampleUserPolling_ReadWrite.keypad3 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                SampleUserPolling_ReadWrite.keypad4 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
                SampleUserPolling_ReadWrite.keypad5 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                SampleUserPolling_ReadWrite.keypad6 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad7))
            {
                SampleUserPolling_ReadWrite.keypad7 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                SampleUserPolling_ReadWrite.keypad8 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.Keypad9))
            {
                SampleUserPolling_ReadWrite.keypad9 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.KeypadMultiply))
            {
                SampleUserPolling_ReadWrite.keypad10 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.KeypadDivide))
            {
                SampleUserPolling_ReadWrite.keypad12 = true;
                keyPressed = true;
            }
            if (Input.GetKey(KeyCode.KeypadMinus))
            {
                SampleUserPolling_ReadWrite.keypad13 = true;
                keyPressed = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Keypad0) || Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.Keypad7) || Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.Keypad9) || Input.GetKeyUp(KeyCode.KeypadDivide) || Input.GetKeyUp(KeyCode.KeypadMultiply) || Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            keyPressed = false;
        }
    }
}
