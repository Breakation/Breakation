using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_photonLobbyCustomMatch : MonoBehaviourPunCallbacks, ILobbyCallbacks
{


    public static sc_photonLobbyCustomMatch lobby;

    public string roomName;
    public GameObject roomListingPrefab;
    public Transform roomsPanel;
   

    private void Awake()
    {
        lobby = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        // next line loads every player in the same scene
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        RemoveRoomListings();
        foreach (RoomInfo room in roomList)
        {
            ListRoom(room);
        }

    }

    void RemoveRoomListings()
    {
        while(roomsPanel.childCount != 0)
        {
            Destroy(roomsPanel.GetChild(0).gameObject);
        }
    }

    void ListRoom(RoomInfo room)
    {
        if(room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsPanel);
            sc_RoomButton tempButton = tempListing.GetComponent<sc_RoomButton>();

            tempButton.roomName = room.Name;

            tempButton.SetRoom();

        }
    }

    public void CreateRoom()
    {
        Debug.Log("Trying to create a new room");

        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)2 };
        PhotonNetwork.CreateRoom(roomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
    }

    public void onRoomNameChanged(string nameIn)
    {
        roomName = nameIn;
    }

    public void JoinLobbyOnClick()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

}
