using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_MenuController : MonoBehaviour
{


    private PhotonView PV;


    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, sc_playerInfo.PI.mySelectedCharacter);
        }
    }

    public void OnClickCharacterPick(int whichCharacter)
    {
        if(sc_playerInfo.PI != null)
        {
            sc_playerInfo.PI.mySelectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);
            
        }
    }


    
}
