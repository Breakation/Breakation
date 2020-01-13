using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Lock : MonoBehaviour
{
    public bool open = false;
    public int target;
    public int targetInput;
    public int[] input;
    public Material right, wrong;
    MeshRenderer ren;
    


    void Start()
    {
        ren = this.gameObject.GetComponent<MeshRenderer>();
        ren.material = wrong;
        input = new int[4];
        target = Random.Range(10, 64);
       
        

    }

    // Update is called once per frame
    void Update()
    {

        input[0] = SampleUserPolling_ReadWrite.pot1value;
        input[1] = SampleUserPolling_ReadWrite.pot2value;
        input[2] = SampleUserPolling_ReadWrite.pot3value;
        input[3] = SampleUserPolling_ReadWrite.pot4value;

        switch (targetInput)
        {
            case 0:
                if (open && (input[0] < target-1 || input[0] > target+1))
                {
                    target = Random.Range(10, 64);
                }
                if (input[0] == target)
                {
                    open = true;
                    ren.material = right;
                }
                else
                {
                    if ((input[0] < target - 1 || input[0] > target + 1))
                    {
                        open = false;
                        ren.material = wrong;
                    }
                } break;

            case 1:
                if (open && (input[1] < target - 1 || input[1] > target + 1))
                {
                    target = Random.Range(10, 64);
                }
                if (input[1] == target)
                {
                    open = true;
                    ren.material = right;
                }
                else
                {
                    if ((input[1] < target - 1 || input[1] > target + 1))
                    {
                        open = false;
                        ren.material = wrong;
                    }
                }
                break;

            case 2:
                if (open && (input[2] < target - 1 || input[2] > target + 1))
                {
                    target = Random.Range(10, 64);
                }
                if (input[2] == target)
                {
                    open = true;
                    ren.material = right;
                }
                else
                {
                    if ((input[2] < target - 1 || input[2] > target + 1))
                    {
                        open = false;
                        ren.material = wrong;
                    }
                }
                break;

            case 3:
                if (open && (input[3] < target - 1 || input[3] > target + 1))
                {
                    target = Random.Range(10, 64);
                }
                if (input[3] == target)
                {
                    open = true;
                    ren.material = right;
                }
                else
                {
                    if ((input[3] < target - 1 || input[3] > target + 1))
                    {
                        open = false;
                        ren.material = wrong;
                    }
                }
                break;
        }

    }
}
