using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Tresor : MonoBehaviour

{
    public bool allLocksOpen = false; // Animator variable einsetzen

    public sc_Lock[] Locks = new sc_Lock[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Locks[0].open && Locks[1].open && Locks[2].open && Locks[3].open)
        {
            allLocksOpen = true;
        }
        
    }
}
