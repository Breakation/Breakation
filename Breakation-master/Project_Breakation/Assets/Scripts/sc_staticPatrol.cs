﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_staticPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;
    private int counter = 0;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        randomSpot = Random.Range(0, moveSpots.Length);

        counter = 0;

        anim = this.gameObject.GetComponentInChildren<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, moveSpots[counter].position, speed * Time.deltaTime);

        

        if(Vector3.Distance(transform.position, moveSpots[counter].position) < 0.2f){
            if(waitTime <= 0)
            {
                if (!anim.GetBool("enemy_walk"))
                {
                    anim.SetBool("enemy_walk", true);
                }
                counter++;

                if(counter >= moveSpots.Length)
                {
                    counter = 0;
                }
                Vector3 direction = moveSpots[counter].position - transform.position;

                Quaternion rotation = Quaternion.LookRotation(direction);

                transform.rotation = rotation;
                waitTime = startWaitTime;

          
            }
            else
            {
                anim.SetBool("enemy_walk", false);
                waitTime -= Time.deltaTime;

               
            }



        }

        
        


    }
}
