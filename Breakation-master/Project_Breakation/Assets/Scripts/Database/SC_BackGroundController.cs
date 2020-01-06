using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BackGroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();
        objectRectTransform.rect.Set(0, 0, SC_CanvasController.canvasWidth, SC_CanvasController.canvasHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
