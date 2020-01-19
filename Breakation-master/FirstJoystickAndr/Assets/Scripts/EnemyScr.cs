using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{

    public bool isAwake = false;

    public int enemyLp;


    public string type;
    public int hp = 10;
    public GameObject player;
    public float movementSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        enemyLp = 3;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(enemyLp<= 0)
        {
            sc_winCondtion.enmyCount--;
            Destroy(this.gameObject);
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    isAwake = true;
        //}


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
