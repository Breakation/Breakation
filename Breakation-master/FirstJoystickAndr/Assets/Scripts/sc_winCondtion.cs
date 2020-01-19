using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_winCondtion : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject pwObj;
    public Text pwTxt;

    public static int enmyCount = 7;


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sc_winCondtion.enmyCount--;
        }
        Debug.Log(enmyCount);
        if(enmyCount <= 0)
        {
            pwTxt = pwObj.GetComponent<Text>();
            pwTxt.text = SC_GameController.currentPw;
            winScreen.SetActive(true);
        }
    }
}
