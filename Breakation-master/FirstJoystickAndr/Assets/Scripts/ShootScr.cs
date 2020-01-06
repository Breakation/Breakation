using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScr : MonoBehaviour
{

    public GameObject bullet;
    public float spd = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
        GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            //instBulletRigidbody.AddForce(Vector3.forward * spd);

            instBulletRigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, spd));

            Destroy(instBullet.gameObject, 3);
            
        }


    }
}
