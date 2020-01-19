using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_cameraSwitch : MonoBehaviour
{
    public Camera firstCam, secondCam;
    private bool switchC = false;
    private bool gotSwitched = false;

    void Start()
    {
        if(sc_playerInfo.PI.mySelectedCharacter == 1)
        {
            firstCam.gameObject.SetActive(true);
            secondCam.gameObject.SetActive(false);
        }
        else
        {
            firstCam.gameObject.SetActive(false);
            secondCam.gameObject.SetActive(true) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L) && !gotSwitched)
        {
            switchC = !switchC;
            gotSwitched = true;

            firstCam.gameObject.SetActive(switchC);
            secondCam.gameObject.SetActive(!switchC);
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            gotSwitched = false;
        }
    }
}
