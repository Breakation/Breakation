using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testkeypad : MonoBehaviour
{
    // Start is called before the first frame update
    public static string teststring ="";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SampleUserPolling_ReadWrite.keypad1 == true)
        {
            teststring = teststring + "1";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad1 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad2 == true)
        {
            teststring = teststring + "2";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad2 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad3 == true)
        {
            teststring = teststring + "3";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad3 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad4 == true)
        {
            teststring = teststring + "4";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad4 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad5 == true)
        {
            teststring = teststring + "5";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad5 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad6 == true)
        {
            teststring = teststring + "6";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad6 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad7 == true)
        {
            teststring = teststring + "7";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad7 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad8 == true)
        {
            teststring = teststring + "8";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad8 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad9 == true)
        {
            teststring = teststring + "9";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad9 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad10 == true)
        {
            teststring = teststring + "*";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad10 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad11 == true)
        {
            teststring = teststring + "0";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad11 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad12 == true)
        {
            teststring = teststring + "#";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad12 = false;
        }
        if (SampleUserPolling_ReadWrite.keypad13 == true)
        {
            teststring = teststring.Remove(teststring.Length - 1);
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad13 = false;
        }

    }
}
