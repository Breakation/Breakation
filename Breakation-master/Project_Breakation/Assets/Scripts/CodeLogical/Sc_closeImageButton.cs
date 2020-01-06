using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_closeImageButton : MonoBehaviour
{
    public Image image;
    public Button button;
    private Text text;

    public void CloseOnClick()
    {
        image.enabled = false;
        button.enabled = false;
        button.image.enabled = false;
        text = button.GetComponentInChildren<Text>();
        text.enabled = false;
        Debug.Log("you are clicking the close button!!");
    }
}
