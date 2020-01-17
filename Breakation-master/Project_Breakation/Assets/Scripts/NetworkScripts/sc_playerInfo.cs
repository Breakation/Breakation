using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_playerInfo : MonoBehaviour
{

    public static sc_playerInfo PI;
    public int mySelectedCharacter;


    private void OnEnable()
    {
        if (sc_playerInfo.PI == null)
        {
            sc_playerInfo.PI = this;
        }
        else
        {
            if(sc_playerInfo.PI != this)
            {
                Destroy(sc_playerInfo.PI.gameObject);
                sc_playerInfo.PI = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
    }

    
}
