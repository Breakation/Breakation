using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_enemyCarWakeUp : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject enemyCar;
    public GameObject myStartPoint;

   


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerCar")
        {
            enemyCar.transform.position = myStartPoint.transform.position;
            sc_enemyCarMove.spd++;
            sc_enemyCarMove.aliveTime = 0;
            enemyCar.SetActive(true);
            
        }
    }


}
