using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sc_carContr : MonoBehaviourPun, IPunObservable
{
    [SerializeField]
    private int xRotation = SampleUserPolling_ReadWrite.JoyXvalue; // sc_pseudoJoystick.xAxis;
    [SerializeField]
    private int zDirection = SampleUserPolling_ReadWrite.JoyYvalue;  //sc_pseudoJoystick.zAxis;

    private Vector3 moveDir = Vector3.zero;

    CharacterController CC;

    PhotonView pv;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    private void Start()
    {
        CC = GetComponent<CharacterController>();
        pv = GetComponent<PhotonView>();

    }

    void Update()
    {
        xRotation = SampleUserPolling_ReadWrite.JoyXvalue;
        zDirection = SampleUserPolling_ReadWrite.JoyYvalue;

       // xRotation = sc_pseudoJoystick.xAxis;
        //zDirection = sc_pseudoJoystick.zAxis;


        if(xRotation > 690)
        {
            xRotation = (xRotation - 690)/-50;
            
        }
        else if(xRotation < 400)
        {
            xRotation = (400 - xRotation) / 50;
        }
        else
        {
            xRotation = 0;
        }

        if (zDirection > 690)
        {
            zDirection = (zDirection - 690) / 50;

        }
        else if(zDirection < 400)
        {
            zDirection = (400 - zDirection) / -50;
        }
        else
        {
            zDirection = 0;
        }

        //moveDir = zDirection * transform.forward;


        moveDir = new Vector3(xRotation, 0 , zDirection);



        //transform.Rotate(0, xRotation, 0);

        
        if(CC.enabled) if (moveDir != Vector3.zero) transform.rotation = Quaternion.LookRotation(moveDir);
        

        CC.Move(moveDir * Time.deltaTime);

        pv.RPC("RPC_syncCar", RpcTarget.AllBuffered);
    }
}

