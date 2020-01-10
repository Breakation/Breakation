﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opener : MonoBehaviour
{
    private bool isOpen = false;
    private bool PlayerInRange = false;
  
   // public GameObject OpenPanel = null;
    private Animator _animator;
    public Renderer[] obj = new Renderer[4];
    private Material inactivMaterial;
    public Material setMaterial;

   // public string OpenText = "Click to Open";
   // public string CloseText = "Click to Close";

    private void Start()
    {
        _animator = transform.GetComponentInParent<Animator>();
        inactivMaterial = obj[0].material;

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            PlayerInRange = true;
          //  OpenPanel.SetActive(true);
            //UpdatePanelText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "Player")
        {
            PlayerInRange = false;

            // OpenPanel.SetActive(false);
            obj[0].material = inactivMaterial;
            obj[1].material = inactivMaterial;
            obj[2].material = inactivMaterial;
            obj[3].material = inactivMaterial;
        }
        
    }

  /*  private bool isOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

     private void UpdatePanelText()
     {
         Text panelText = OpenPanel.transform.Find("Text").GetComponent<Text>();
         if(panelText != null)
         {
             panelText.text = isOpen ? CloseText : OpenText;
         }
     }
    */
    

    private void OnMouseOver()
    {
        if (PlayerInRange)
        {

            obj[0].material = setMaterial;
            obj[1].material = setMaterial;
            obj[2].material = setMaterial;
            obj[3].material = setMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (PlayerInRange)
        {

            obj[0].material = inactivMaterial;
            obj[1].material = inactivMaterial;
            obj[2].material = inactivMaterial;
            obj[3].material = inactivMaterial;
        }
    }


    private void OnMouseDown()
    {
        
        if (PlayerInRange)
        {
            isOpen = !isOpen;
           // UpdatePanelText();
            _animator.SetBool("open", isOpen);
        }
    }


}
