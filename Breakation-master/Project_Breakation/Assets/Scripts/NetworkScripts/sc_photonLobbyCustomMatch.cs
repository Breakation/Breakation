using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_photonLobbyCustomMatch : MonoBehaviourPunCallbacks, ILobbyCallbacks
{


    public static sc_photonLobbyCustomMatch lobby;

    public string roomName;
    public GameObject roomListingPrefab;
    public Transform roomsPanel;
    public GameObject roomGo;
    public GameObject lobbyGO;
   

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
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
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

        roomGo.SetActive(false);
        lobbyGO.SetActive(true);

        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)2 };
        PhotonNetwork.CreateRoom(roomName, roomOps);
        sc_playerInfo.PI.mySelectedCharacter = 1;
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
            sc_playerInfo.PI.mySelectedCharacter = 2;
        }
    }

    public void LoadMainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenuUI");
    }

}
