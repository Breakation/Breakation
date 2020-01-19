using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_WakeUp : MonoBehaviour
{

    public GameObject[] wakeUpTargets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Trigger")
        {
            for (int i = 0; i < wakeUpTargets.Length; i++)
            {
                var tempScript = wakeUpTargets[i].GetComponent<EnemyScr>();
                tempScript.isAwake = true;
                //var tempScriptShot = wakeUpTargets[i].GetComponent<sc_EnemyShot>();
                //tempScriptShot.isAwake = true;
                
            }
        }
    }

}
