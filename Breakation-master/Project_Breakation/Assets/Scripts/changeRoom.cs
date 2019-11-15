using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRoom : MonoBehaviour
{
    public GameObject player;
    public GameObject location;
    
    private void OnTriggerEnter(Collider other)
    {

        player.transform.position = location.transform.position;
    }
}
