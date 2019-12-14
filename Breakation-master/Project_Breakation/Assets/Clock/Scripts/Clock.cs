using UnityEngine;
using System.Collections;
using Photon.Pun;

public class Clock : MonoBehaviourPun, IPunObservable {
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
    //
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------

    //-- set start time 00:00

    private bool copyCreated = false;
    public bool isCopy = false;


    GameObject tempClock;
    GameObject creator;
    Clock creatorScript;

    public GameObject maincamera;
    public Vector3 distToCam = new Vector3(0,-2,2);

    public GameObject clockPrefab;

    Ray ray;
    RaycastHit raycasthit;

    public int minutes = 0;
    public int hour = 0;
    private bool timeChanged = false;
    private PhotonView pv;
    
    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting && timeChanged)
        //{
        //    stream.SendNext(seconds);
        //    stream.SendNext(minutes);
        //    stream.SendNext(hour);
        //    Debug.Log("TestW");
        //    timeChanged = false;
        //}
        //else if(stream.IsReading)
        //{
        //    this.seconds = (int)stream.ReceiveNext();
        //    this.minutes = (int)stream.ReceiveNext();
        //    this.hour = (int)stream.ReceiveNext();
        //    Debug.Log("TestR");
        //}
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    void Start() 
{
        pv = GetComponent<PhotonView>();

    pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
    pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
    pointerHours   = transform.Find("rotation_axis_pointer_hour").gameObject;

    msecs = 0.0f;
        if (!isCopy)
        {
            seconds = 0;
        }
    
}
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && UhrzeitTuerController.clockHacked)
        {
            minutes++;
            if (minutes >= 60)
            {
                minutes = 0;
                hour++;
                if (hour >= 24)
                    hour = 0;
            }
            timeChanged = true;
            pv.RPC("RPC_SyncTime", RpcTarget.AllBuffered, minutes, hour);
            
        }
    
        

    //-- calculate time
    msecs += Time.deltaTime * clockSpeed;
    if(msecs >= 1.0f)
    {
        msecs -= 1.0f;
        seconds++;
        if(seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;
            }
        }
    }


    //-- calculate pointer angles
    float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

        if(hour >= 12)
        {
            OpenerWithUhr.op_triggered = true;
        }
}

    [PunRPC]
    void RPC_SyncTime(int syncMin, int syncHour)
    {
        minutes = syncMin;
        hour = syncHour;
        Debug.Log("sync succesfull");
    }
    
    public void changeSeconds(int pSeconds)
    {
        seconds = pSeconds;
    }

    private void OnMouseDown()
    {
        if (!isCopy)
        {
            Debug.Log(tempClock);
            if (!copyCreated)
            {
                Vector3 tempPos = maincamera.transform.position;
                Vector3 newPos = tempPos + distToCam;
                Vector3 RotationAdd = new Vector3(-45, 180, 0);
                Debug.Log("Click");
                Debug.Log(tempPos);
                Debug.Log(newPos);
                tempClock = Instantiate(clockPrefab, newPos, Quaternion.identity);
                Clock tempScript = tempClock.GetComponent<Clock>();
                tempScript.changeSeconds(seconds);
                tempScript.minutes = minutes;
                tempScript.hour = hour;
                tempScript.isCopy = true;
                tempScript.creator = this.gameObject;
                tempScript.creatorScript = tempScript.creator.GetComponent<Clock>();


                tempClock.transform.Rotate(RotationAdd);
                copyCreated = true;
            }
            
            
        }
        else {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycasthit))
            {
                creatorScript.copyCreated = false;
                Object.Destroy(this.gameObject);
            }
           
        }

    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
}
