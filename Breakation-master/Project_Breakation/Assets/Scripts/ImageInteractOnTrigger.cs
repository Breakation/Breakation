using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInteractOnTrigger : MonoBehaviour
{

    [SerializeField] private Image image; //makes it visible in the inspector without making a public variable
    

    private void OnTriggerEnter(Collider other)
    {
        // if the player enters the trigger the image appears
        if (other.CompareTag("Player"))
        {
            image.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if the player leaves the trigger the image disappears
        if (other.CompareTag("Player"))
        {
            image.enabled = false;
        }
    }
}
