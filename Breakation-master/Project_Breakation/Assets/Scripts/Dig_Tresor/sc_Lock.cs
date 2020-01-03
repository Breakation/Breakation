using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Lock : MonoBehaviour
{
    public bool open = false;
    public int target;
    public int targetInput;
    public int[] input;
    
    
    void Start()
    {
        input = new int[4];
        target = Random.Range(0, 64);

    }

    // Update is called once per frame
    void Update()
    {

        input[0] = input[0];
        input[1] = input[1];
        input[2] = input[2];
        input[3] = input[3];

        switch (targetInput)
        {
            case 0:
                if (open && input[0] != target)
                {
                    target = Random.Range(0, 64);
                }
                if (input[0] == target)
                {
                    open = true;
                }
                else
                {
                    open = false;
                } break;

            case 1:
                if (open && input[1] != target)
                {
                    target = Random.Range(0, 64);
                }
                if (input[1] == target)
                {
                    open = true;
                }
                else
                {
                    open = false;
                }
                break;

            case 2:
                if (open && input[2] != target)
                {
                    target = Random.Range(0, 64);
                }
                if (input[2] == target)
                {
                    open = true;
                }
                else
                {
                    open = false;
                }
                break;

            case 3:
                if (open && input[3] != target)
                {
                    target = Random.Range(0, 64);
                }
                if (input[3] == target)
                {
                    open = true;
                }
                else
                {
                    open = false;
                }
                break;
        }

    }
}
