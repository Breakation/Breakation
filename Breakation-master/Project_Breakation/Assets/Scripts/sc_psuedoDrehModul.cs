using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sc_psuedoDrehModul : MonoBehaviourPun, IPunObservable
{
    public static bool rightRotation = false;
    public static bool leftRotation = false;

    private PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            rightRotation = true;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            leftRotation = true;
        }

        pv.RPC("RPC_syncDrehModul", RpcTarget.AllBuffered, rightRotation, leftRotation);
    }


    [PunRPC]
    void RPC_syncDrehModul(bool pRightRotation, bool pLeftRotation)
    {
        rightRotation = pRightRotation;
        leftRotation = pLeftRotation;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
