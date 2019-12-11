using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenerWithUhr : MonoBehaviour
{
    private bool isOpen = false;
    public static bool op_triggered = false;
  
   // public GameObject OpenPanel = null;
    private Animator _animator;
    public Renderer obj;
    private Material inactivMaterial;
    public Material setMaterial;

   // public string OpenText = "Click to Open";
   // public string CloseText = "Click to Close";

    private void Start()
    {
        _animator = transform.GetComponentInParent<Animator>();
        inactivMaterial = obj.material;

    }


    private void Update()
    {
        if (op_triggered && !isOpen)
        {
            isOpen = !isOpen;
            _animator.SetBool("open", isOpen);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if(other.tag == "Player")
    //    {
    //        PlayerInRange = true;
    //      //  OpenPanel.SetActive(true);
    //        //UpdatePanelText();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.tag == "Player")
    //    {
    //        PlayerInRange = false;

    //       // OpenPanel.SetActive(false);
    //        obj.material = inactivMaterial;
    //    }

    //}

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


    //private void OnMouseOver()
    //{
    //    if (PlayerInRange)
    //    {

    //        obj.material = setMaterial;
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    if (PlayerInRange)
    //    {

    //        obj.material = inactivMaterial;
    //    }
    //}


    //private void OnMouseDown()
    //{

    //    if (PlayerInRange)
    //    {
    //        isOpen = !isOpen;
    //       // UpdatePanelText();
    //        _animator.SetBool("open", isOpen);
    //    }
    //}


}
