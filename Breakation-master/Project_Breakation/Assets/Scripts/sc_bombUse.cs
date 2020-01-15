using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_bombUse : MonoBehaviour
{
    public GameObject mixerObj;
    public GameObject steinObj;

    private void OnMouseDown()
    {
        bombStone();
    }

    public void bombStone()
    {
        steinObj.SetActive(false);
    }
}
