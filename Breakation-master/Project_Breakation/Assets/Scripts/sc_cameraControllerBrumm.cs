using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_cameraControllerBrumm : MonoBehaviour
{
    public GameObject playerCar;
    public static bool brummSpiel = true;

    public Vector3 distToCar = new Vector3(0, 5f, -10f);

    // Update is called once per frame
    void LateUpdate()
    {
        if (brummSpiel)
        {
            transform.position = Vector3.Lerp(transform.position,playerCar.transform.position + distToCar,1.0f) ;
        }
    }
}
