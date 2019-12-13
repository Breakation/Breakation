using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_avatarSetup : MonoBehaviour
{

    private PhotonView PV;
    public int characterValue;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, sc_playerInfo.PI.mySelectedCharacter);
        }
    }


    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        characterValue = whichCharacter;
    }

}
