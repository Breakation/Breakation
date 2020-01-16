using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sc_carContr : MonoBehaviourPun, IPunObservable
{
    [SerializeField]
    private int xDirection = SampleUserPolling_ReadWrite.JoyXvalue; // sc_pseudoJoystick.xAxis;
    [SerializeField]
    private int zRotation = SampleUserPolling_ReadWrite.JoyYvalue;  //sc_pseudoJoystick.zAxis;

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
        xDirection = SampleUserPolling_ReadWrite.JoyXvalue;
        zRotation = SampleUserPolling_ReadWrite.JoyYvalue;

        xDirection = sc_pseudoJoystick.xAxis;
        zRotation = sc_pseudoJoystick.zAxis;


        if(xDirection > 500)
        {
            xDirection = (xDirection - 500)/50;
            
        }
        else if(xDirection < 500)
        {
            xDirection = (500 - xDirection) / -50;
        }
        else
        {
            xDirection = 0;
        }

        if (zRotation > 500)
        {
            zRotation = (zRotation - 500) / -50;

        }
        else if(zRotation < 500)
        {
            zRotation = (500 - zRotation) / 50;
        }
        else
        {
            zRotation = 0;
        }

        moveDir = xDirection * transform.forward;


        transform.Rotate(0, zRotation, 0);

        
        if(CC.enabled) if (moveDir != Vector3.zero) transform.rotation = Quaternion.LookRotation(moveDir);
        

        CC.Move(moveDir * Time.deltaTime);

        pv.RPC("RPC_syncCar", RpcTarget.AllBuffered);
    }
}

