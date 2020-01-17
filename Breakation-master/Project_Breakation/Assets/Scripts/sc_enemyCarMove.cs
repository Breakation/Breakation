using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_enemyCarMove : MonoBehaviour
{
    public static bool follow = true;
    public GameObject lostScreen;
    public GameObject restartBtn;

    public GameObject playerCar;
    public static int spd = 1;
    public int timeToLive = 180;
    [SerializeField]
    public static int aliveTime = 0;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayerCar")
        {
            follow = false;
            CharacterController tempCC = playerCar.GetComponent<CharacterController>();
            tempCC.enabled = false;
            lostScreen.SetActive(true);
            restartBtn.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerCar")
        {
            follow = false;
            CharacterController tempCC = playerCar.GetComponent<CharacterController>();
            tempCC.enabled = false;
            lostScreen.SetActive(true);
            restartBtn.SetActive(true);
        }
    }

    void Update()
    {
        if (follow)
        {
            if (aliveTime >= timeToLive)
            {
                this.gameObject.SetActive(false);
                aliveTime = 0;
            }

            transform.LookAt(playerCar.transform.position);

            transform.position += transform.forward * spd * Time.deltaTime;

            aliveTime++;
        }
    }
}
