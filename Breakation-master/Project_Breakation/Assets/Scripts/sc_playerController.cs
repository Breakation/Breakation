using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_playerController : MonoBehaviour
{
    public float moveSpeed;

    //für den CharacterController
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    //für den Animator : ist implementiert. brauche nur Samira's Modell einzuintegrieren
    //public Animator anim;

    //Diese Referenzen sind für die Kontrolle der Spielerrotation in correspondance with the camera
    public Transform pivot; //der Spieler orientiert sich nicht an die Camera selbst sondern einer Art Pivotpunkt 
    public float rotateSpeed;
    //public GameObject playerModel; Dafür ist der 3D Modell von Samira notwendig!

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //for CharacterController movement
        float yStore = moveDirection.y;//behalten des ursprünglichen Y-Werts
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        //gravity
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        //apply movement on controller; Time.deltaTime calculates how long it was since last frame was rendered
        controller.Move(moveDirection * Time.deltaTime);
         

        //move the player in dieffrenet direction in correspondance to the camera's view
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)// if the player is moving
        {//we rotate: we need to be facing wherever our pivot point is facing
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y/*whatever rotation makes our camera rotate horizontally*/, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z)); // LookRotation : you give this function a point in the world and it makes the object look at that point (face its direction)
            //playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        this.Menu(); // damit lässt sich der InventoryPanel schließen (Tab drücken)!
        //changes animation if player is not on the ground (for jumping but we don't need that )
        //anim.SetBool("isOnGround", controller.isGrounded);
        //changes animation if player is moving (if there is any vertical or horizontal input the value of GetAxis is 1 and so its greater than 0.1
        //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    public void Menu()//this function enables/disables the InventoryPanel using setActive()
    { // !!!! the  InventoryPanel should be disables first!!!!

        if (Input.GetKeyDown(KeyCode.Tab))// be able to open/close the InventoryPanel by pressing Tab
        {
            GameObject ip = sc_Inventory.instance.inventoryPanel;

            if (!ip.activeSelf)
            {
                ip.SetActive(true);
            }
            else
            {
                ip.SetActive(false);
            }
        }
    }

    

}
