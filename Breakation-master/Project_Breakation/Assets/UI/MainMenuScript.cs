using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsMenuMain");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLobby()
    {
        //SceneManager.LoadScene("...");
    }
}
