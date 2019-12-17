using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_uiController : MonoBehaviour
{
    public GameObject mixUI;
    public GameObject divUI;

    public void toDivide()
    {
        divUI.SetActive(true);
        mixUI.SetActive(false);
    }

    public void toMix()
    {
        divUI.SetActive(false);
        mixUI.SetActive(true);
    }
}
