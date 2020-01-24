using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ledbrumm : MonoBehaviour
{
     int ledcount = 0;
    // Start is called before the first frame update
    void Start()
    {
    ledcount = 0;
        
    }

    // Update is called once per frame
    void Update()

    {
if ( ledcount == 0){

    SampleUserPolling_ReadWrite.sendtext = "L-1T";

}

if ( ledcount == 100){
    SampleUserPolling_ReadWrite.sendtext = "L-2F";
}

if ( ledcount == 200){
    SampleUserPolling_ReadWrite.sendtext = "L-3F";
}

if ( ledcount == 300){
    SampleUserPolling_ReadWrite.sendtext = "L-4T";


    }
    ledcount++;
    }

}
