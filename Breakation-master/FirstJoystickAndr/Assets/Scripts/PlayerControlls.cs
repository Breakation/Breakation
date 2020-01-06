using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespd = 5;

    public Rigidbody PLrigidbody;
    public Joystick MoveJoystick;
    public Joystick ShootJoystick;

    protected Joystick joystick;

    protected bool shoot;

    public GameObject bullet;
    public float spd = 40f;
    public int shotcount = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        PLrigidbody.velocity = new Vector3(MoveJoystick.Horizontal * 10f, PLrigidbody.velocity.y, MoveJoystick.Vertical * 10f);


        float hormovement = Input.GetAxis("Horizontal");
        float vermovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hormovement, 0.0f, vermovement);

        Vector3 lookat = new Vector3(ShootJoystick.Horizontal, 0, ShootJoystick.Vertical);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookat), 0.1f);

        transform.Translate(movement * movespd * Time.deltaTime, Space.World);



        if(!shoot && ShootJoystick.Pressed)
        {
            shoot = true;
        }
        if (shoot && !ShootJoystick.Pressed)
        {

            shoot = false;

        }

        if (shoot)
        {

            if(shotcount > 6)
            {
                GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                //instBulletRigidbody.AddForce(Vector3.forward * spd);

                instBulletRigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, spd));

                Destroy(instBullet.gameObject, 3);

                shotcount = 0;
            }

            shotcount++;

        }

    }
}
