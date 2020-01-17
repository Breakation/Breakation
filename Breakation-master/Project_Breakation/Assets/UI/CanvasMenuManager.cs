using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuManager : MonoBehaviour
{

    [SerializeField] GameObject CanvasOptionMenu;
    [SerializeField] GameObject CanvasPauseMenu;
    [SerializeField] AudioSource MainTheme;

    public static bool GameIsPaused = false;
    public static bool MainThemePlays = false;



    PauseMenuScript _pauseMenuScript = new PauseMenuScript();

    // Start is called before the first frame update
    void Start()
    { 

        CanvasOptionMenu.SetActive(false);
        CanvasPauseMenu.SetActive(false);
        MainTheme.Pause();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                GameIsPaused = false;
                MainTheme.Play(0);
                MainThemePlays = true;

            }
            else
            {
                CanvasPauseMenu.SetActive(true);
                CanvasOptionMenu.SetActive(false);
                MainTheme.Pause();
                GameIsPaused = true;
                MainThemePlays = true;


            }
        }
    }


}
