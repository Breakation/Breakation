using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool PlayerInRange = false;
    public GameObject info;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerInRange = true;
            info.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerInRange = false;
            info.SetActive(false);

        }
    }

    private void OnMouseDown()
    {

        if (PlayerInRange)
        {
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 90, 0);
        }
    }
   
}
