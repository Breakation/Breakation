using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSCR : MonoBehaviour
{
    
    

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.name ==  "Enemy")
        {

            Destroy(other.gameObject);

        }

    }

}
