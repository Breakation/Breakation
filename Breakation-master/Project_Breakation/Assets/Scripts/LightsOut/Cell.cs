using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // diese Klasse ist für unseren Behälter. Mit der interagiert Spieler im spiel
    public bool capOpen;
    public CellController cellController;
    Animator animator;
    bool onTrigger;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }
    private void Update()
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

        if (capOpen)
        {
            Debug.Log("cap is open!");
            //rotation annimation
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
                    onTrigger = false;
                }
            }
        }
    }
    
}
