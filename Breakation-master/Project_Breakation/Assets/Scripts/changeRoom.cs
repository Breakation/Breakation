using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRoom : MonoBehaviour
{
    public GameObject player;
    public GameObject location;
    private CharacterController charcon;
    public GameObject targetRoom, actualRoom;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        charcon = player.GetComponent<CharacterController>();
        
       // targetRoom.SetActive(false);
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        targetRoom.SetActive(true);
        Debug.Log("klappt?");
        charcon.enabled = false;
        player.transform.position = location.transform.position;
        charcon.enabled = true;
        actualRoom.SetActive(false);
        RoomOnOff.roomChanged = true;
    }

   
}
