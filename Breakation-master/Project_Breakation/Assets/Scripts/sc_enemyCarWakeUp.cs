using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_enemyCarWakeUp : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject enemyCar;
    public GameObject myStartPoint;



    private void Start()
    {
        playerCar = GameObject.FindGameObjectWithTag("PlayerCar");
        enemyCar = GameObject.FindGameObjectWithTag("EnemyCar");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("startWake");

        if (collision.gameObject.tag == "PlayerCar")
        {
            Debug.Log("Wake");
            enemyCar.transform.position = myStartPoint.transform.position;
            sc_enemyCarMove.spd++;
            sc_enemyCarMove.aliveTime = 0;
            enemyCar.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "PlayerCar")
        {
            enemyCar.transform.position = myStartPoint.transform.position;
            sc_enemyCarMove.spd++;
            sc_enemyCarMove.aliveTime = 0;
            enemyCar.SetActive(true);
            
        }
    }


}
