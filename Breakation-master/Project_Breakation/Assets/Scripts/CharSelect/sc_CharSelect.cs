using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_CharSelect : MonoBehaviour
{
    private bool firstCharUnlocked = false;
    private bool secondCharUnlocked = false;
    private bool thirdCharUnlocked = false;


    private string doorFirstCharIP = "0.1";
    private string doorSecondCharIP = "0.2";
    private string doorThirdCharIP = "0.3";

    private string doorFirstCharPW = "thug";
    private string doorSecondCharPW = "nerd";
    private string doorThirdCharPW = "crack";



    private string eingegIP;
    private string eingegPW;

    public CharacterController firstCharContr;
    public CharacterController secondCharContr;
    public CharacterController thirdCharContr;

    public GameObject firstChar;
    public GameObject secondChar;
    public GameObject thirdChar;
    

    public GameObject HackButton;
    public GameObject CancelButton;
    public GameObject StartHackButton;

    public GameObject IpField;
    public GameObject PWField;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if ((eingegIP == doorSecondCharIP) && (eingegPW == doorSecondCharPW))
        {
            CancelHack();
            secondCharUnlocked = true;
            secondCharContr = secondChar.GetComponent<CharacterController>();
            secondCharContr.enabled = true;
        }
        if ((eingegIP == doorFirstCharIP) && (eingegPW == doorFirstCharPW))
        {
            CancelHack();
            firstCharUnlocked = true;
            firstCharContr = firstChar.GetComponent<CharacterController>();
            firstCharContr.enabled = !firstCharContr.enabled;
            
        }
        if ((eingegIP == doorThirdCharIP) && (eingegPW == doorThirdCharPW))
        {
            CancelHack();
            thirdCharUnlocked = true;
            thirdCharContr = thirdChar.GetComponent<CharacterController>();
            thirdCharContr.enabled = true;
        }

    }
}
