using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class testkeypad : MonoBehaviourPun, IPunObservable
{
    // Start is called before the first frame update
    public static string teststring ="";
    public static string sendkeypad= "";

    public static bool textChanged = false;

    private PhotonView pv;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SampleUserPolling_ReadWrite.keypad1 == true)
        {
            
            teststring = teststring + "1";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad1 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad2 == true)
        {
            teststring = teststring + "2";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad2 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad3 == true)
        {
            teststring = teststring + "3";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad3 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad4 == true)
        {
            teststring = teststring + "4";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad4 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad5 == true)
        {
            teststring = teststring + "5";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad5 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad6 == true)
        {
            teststring = teststring + "6";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad6 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad7 == true)
        {
            teststring = teststring + "7";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad7 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad8 == true)
        {
            teststring = teststring + "8";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad8 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad9 == true)
        {
            teststring = teststring + "9";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad9 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad10 == true)
        {
            teststring = teststring + "*";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad10 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad11 == true)
        {
            teststring = teststring + "0";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad11 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad12 == true)
        {
            teststring = teststring + "#";
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            SampleUserPolling_ReadWrite.keypad12 = false;
            textChanged = true;
        }
        if (SampleUserPolling_ReadWrite.keypad13==true){
            if(teststring.Length > 0){

                teststring = teststring.Remove(teststring.Length-1);
                Debug.Log(teststring);
                SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
                SampleUserPolling_ReadWrite.keypad13 =false;
                textChanged = true;
            }
        }
        if (SampleUserPolling_ReadWrite.keypad14 == true)
        {

            sendkeypad = teststring;
            teststring = "";
            SampleUserPolling_ReadWrite.sendtext = "A-" + teststring;
            Debug.Log(teststring);
            SampleUserPolling_ReadWrite.keypad14 = false;
            textChanged = true;
        }
        if (textChanged)
        {
            pv.RPC("RPC_syncPseudoKeypad", RpcTarget.AllBuffered, teststring);
            textChanged = false;
        }
    }

    [PunRPC]
    void RPC_syncPseudoKeypad(string pteststring)
    {
        teststring = pteststring;
    }
}