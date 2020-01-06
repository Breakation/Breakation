using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{

    public bool isAwake = false;
    

    public string type;
    public int hp = 10;
    public GameObject player;
    public float movementSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isAwake = true;
        }


        if (isAwake)
        {
            if (type == "tower")
            {

                transform.Rotate(new Vector3(0, 0.5f, 0));
            }

            if (type == "patrolEnemy")
            {
                transform.LookAt(player.transform);
            }

            if (type == "follow")
            {
                transform.LookAt(player.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;

            }
        }
    }
}
