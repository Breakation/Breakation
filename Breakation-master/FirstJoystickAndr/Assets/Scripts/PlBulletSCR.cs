using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlBulletSCR : MonoBehaviour
{

    public GameObject player;
    public Rigidbody myBody;
    public static string targetType;
    public EnemyScr enemy;
    

    private void OnCollisionEnter(Collision collision)
    {
        

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            

            myBody.velocity = Vector3.zero;
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.transform.parent.GetComponent<EnemyScr>();
            enemy.enemyLp--;
            myBody.velocity = Vector3.zero;
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }

    }

}
