using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_RoomButton : MonoBehaviour
{

    public Text nameText;
    public Text sizeText;

    public string roomName;


    public void SetRoom()
    {
        nameText.text = roomName;

    }

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

}
