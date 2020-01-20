using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_zoomTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("true");
            SC_Zoomable.inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("false");
            SC_Zoomable.inRange = false;
        }
    }
}
