using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_HackController : MonoBehaviour
{
    public GameObject hackGUI;

    public GameObject HackButton;
    public GameObject CancelButton;
    public GameObject StartHackButton;

    public GameObject IpField;
    public GameObject PWField;


    private string eingegIP;
    private string eingegPW;



    private string mdAutomatMixDivIP = "7.1";
    private string mdAutomatMixDivPW = "mix";



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    public void startHack()
    {
        eingegIP = IpField.GetComponent<InputField>().text;
        eingegPW = PWField.GetComponent<InputField>().text;

        if(eingegIP == mdAutomatMixDivIP && eingegPW == mdAutomatMixDivPW)
        {
            sc_uiController.activateMixDivUI = true;
            CancelHack();
        }
    }
}
