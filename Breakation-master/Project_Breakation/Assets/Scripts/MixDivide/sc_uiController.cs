using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_uiController : MonoBehaviour
{
    public GameObject mixUI;
    public GameObject divUI;
    public static bool activateMixDivUI = false;
    private bool uiActivated = false;

    private void Update()
    {
        if (!uiActivated)
        {
            if (activateMixDivUI)
            {
                mixUI.SetActive(true);
                uiActivated = true;
            }
        }
    }

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
