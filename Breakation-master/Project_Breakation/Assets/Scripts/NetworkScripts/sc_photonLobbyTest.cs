using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_photonLobbyTest : MonoBehaviourPunCallbacks
{

    public static sc_photonLobbyTest lobby;


    public GameObject battleButton;
    public GameObject cancelButton;



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
        Debug.Log("connected to photon master server");
        battleButton.SetActive(true);
    }


    public void OnBattleButtonClicked()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("tried to join , failed, there must be no rooms avaible");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a room , failed, must be room with same name");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
