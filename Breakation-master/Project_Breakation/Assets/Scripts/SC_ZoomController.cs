using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ZoomController : MonoBehaviour
{

    public GameObject maincamera;
    public Vector3 distToCam = new Vector3(0, -2, 2);

    private GameObject tempCopy;

    public GameObject[] zoomableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void zoomIn(string prefabName)
    {
        Vector3 tempPos = maincamera.transform.position;
        Vector3 newPos = tempPos + distToCam;
        Vector3 RotationAdd = new Vector3(0, 180, 0);
        Vector3 nullRot = new Vector3(0, 0, 0);
        Debug.Log("Click");

        tempCopy = PhotonNetwork.Instantiate(prefabName, tempPos, maincamera.transform.rotation);
        SC_Zoomable tempscript = tempCopy.GetComponent<SC_Zoomable>();

        tempscript.isCopy = true;

        tempCopy.transform.Rotate(new Vector3(0, 180, 0));
    }
}
