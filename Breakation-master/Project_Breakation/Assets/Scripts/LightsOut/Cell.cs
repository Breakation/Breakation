using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // diese Klasse ist für unseren Behälter. Mit der interagiert Spieler im spiel
    public bool closable;
    public bool special, onTrigger, capOpen, allowedToOpen;
    public Transform capHinge;
    public CellController cellController;
    //Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I am in!");
        onTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("I am out!");
        onTrigger = false;
        allowedToOpen = false;
    }

    private void Update()
    {
        if (allowedToOpen)
        {
            if (closable)
            {
                capOpen = true;
                Debug.Log("closable is true!");
            }
            else
            {
                Debug.Log("closable is false!");
            }   
        }

        if (capOpen)
        {
            Debug.Log("cap is open!");
            //rotation annimation
            capHinge.rotation = Quaternion.RotateTowards(capHinge.rotation, Quaternion.Euler(-0.0f, -0.0f, 0.0f), Time.deltaTime * 250);
            //animator.SetInteger("anim_state",1);{

            if (cellController.cellStatus ==  CellController.Status.open)
            {
                cellController.closeCap();
            }
            else
            {
                cellController.openCap();
            }
            
            cellController.AffectCells();
        }
    }

    public void ArduinoInputSetClosableOnTrue() // diese Methode ist für den Controller
    {
        this.closable = true;
    }

    private void OnGUI()
    {
        if (!capOpen)
        {
            if (onTrigger)
            {
                GUI.backgroundColor = Color.yellow;
                GUI.Box(new Rect(0, 0, 400, 25), "Press E to open cap!");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    allowedToOpen = true;
                    onTrigger = false;
                }
            }

            if (allowedToOpen)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "you are now allowed to open!");
            }
        }
    }
    
}
