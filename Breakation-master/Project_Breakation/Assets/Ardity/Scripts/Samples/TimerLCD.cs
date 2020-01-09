using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLCD : MonoBehaviour
{
    public static int timeStart = 7665;
    float elapsed = 0f;
    public bool countdownzero = false;
    public static string temptime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed  += Time.deltaTime;
        if(elapsed >= 1f){
            elapsed = elapsed % 1f;
            if(timeStart % 1000 == 0){
                timeStart += -1000 + 959;
            } else if(timeStart % 100 == 0){
                timeStart += -100 + 59;
            } else { timeStart--;
            }
            //Debug.Log(timeStart);
            if(timeStart > 999) {
                temptime = "T-" + timeStart.ToString();
                SampleUserPolling_ReadWrite.timercd = true;
            }
            if(timeStart == 0){
                Debug.Log("loose");
                countdownzero = true;
            }
        }
    }
}
