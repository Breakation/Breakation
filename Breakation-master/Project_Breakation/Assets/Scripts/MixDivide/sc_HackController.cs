using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class sc_HackController : MonoBehaviour
{
    public GameObject hackGUI;

    public GameObject HackButton;
    public GameObject CancelButton;
    public GameObject StartHackButton;

    public GameObject IpField;
    public GameObject PWField;


    public GameObject mixerObj;
    public sc_Mixer mixerScr;


    private string eingegIP;
    private string eingegPW;



    private string mdAutomatMixDivIP = "7.1";
    private string mdAutomatMixDivPW = "mix";

    EventSystem system;

    void Start()
    {
        if(sc_playerInfo.PI.mySelectedCharacter == 1)
        {
            hackGUI.SetActive(false);
        }
        system = EventSystem.current;
        mixerScr = mixerObj.GetComponent<sc_Mixer>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           


            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");

        }

        if (Input.GetKeyDown(KeyCode.Return)){
            startHack();
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

    public void startHack()
    {
        eingegIP = IpField.GetComponent<InputField>().text;
        eingegPW = PWField.GetComponent<InputField>().text;

        if(eingegIP == mdAutomatMixDivIP && eingegPW == mdAutomatMixDivPW)
        {
            mixerScr.mixerHacked = true;
            testkeypad.sendkeypad = "";
            //sc_uiController.activateMixDivUI = true;
            
            CancelHack();
        }
    }
}
