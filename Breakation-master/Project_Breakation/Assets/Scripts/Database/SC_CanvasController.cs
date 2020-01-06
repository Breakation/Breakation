using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CanvasController : MonoBehaviour
{
    public static float canvasWidth;
    public static float canvasHeight;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();
        //Debug.Log("width: " + objectRectTransform.rect.width + ", height: " + objectRectTransform.rect.height);
        canvasWidth = objectRectTransform.rect.width;
        canvasHeight = objectRectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
