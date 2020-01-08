using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UhrzeitTuerController : MonoBehaviour
{
    public static bool clockHacked = false;

    public GameObject hackGUI;

    public GameObject HackButton;
    public GameObject CancelButton;
    public GameObject StartHackButton;

    private string clockIP = "1.2";
    private string clockPW = "clock";

    private string eingegIP;
    private string eingegPW;

    public GameObject IpField;
    public GameObject PWField;

    // Start is called before the first frame update
    void Start()
    {
        //if(sc_playerInfo.PI.mySelectedCharacter != 2)
        //{
        //    hackGUI.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SampleUserPolling_ReadWrite.encoderright = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SampleUserPolling_ReadWrite.encoderleft = true;
        }
    }


    public void Hack()
    {
        HackButton.SetActive(false);
        CancelButton.SetActive(true);
        IpField.SetActive(true);
        PWField.SetActive(true);
        StartHackButton.SetActive(true);
    }

    public void CancelHack()
    {
        HackButton.SetActive(true);
        CancelButton.SetActive(false);
        IpField.SetActive(false);
        PWField.SetActive(false);
        StartHackButton.SetActive(false);
    }

    

    public void StartHack()
    {
        eingegIP = IpField.GetComponent<InputField>().text;
        eingegPW = PWField.GetComponent<InputField>().text;

        if((eingegIP == clockIP) && (eingegPW == clockPW))
        {
            CancelHack();
            clockHacked = true;
        }

    }
}
