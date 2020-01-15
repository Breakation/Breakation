using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_psuedoDrehModul : MonoBehaviour
{
    public static bool rightRotation = false;
    public static bool leftRotation = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            rightRotation = true;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            leftRotation = true;
        }
    }
}
