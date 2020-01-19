using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_camreaSwitch : MonoBehaviour
{
    public Camera firstCam, secondCam;
    private bool switchC = false;
    private bool gotSwitched = false;

    // Start is called before the first frame update
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
            secondCam.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L) && !gotSwitched)
        {
            switchC = !switchC;
            firstCam.gameObject.SetActive(switchC);
            secondCam.gameObject.SetActive(!switchC);
            gotSwitched = true;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            gotSwitched = false;
        }
    }
}
