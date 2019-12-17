using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_Mixer : MonoBehaviour
{
    // 0=hd 1=hq 2=hw 3=hy 4=hl
    private bool[] fluids = new bool[5];

    // 0=of 1=oa 2=ol 3=oz 4=op
    private bool[] gasses = new bool[5];

    // 0=ft 1=ff 2=fq 3=fh 4=fs
    private bool[] solids = new bool[5];

    public GameObject firstSubField;
    public GameObject secondSubField;
    public GameObject firstTypeField;
    public GameObject secondTypeField;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startMix()
    {
        string tempFirstT = firstTypeField.GetComponent<InputField>().text;
        string tempSecT = secondTypeField.GetComponent<InputField>().text;
        int tempFirstS = int.Parse(firstSubField.GetComponent<InputField>().text);
        int tempSecondS = int.Parse(secondSubField.GetComponent<InputField>().text);

        mixProcess(tempFirstS, tempFirstT, tempSecondS, tempSecT);
    }

    public void startDivide()
    {

    }


    private  void mixProcess(int firstSubs,string firstType, int secondSubs,string secondType)
    {
        switch (firstType){
            case "fluid":
                {
                    // 0=hd 1=hq 2=hw 3=hy 4=hl
                    switch (firstSubs)
                    {
                        case 1:
                            {
                                // HQ

                                if((secondType == "solid") && (secondSubs == 0))
                                {
                                    Debug.Log("Mix");
                                    // => HD
                                }
                                else if ((secondType == "solid") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // => FG
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                        case 2:
                            {
                                // HW

                                if ((secondType == "gas") && (secondSubs == 2))
                                {
                                    Debug.Log("Mix");
                                    // => HL
                                }
                                else if ((secondType == "gas") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // ot?
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                        case 3:
                            {
                                // HY

                                if ((secondType == "gas") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // => FF
                                }
                                else if ((secondType == "gas") && (secondSubs == 2))
                                {
                                    Debug.Log("Mix");
                                    // => OA
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                        case 4:
                            {
                                // HL

                                if ((secondType == "solid") && (secondSubs == 2))
                                {
                                    Debug.Log("Mix");
                                    // => FZ ?
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                        default:
                            {
                                Debug.Log("Fail");
                            }
                            break;

                    }
                }break;
            case "gas":
                {
                    // 0=of 1=oa 2=ol 3=oz 4=op
                    switch (firstSubs)
                    {

                        case 1:
                            {
                                // OA

                                if ((secondType == "solid") && (secondSubs == 4))
                                {
                                    // fz?
                                    Debug.Log("Mix");
                                    // => FY
                                }


                            }
                            break;
                        case 2:
                            {
                                // OL

                                if ((secondType == "fluid") && (secondSubs == 2))
                                {
                                    Debug.Log("Mix");
                                    // => HL
                                }
                                if ((secondType == "fluid") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // => OA
                                }
                            }
                            break;
                        case 3:
                            {
                                // OZ

                                if ((secondType == "fluid") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // => FF
                                }
                            }
                            break;
                        case 4:
                            {
                                // OP

                                if ((secondType == "solid") && (secondSubs == 4))
                                {
                                    Debug.Log("Mix");
                                    // => HQ
                                }
                            }
                            break;
                        default:
                            {
                                Debug.Log("Fail");
                            }
                            break;
                    }
                }
                break;
            case "solid":
                {
                    // 0=ft 1=ff 2=fq 3=fh 4=fs
                    switch (firstSubs)
                    {
                        case 0:
                            {
                                // FT

                                if ((secondType == "fluid") && (secondSubs == 1))
                                {
                                    Debug.Log("Mix");
                                    // => HD
                                }
                            }
                            break;
                        case 1:
                            {
                                // FF

                                if ((secondType == "gas") && (secondSubs == 0))
                                {
                                    // OT?
                                    Debug.Log("Mix");
                                    // => OF
                                }
                            }
                            break;
                        case 2:
                            {
                                // FQ

                                if ((secondType == "fluid") && (secondSubs == 4))
                                {
                                    Debug.Log("Mix");
                                    // => FZ
                                }
                            }
                            break;
                        case 3:
                            {
                                // FH

                                if ((secondType == "fluid") && (secondSubs == 1))
                                {
                                    Debug.Log("Mix");
                                    // => FQ
                                }
                            }
                            break;
                        case 4:
                            {
                                // FS

                                if ((secondType == "gas") && (secondSubs == 4))
                                {
                                    Debug.Log("Mix");
                                    // => HQ
                                }
                            }
                            break;
                        default:
                            {
                                Debug.Log("Fail");
                            }break;
                    }
                }
                break;
        }
    }

    private void divProcess()
    {

    }
}
