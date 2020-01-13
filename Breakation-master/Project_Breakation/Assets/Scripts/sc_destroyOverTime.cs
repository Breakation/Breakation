using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  this script removes objects from the world after a certain amount of time
     */
public class sc_destroyOverTime : MonoBehaviour
{

    public float lifetime; // we give it a life time a little bit longer than our pick ArrowUp effect would last!

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
        Destroy(gameObject, lifetime);
        /*lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(gameObject);
        }*/
    }
}
