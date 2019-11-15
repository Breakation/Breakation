using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_dummy : MonoBehaviour
{
    public float speed = 6.0F;
    
    

    // Update is called once per frame
    void FixedUpdate()
    {


        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0F, Input.GetAxis("Vertical") * speed* Time.deltaTime);
    }
}
