using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sc_finalDoor : MonoBehaviourPun, IPunObservable
{


    private string displayCode;
    private string finalCode = "0000";


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    

    // Update is called once per frame
    void Update()
    {
        displayCode = testkeypad.teststring;

        if (SampleUserPolling_ReadWrite.keypad14)
        {
            if(displayCode == finalCode)
            {

            }
            else
            {
                
            }
        }

    }
}
