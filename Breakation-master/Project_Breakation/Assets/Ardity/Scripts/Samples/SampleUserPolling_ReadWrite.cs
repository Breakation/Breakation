/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public static bool encoderleft;
    public static bool encoderright;

    //keypad

    public static bool keypad1;
    public static bool keypad2;
    public static bool keypad3;
    public static bool keypad4;
    public static bool keypad5;
    public static bool keypad6;
    public static bool keypad7;
    public static bool keypad8;
    public static bool keypad9;
    public static bool keypad10;
    public static bool keypad11;
    public static bool keypad12;
    public static bool keypad13;
    public static int pot1value;
    public static int pot2value;
    public static int pot3value;
    public static int pot4value;
    public static int JoyXvalue;
    public static int JoyYvalue;

    public SerialController serialController;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        Debug.Log("Press A or Z to execute some actions");
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sending A");
            serialController.SendSerialMessage("A");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("Z");
        }


        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        string message = serialController.ReadSerialMessage();
        //encoder
        if (message == "encoderleft"){
            encoderleft = true;
            Debug.Log(message);
            
            // wenn benutzt nach if abfrage wieder auf false setzen
        }
        if ( message == "encoderright"){
            encoderright = true;
            Debug.Log(message);
            
        }

        if((message != null) && (message.Contains("pot1"))){
            string[] numbers = message.Split(',');
            pot1value = int.Parse(numbers[1]);
            Debug.Log(pot1value);
        }

        if((message != null) && (message.Contains("pot2"))){
            string[] numbers = message.Split(',');
            pot2value = int.Parse(numbers[1]);
            Debug.Log(pot2value);
        }

        if((message != null) && (message.Contains("pot3"))){
            string[] numbers = message.Split(',');
            pot3value = int.Parse(numbers[1]);
            Debug.Log(pot3value);
        }

        if((message != null) && (message.Contains("pot4"))){
            string[] numbers = message.Split(',');
            pot4value = int.Parse(numbers[1]);
            Debug.Log(pot4value);
        }

        //Joystick

        if((message != null) && (message.Contains("JoyX"))){
            string[] numbers = message.Split(',');
            JoyXvalue = int.Parse(numbers[1]);
            Debug.Log(JoyXvalue);
        }

        if((message != null) && (message.Contains("JoyY"))){
            string[] numbers = message.Split(',');
            JoyYvalue = int.Parse(numbers[1]);
            Debug.Log(JoyYvalue);
        }



        // keypad

        if (message == "keypad1"){
            Debug.Log(message);
            keypad1 = true;
        } 
        if (message == "keypad2"){
            Debug.Log(message);
            keypad2 = true;
        } 
        if (message == "keypad3"){
            Debug.Log(message);
            keypad3 = true;
        } 
        if (message == "keypad4"){
            Debug.Log(message);
            keypad4 = true;
        } 
        if (message == "keypad5"){
            Debug.Log(message);
            keypad5 = true;
        } 
        if (message == "keypad6"){
            Debug.Log(message);
            keypad6 = true;
        } 
        if (message == "keypad7"){
            Debug.Log(message);
            keypad7 = true;
        } 
        if (message == "keypad8"){
            Debug.Log(message);
            keypad8 = true;
        } 
        if (message == "keypad9"){
            Debug.Log(message);
            keypad9 = true;
        } 
        if (message == "keypad*"){
            Debug.Log(message);
            keypad10 = true;
        } 
        if (message == "keypad0"){
            Debug.Log(message);
            keypad11 = true;
        } 
        if (message == "keypad#"){
            Debug.Log(message);
            keypad12 = true;
        } 
        if (message == "keypadbackspace"){
            Debug.Log(message);
            keypad13 = true;
        } 
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);
    }
}
