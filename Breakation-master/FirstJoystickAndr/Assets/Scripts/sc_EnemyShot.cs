using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_EnemyShot : MonoBehaviour
{
    private bool isAwake = false;
    public GameObject mySelf;

    public GameObject bullet;
    public float spd = 50f;
    public int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tempScript = mySelf.GetComponent<EnemyScr>();
        isAwake = tempScript.isAwake;


        if (isAwake)
        {
            if (timer >= 40)
            {
                GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                //instBullet.transform.rotation = transform.rotation;
                //instBulletRigidbody.AddForce(Vector3.forward * spd);

                instBulletRigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, spd));

                Destroy(instBullet.gameObject, 3);

                timer = 0;
            }
            timer++;
        }
    }
}
