/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using Photon.Pun;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviourPun, IPunObservable
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
    public static bool keypad14;
    public static bool arrowleft;
    public static bool arrowright;
    public static bool arrowup;
    public static bool arrowdown;
    public static bool buttonX;

    public static int pot1value;
    public static int pot2value;
    public static int pot3value;
    public static int pot4value;
    public static int JoyXvalue;
    public static int JoyYvalue;
    public static bool erdbebenMode;
    public static bool  timercd = false;
    public static string sendtext = "lul";
    public static bool kipp1;
    public static bool kipp2;
    public static bool kipp3;
    public static bool kipp4;
    public static bool module1;
    public static bool module2;
    public static bool module3;
    public static bool module4;

    public SerialController serialController;



    private PhotonView pv;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        Debug.Log("Press A or Z to execute some actions");

        pv = GetComponent<PhotonView>();
    }

    // Executed each frame
    void Update()
    {
        
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Sending P");
        serialController.SendSerialMessage("P1");
        
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("B-C-T-07");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("B-O-34");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
           
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("B-F-0-0");
        }
        
        if (sendtext != "lul")
        {
           Debug.Log(sendtext);
            serialController.SendSerialMessage(sendtext);
            sendtext = "lul";
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Sending T");
            serialController.SendSerialMessage("T-6000");
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

        //Kippschalter
        if( message == "kippschalter1on"){
            kipp1 = true;
            Debug.Log(message);
        }

        if( message == "kippschalter1off"){
            kipp1 = false;
            Debug.Log(message);
        }

        if( message == "kippschalter2on"){
            kipp2 = true;
            Debug.Log(message);
        }

        if( message == "kippschalter2off"){
            kipp2 = false;
            Debug.Log(message);
        }

        if( message == "kippschalter3on"){
            kipp3 = true;
            Debug.Log(message);
        }

        if( message == "kippschalter3off"){
            kipp3 = false;
            Debug.Log(message);
        }

        if( message == "kippschalter4on"){
            kipp4 = true;
            Debug.Log(message);
        }

        if( message == "kippschalter4off"){
            kipp4 = false;
            Debug.Log(message);
        }

        //modulemode

        if(message == "module1on"){
            module1 = true;
            Debug.Log(message);
        }

        if(message == "module1off"){
            module1 = false;
            Debug.Log(message);
        }


        if(message == "module2on"){
            module2 = true;
            Debug.Log(message);
        }

        if(message == "module2off"){
            module2 = false;
            Debug.Log(message);
        }

        if(message == "module3on"){
            module3 = true;
            Debug.Log(message);
        }

        if(message == "module3off"){
            module3 = false;
            Debug.Log(message);
        }

        if(message == "module4on"){
            module4 = true;
            Debug.Log(message);
        }

        if(message == "module4off"){
            module4 = false;
            Debug.Log(message);
        }


        

        //potentiometer

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

        if(message == "beben"){
            erdbebenMode = true;
        }

        // keypad

        if (message == "arrowup"){
            Debug.Log(message);
            arrowup = true;
            
        } 

        if (message == "arrowdown"){
            Debug.Log(message);
            arrowdown = true;
            
        } 

        if (message == "arrowleft"){
            Debug.Log(message);
            arrowleft = true;
            
        } 

        if (message == "arrowright"){
            Debug.Log(message);
            arrowright = true;
            
        }
        if (message == "ButtonX"){
            Debug.Log(message);
            buttonX = true;
            
        }  

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
        if (message == "keypadenter"){

            Debug.Log(message);
            keypad14 = true;
            
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

    [PunRPC]
    void RPC_syncSerialController(bool pkeypad1, bool pkeypad10, bool pkeypad11, bool pkeypad12, bool pkeypad13, bool pkeypad14, bool pkeypad2, bool pkeypad3, bool pkeypad4, bool pkeypad5, bool pkeypad6, bool pkeypad7, bool pkeypad8, bool pkeypad9, bool pencoderright, bool pencoderleft, int ppot1value, int ppot2value, int ppot3value, int ppot4value, int pjoyxvalue, int pjoyyvalue, bool perdbebenmode, bool ptimercd, string psendtext)
    {
        keypad1 = pkeypad1;
        keypad10 = pkeypad10;
        keypad11 = pkeypad11;
        keypad12 = pkeypad12;
        keypad13 = pkeypad13;
        keypad14 = pkeypad14;
        keypad2 = pkeypad2;
        keypad3 = pkeypad3;
        keypad4 = pkeypad4;
        keypad5 = pkeypad5;
        keypad6 = pkeypad6;
        keypad7 = pkeypad7;
        keypad8 = pkeypad8;
        keypad9 = pkeypad9;
        encoderleft = pencoderleft;
        encoderright = pencoderright;
        pot1value = ppot1value;
        pot2value = ppot2value;
        pot3value = ppot3value;
        pot4value = ppot4value;
        JoyXvalue = pjoyxvalue;
        JoyYvalue = pjoyyvalue;
        erdbebenMode = perdbebenmode;
        timercd = ptimercd;
        sendtext = psendtext;
    }
    
}

