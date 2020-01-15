using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()

    {   // public variable um anzuzeigen dass spiel nicht mehr pausiert
        GameIsPaused = false;

        // Pause Menu wieder schließen
        pauseMenuUI.SetActive(false);

        // Spiel nicht mehr freezen
        //Time.timeScale = 1f;
    }

    public  void pause()
    {
        // public variable um anzuzeigen ob spiel pausiert
        GameIsPaused = true;

        // Pause Menu öffnen und Scene anzeigen
        pauseMenuUI.SetActive(true);

        // Spiel freezen
        //Time.timeScale = 0f;
    }

    public void options()
    {
        // code für option button soll neue option szene laden wo einstellungen vorgenommen werden können
        // BSP unten wenn scene options heißt
        SceneManager.LoadScene("OptionsMenu");
        Debug.Log("Options");

        // Achtung Game ist bei Options noch frozen durch TimeScale = 0 nachher auf jeden Fall Resume!! mit Timesclae = 1

    }

    public void quitGame()
    {
        // hier kommt der Code für den Quit button rein muss aber noch geklärt werden mit Netzwerk wie das möglich ist zu quitten oder wenn ein spieler quittet

          /////////////////////////////////////////////////////////////////////////
         //mit Netzwerk abklären was hier hin muss um ins main menu zu wechseln///
        /////////////////////////////////////////////////////////////////////////
        
        SceneManager.LoadScene("MainMenuUI");
        Debug.Log("Quit Game");

        // Achtung Game ist bei Quit noch frozen durch TimeScale = 0

    }

}
