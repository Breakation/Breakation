using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Jedes Objekt hat einen "transform", die Position des Objekts in der Welt
    public Transform target;//Position des Spielers
    public Transform pivot;
    //Variable für den Abstand zwischen Spieler/Pivot und Camera
    public Vector3 offset;

    public bool useOffsetValues;
    public float rotateSpeed;


    //for limiting the camera
    public float maxViewAngle, minViewAngle;

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    { 

        if(!useOffsetValues){
        // Spielerposition - Cameraposition
        offset = target.position - transform.position;
        }
        //der Pivot hat die gleiche Position wie der Spieler
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        //locks the cursor of the mouse to the center of the window (Cursur verschwindet)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //der Pivot bewegt sich mit dem Spieler mit,
        pivot.transform.position = target.transform.position;

        // x position der Mouse holen und mit dem Pivot rotatieren 
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        //y position der Mouse holen und mit dem Pivot rotatieren 
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        //Rotation der Camera abhängig von dem Pivot
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }


        //limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < (360f + minViewAngle))
        {
            pivot.rotation = Quaternion.Euler((360f + minViewAngle), 0, 0);
        }

        //Camera anhand der Pivot-Rotation und der original offset bewegen
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //Camera daran hindern durch den Boden zu gehen!
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f , transform.position.z);
        }
       transform.LookAt(target);
        
    }
}
