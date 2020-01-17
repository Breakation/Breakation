using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sc_pseudoJoystick : MonoBehaviourPun, IPunObservable
{

    public static int xAxis;
    public static int zAxis;

    private PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            xAxis = 1000 ;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xAxis = 0;
        }
        else
        {
            xAxis = 500;
        }


        if (Input.GetKey(KeyCode.W))
        {
            zAxis = 1000;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zAxis = 0;
        }
        else
        {
            zAxis = 500;
        }

        //pv.RPC("RPC_syncJoyStick", RpcTarget.AllBuffered, xAxis, zAxis);
    }



    /*[PunRPC]
    void RPC_syncJoyStick(int pXAxis, int pZAxis)
    {
        xAxis = pXAxis;
        zAxis = pZAxis;
    }*/

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
    }
}
