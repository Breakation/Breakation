using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_carContr : MonoBehaviour
{
    [SerializeField]
    private int xDirection = SampleUserPolling_ReadWrite.JoyXvalue; // sc_pseudoJoystick.xAxis;
    [SerializeField]
    private int zDirection = SampleUserPolling_ReadWrite.JoyYvalue;  //sc_pseudoJoystick.zAxis;

    private Vector3 moveDir = Vector3.zero;

    CharacterController CC;

    private void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        xDirection = SampleUserPolling_ReadWrite.JoyXvalue;
        zDirection = SampleUserPolling_ReadWrite.JoyYvalue;


        if(xDirection > 500)
        {
            xDirection = (xDirection - 500)/50;
            
        }
        else if(xDirection <500)
        {
            xDirection = (500 - xDirection) / -50;
        }
        else
        {
            xDirection = 0;
        }

        if (zDirection > 500)
        {
            zDirection = (zDirection - 500) / 50;

        }
        else if(zDirection < 500)
        {
            zDirection = (500 - zDirection) / -50;
        }
        else
        {
            zDirection = 0;
        }


        moveDir = new Vector3(xDirection, 0.0f, zDirection);
        if(CC.enabled) if (moveDir != Vector3.zero) transform.rotation = Quaternion.LookRotation(moveDir);


        CC.Move(moveDir * Time.deltaTime);
    }
}

