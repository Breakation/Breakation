using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSCR : MonoBehaviour
{

    public GameObject player;
    public Rigidbody myBody;
    public static string targetType;

    

    private void OnCollisionEnter(Collision collision)
    {
        

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "PlayerTrigger")
        {
            myBody.velocity = Vector3.zero;
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "PlayerTrigger")
        {
            myBody.velocity = Vector3.zero;
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }

    }

}
