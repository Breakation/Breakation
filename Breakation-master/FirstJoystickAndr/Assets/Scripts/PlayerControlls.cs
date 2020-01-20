using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespd = 5;

    public static int lp;


    public GameObject gameOver;

    public Rigidbody PLrigidbody;
    public Joystick MoveJoystick;
    public Joystick ShootJoystick;

    protected Joystick joystick;

    protected bool shoot;

    public GameObject bullet;
    public float spd = 40f;
    public int shotcount = 0;

    Vector3 lookat;

    void Start()
    {
        lp = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y != 5)
        {
            transform.position = new Vector3(transform.position.x,5,transform.position.z);
        }

        if(lp<= 0)
        {
            gameOver.SetActive(true);
            Destroy(this.gameObject);
        }

        PLrigidbody.velocity = new Vector3(MoveJoystick.Horizontal * 10f, PLrigidbody.velocity.y, MoveJoystick.Vertical * 10f);


        float hormovement = Input.GetAxis("Horizontal");
        float vermovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hormovement, 0.0f, vermovement);
        if (ShootJoystick.Pressed)
        {
            lookat = new Vector3(ShootJoystick.Horizontal, 0, ShootJoystick.Vertical);
        }
        else
        {
            lookat = new Vector3(MoveJoystick.Horizontal, 0, MoveJoystick.Vertical);
        }
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
