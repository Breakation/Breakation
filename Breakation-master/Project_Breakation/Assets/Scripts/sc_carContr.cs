using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_carContr : MonoBehaviour
{
    [SerializeField]
    private int xDirection = sc_pseudoJoystick.xAxis;
    [SerializeField]
    private int zDirection = sc_pseudoJoystick.zAxis;

    private Vector3 moveDir = Vector3.zero;

    CharacterController CC;

    private void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        xDirection = sc_pseudoJoystick.xAxis;
        zDirection = sc_pseudoJoystick.zAxis;


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

