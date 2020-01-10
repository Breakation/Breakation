using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Zoomable : MonoBehaviour
{

    public bool isCopy = false;
    public GameObject zoomContr;
     SC_ZoomController zoomScr;
    public string prefabName;

    public int rotationNmbr;

    public string objType;

    // Start is called before the first frame update
    void Start()
    {
        zoomScr = zoomContr.GetComponent<SC_ZoomController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!isCopy)
        {
            zoomScr.zoomIn(prefabName,objType);
        }
        
    }
}
