using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_uiConter : MonoBehaviour
{
    public GameObject lpUI;
    public Text lpTxt;

    private void Start()
    {
        lpTxt = lpUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lpTxt.text = PlayerControlls.lp.ToString();
    }
}
