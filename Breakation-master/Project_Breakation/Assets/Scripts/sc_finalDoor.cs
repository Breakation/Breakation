using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sc_finalDoor : MonoBehaviourPun, IPunObservable
{


    private string displayCode;
    private string eingegCode;
    private string finalCode = "150766961002";
    public GameObject prisonbars;
    private Animator barAnim;
    private Collider barColl;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    void Start()
    {
        barAnim = prisonbars.GetComponent<Animator>();
        barColl = prisonbars.GetComponent<Collider>();
    }
    

    // Update is called once per frame
    void Update()
    {
        displayCode = testkeypad.teststring;

        if (testkeypad.sendkeypad != "")
        {
            eingegCode = testkeypad.sendkeypad;


            //Debug.Log("eingegeben " + eingegCode);
            //Debug.Log("sendkeypad " + testkeypad.sendkeypad);

            if(eingegCode == finalCode)
            {
                Debug.Log("open final");
                barAnim.SetBool("Open", true);
                barColl.enabled = false;
            }else if(/*eingegCode.Length == 12 && */testkeypad.teststring == "")
            {
                sc_digitalDisplay.wrongCode = true;
            }
            
            
            testkeypad.textChanged = false;
        }

    }
}
