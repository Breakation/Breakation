using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_brummCarDeath : MonoBehaviour
{
    public GameObject car;
    public GameObject enemyCar;
    public GameObject startPoint;
    

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("die");
        if(other.tag == "PlayerCar")
        {
            CharacterController tempCC = car.GetComponent<CharacterController>();
            tempCC.enabled = false;
            car.transform.position = startPoint.transform.position;
            tempCC.enabled = true;
            sc_enemyCarMove.spd = 1;
            enemyCar.SetActive(false);
            sc_enemyCarMove.aliveTime = 0;
            sc_enemyCarMove.follow = true;
        }
    }
}
