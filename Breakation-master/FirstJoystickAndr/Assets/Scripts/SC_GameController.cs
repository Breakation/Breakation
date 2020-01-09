using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SC_GameController : MonoBehaviour
{
    private int popUpTimer = 0;
    
    public InputField ipField;
    private string eingabe;

    public GameObject errorMess;
    private bool errorShown = false;

    public string[] ipAdressen;
    public string[] pw;

    private int rememberPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (errorShown)
        {
            popUpTimer++;
            if (popUpTimer >= 30)
            {
                errorMess.SetActive(false);
                errorShown = false;
                popUpTimer = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startPressed();
        }
    }


    public void startPressed()
    {
        eingabe = ipField.text;

        for (int i = 0; i < ipAdressen.Length; i++)
        {
            if(eingabe == ipAdressen[i])
            {
                rememberPos = i;
                startGame();
                return;
            }
        }
        errorMess.SetActive(true);
        errorShown = true;
        Debug.Log("start");
    }

    private void startGame()
    {
        SceneManager.LoadScene(1);
    }

}
