using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCameraController : MonoBehaviour
{

    Vector3 player1Pos = new Vector3(0, 8, -25);
    Vector3 player1Rot = new Vector3(30, 0, 0);


    Vector3 player2Pos = new Vector3(0, 8, 25);
    Vector3 player2Rot = new Vector3(30, 180, 0);


    // Start is called before the first frame update
    void Start()
    {
        if(sc_playerInfo.PI.mySelectedCharacter == 1)
        {
            transform.position = player1Pos;
            transform.rotation = Quaternion.Euler(player1Rot);
        }
        if (sc_playerInfo.PI.mySelectedCharacter == 2)
        {
            transform.position = player2Pos;
            transform.rotation = Quaternion.Euler(player2Rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
