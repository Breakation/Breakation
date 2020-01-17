using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLostCanvasContr : MonoBehaviour
{
    public GameObject lostScreen;
    public GameObject restartBtn;

    public GameObject car;
    public GameObject startPoint;
    public GameObject enemyCar;

    public void restartCar()
    {
        lostScreen.SetActive(false);
        restartBtn.SetActive(false);

        CharacterController tempCC = car.GetComponent<CharacterController>();
        tempCC.enabled = false;
        car.transform.position = startPoint.transform.position;
        tempCC.enabled = true;
        sc_enemyCarMove.spd = 1;
        enemyCar.SetActive(false);
        sc_enemyCarMove.aliveTime = 0;

    }
}
