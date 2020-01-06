using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_staticPatrol : MonoBehaviour
{
    public GameObject mySelf;
    private bool isAwake = false;

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;
    private int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        randomSpot = Random.Range(0, moveSpots.Length);

        counter = 0;

        var tempScript = mySelf.GetComponent<EnemyScr>();
        isAwake = tempScript.isAwake;
    }

    // Update is called once per frame
    void Update()
    {
        var tempScript = mySelf.GetComponent<EnemyScr>();
        isAwake = tempScript.isAwake;

        if (isAwake)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[counter].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveSpots[counter].position) < 0.2f)
            {
                if (waitTime <= 0)
                {

                    counter++;

                    if (counter >= moveSpots.Length)
                    {
                        counter = 0;
                    }

                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }



            }

            Vector3 direction = moveSpots[counter].position - transform.position;

        }


    }
}
