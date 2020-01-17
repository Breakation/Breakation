using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOnOff : MonoBehaviour
{

    public GameObject[] room, mini;
    public static bool roomChanged;

    
    // Update is called once per frame
    void Update()
    {
        if (roomChanged)
        {
            for (int i = 0; i < room.Length; i++)
            {
                mini[i].gameObject.SetActive(room[i].activeInHierarchy);
            }
            roomChanged = false;
        }
        
    }
}
