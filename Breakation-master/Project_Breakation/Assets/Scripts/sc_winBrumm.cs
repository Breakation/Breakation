﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_winBrumm : MonoBehaviour
{
    public GameObject player;
    public GameObject winCanvas;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCar");
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yeah!");
        winCanvas.SetActive(true);
    }
}
