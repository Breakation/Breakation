using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sc_photonRoomCM : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    public static sc_photonRoomCM room;
    private PhotonView PV;

    public static bool goOff;

    public bool isGameLoaded;
    public int currentScene;
    public int multiplayerScene;

    Player[] photonPlayers;
    public int playersInRoom;
    public int myNumberInRoom;

    public int playersInGame;

    private bool readyToCount;
    private bool readyToStart;
    public float startingTime;
    private float lessThanMaxPlayers;
    private float atMaxPlayers;
    private float timeToStart;


    public GameObject lobbyGO;
    public GameObject roomGO;
    public Transform playersPanel;
    public GameObject playerListingPrefab;
    public GameObject startButton;
    
    


    private void Awake()
    {
        if (sc_photonRoomCM.room == null)
        {
            sc_photonRoomCM.room = this;
        }
        else
        {
            if (sc_photonRoomCM.room != this)
            {
                Destroy(sc_photonRoomCM.room.gameObject);
                sc_photonRoomCM.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        //SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        //SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        readyToCount = false;
        readyToStart = false;
        lessThanMaxPlayers = startingTime;
        atMaxPlayers = 6;
        timeToStart = startingTime;
    }


    //void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    //{
    //    currentScene = scene.buildIndex;
    //    if(currentScene == multiplayerScene)
    //    {
    //        //isGameLoaded = true;
    //        {
    //            CreatePlayer();
    //        }
    //    }
    //}

    //private void CreatePlayer()
    //{
    //    PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
    //}

    // Update is called once per frame
    void Update()
    {

        if (goOff)
        {
            PV.RPC("RPC_goOff", RpcTarget.AllBuffered);
        }

        //if (MultiplayerSetting.multiplayerSetting.delayStart)
        //{
        //    if(playersInRoom == 1)
        //    {
        //        RestartTimer();
        //    }
        //    if (!isGameLoaded)
        //    {
        //        if (readyToStart)
        //        {
        //            atMaxPlayers -= Time.deltaTime;
        //            lessThanMaxPlayers = atMaxPlayers;
        //            timeToStart = atMaxPlayers;
        //        }else if (readyToCount)
        //        {
        //            lessThanMaxPlayers -= Time.deltaTime;
        //            timeToStart = lessThanMaxPlayers;
        //        }
        //        Debug.Log("Display time to start the players " + timeToStart);
        //        if(timeToStart <= 0)
        //        {
        //            StartGame();
        //        }
        //    }
        //}


    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("A new player has joined the room");
        CLearPlayerListings();
        ListPlayers();
        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom++;

    }

    public void StartGame()
    {
        isGameLoaded = true;
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        //if (MultiplayerSetting.multiplayerSetting.delayStart)
        //{
        //    PhotonNetwork.CurrentRoom.IsOpen = false;
        //}
        if(playersInRoom < 2)
        {
            Debug.Log("There has to be 1 Jailbreaker and 1 Supporter");
            return;
        }
        PhotonNetwork.LoadLevel(multiplayerScene);
    }


    public override void OnJoinedRoom()
    {


        base.OnJoinedRoom();
        Debug.Log("We are now in a room");
        Debug.Log("My Character : " + sc_playerInfo.PI.mySelectedCharacter);
        lobbyGO.SetActive(false);
        roomGO.SetActive(true);

        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }

        CLearPlayerListings();

        ListPlayers();


        if (!PhotonNetwork.IsMasterClient) return;
        //StartGame();


        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom = photonPlayers.Length;
        myNumberInRoom = playersInRoom;
        

        //if (Multiplayersetting.multiplayerSetting.delayStart)
        //{
        //    Debug.Log("Displayer players in room out of max players possible (" + playersInRoom + ":");
        //    if (playersInRoom > 1)
        //    {
        //        readyToCount = true;
        //    }
        //    if (playersInRoom == MUl)
        //}
    }


    void CLearPlayerListings()
    {
        for (int i = playersPanel.childCount -1; i >= 0; i--)
        {
            Destroy(playersPanel.GetChild(i).gameObject);
        }
    }

    void ListPlayers()
    {
        if (PhotonNetwork.InRoom)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                GameObject tempListing = Instantiate(playerListingPrefab, playersPanel);
                
                Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
                tempText.text = player.NickName;
              
            }
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log(otherPlayer.NickName + "has Left the game");
        playersInRoom--;

        CLearPlayerListings();
        ListPlayers();

        PhotonNetwork.LeaveRoom();

        SceneManager.LoadScene("MainMeuUI");
    }

    public void LeavePhotonRoom()
    {
       
        PhotonNetwork.LeaveRoom();

        SceneManager.LoadScene("MainMenuUI");
    }

    [PunRPC]
    void RPC_goOff()
    {
        PhotonNetwork.LeaveRoom();
    }

}
