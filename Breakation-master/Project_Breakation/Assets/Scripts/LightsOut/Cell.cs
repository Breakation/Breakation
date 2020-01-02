/* LÖSCHEN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // diese Klasse ist für unseren Behälter; hier werden Funktionen wie z.B. Türschließen hinkommen
    public bool special, closable;
    public CellController cellController;
    // Start is called before the first frame update
    void Start()
    {
        Cell[] arrayOfObjects = GameObject.FindObjectsOfType<Cell>();
        Debug.Log(arrayOfObjects.Length);
    }
    private void OnEnable()
    {
        Cell[] arrayOfObjects = GameObject.FindObjectsOfType<Cell>();
        Debug.Log(arrayOfObjects.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
LÖSCHEN */