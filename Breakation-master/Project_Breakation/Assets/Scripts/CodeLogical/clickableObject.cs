using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clickableObject : MonoBehaviour
{
    public Image image;
    public Button button;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        button.enabled = false;
        button.image.enabled = false;
        text = button.GetComponentInChildren<Text>();
        text.enabled = false;
    }

    private void OnMouseDown()
    {
        // Turns the image on if it is off, and off if it is on.
        image.enabled = !image.enabled;
        button.enabled = !button.enabled;
        button.image.enabled = !button.image.enabled;
        text.enabled = !text.enabled;
        Debug.Log("you are clicking the sheet!!!");
    }

}
