using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour

{

    public AudioMixer audiomixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // volume ändern per music mixer einmal gruppe music und einmal sound

    public void SetVolumeMusic(float volumeMusic)
    {
        audiomixer.SetFloat("Volume_music",volumeMusic);
    }


    public void SetVolumeSound(float volumeSound)
    {
        audiomixer.SetFloat("Volume_sound", volumeSound);
    }

    // Muten per zugriff auf music mixer und mute master, da darin alle untergruppen wie music und sound enthalten sind

    bool mute = true;
    float speicher;

    public void MuteAll()
    {
        switch (mute)
        {
            case false:
                DeMuteAll();
                break;

            case true:
                    audiomixer.GetFloat("Volume_Master", out speicher);
                    float f = -80;
                    audiomixer.SetFloat("Volume_Master", f);
                    mute = false;
                break;

        }
    }

    public void DeMuteAll()
    {
            audiomixer.SetFloat("Volume_Master", 0);
            mute = true;
        
    }

    //Pitch zugriff auf music mixer

    public void pitchMusic(float pitch)
    {
        audiomixer.SetFloat("Pitch_Music",pitch);
    }




    /// <summary>
    /// /Scenene von Main Menu und Pause menu laden Buttons
    /// </summary>
    /// 
    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenuUI");
    }

    public void backToPauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }
}
