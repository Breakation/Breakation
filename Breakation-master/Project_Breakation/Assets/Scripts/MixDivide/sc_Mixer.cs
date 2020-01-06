using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_Mixer : MonoBehaviour
{
    // 0=hd 1=hq 2=hw 3=hy 4=hl
    private bool[] fluids = new bool[5];

    // 0=of 1=oa 2=ol 3=oz 4=op 5=ot
    private bool[] gasses = new bool[6];

    // 0=ft 1=ff 2=fq 3=fh 4=fs 5=fy 6=fz
    private bool[] solids = new bool[7];


    private string[] possibleCombs = { "34*24", "23*13", "12*22","33*11","12*25","11*30","31*25","14*32","36*21", "13*22" };
    private string[] possibleDivs = { "10#" ,"20#", "35#", "11#", "30#", "31#","25#", "36#", "21#", "14#", "32#"};


    public GameObject firstSubField;
    public GameObject secondSubField;
    public GameObject firstTypeField;
    public GameObject secondTypeField;

    public GameObject subField;
    public GameObject typeField;

    public GameObject flaskPrefab;


    // Start is called before the first frame update
    void Start()
    {
        fluids[0] = false;
        fluids[1] = false;
        fluids[2] = false;
        fluids[3] = false;
        fluids[4] = false;

        gasses[0] = false;
        gasses[1] = false;
        gasses[2] = true;
        gasses[3] = false;
        gasses[4] = true;
        gasses[5] = false;

        solids[0] = true;
        solids[1] = true;
        solids[2] = false;
        solids[3] = true;
        solids[4] = true;
        solids[5] = false;
        solids[6] = false;
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
        string tempType = typeField.GetComponent<InputField>().text;
        int tempSub = int.Parse(subField.GetComponent<InputField>().text);

        divProcess(tempSub, tempType);
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
                                    fluids[0] = true;
                                    Instantiate(flaskPrefab, new Vector3(-4.74f, 1.684f, -7.09f),Quaternion.Euler(0,90,0));
                                }
                                else if ((secondType == "solid") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // => FQ
                                    solids[2] = true;
                                    Instantiate(flaskPrefab, new Vector3(3.67f, 1.684f, -7.09f), Quaternion.Euler(0, 90, 0));
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
                                    fluids[4] = true;
                                    Instantiate(flaskPrefab, new Vector3(-3.78f, 0.65f, -7.09f), Quaternion.Euler(0, 90, 0));
                                }
                                else if ((secondType == "gas") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // ot?
                                    gasses[5] = true;
                                    Instantiate(flaskPrefab, new Vector3(0.12f, 0.65f, -7.09f), Quaternion.Euler(0, 90, 0));
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
                                    solids[1] = true;
                                    Instantiate(flaskPrefab, new Vector3(0.12f, 0.65f, -7.09f), Quaternion.Euler(0, 90, 0));
                                }
                                else if ((secondType == "gas") && (secondSubs == 2))
                                {
                                    Debug.Log("Mix");
                                    // => OA
                                    gasses[1] = true;
                                    Instantiate(flaskPrefab, new Vector3(0.12f, 0.65f, -7.09f), Quaternion.Euler(0, 90, 0));
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                    Instantiate(flaskPrefab, new Vector3(0.12f, 0.65f, -7.09f), Quaternion.Euler(0, 90, 0));
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
                                    solids[6] = true;
                                    Instantiate(flaskPrefab, new Vector3(0.12f, 0.65f, -7.09f), Quaternion.Euler(0, 90, 0));
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
                                    solids[5] = true;

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
                                    fluids[4] = true;
                                }
                                if ((secondType == "fluid") && (secondSubs == 3))
                                {
                                    Debug.Log("Mix");
                                    // => OA
                                    gasses[1] = true;
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
                                    solids[1] = true;
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
                                    fluids[1] = true;
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
                                    fluids[0] = true;
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
                                    gasses[0] = true;
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
                                    solids[6] = true;
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
                                    solids[2] = true;
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
                                    fluids[1] = true;
                                }
                            }
                            break;
                        case 6:
                            {
                                // FZ

                                if((secondType == "gas")&& (secondSubs == 1))
                                {
                                    Debug.Log("Mix");
                                    // => FY
                                }
                            }break;
                        default:
                            {
                                Debug.Log("Fail");
                            }break;
                    }
                }
                break;
        }
    }

    private void divProcess(int sub, string stype)
    {
        switch (stype)
        {
            case "fluid":
                {
                    switch (sub)
                    {
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case 0:
                            {
                                Debug.Log("Got HQ & FT");
                                fluids[1] = true;
                                solids[0] = true;
                            }break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case 1:
                            {
                                Debug.Log("Got FS & OP");
                                solids[4] = true;
                                gasses[4] = true;
                            }
                            break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case 2:
                            {
                                Debug.Log("Got None");

                            }
                            break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case 3:
                            {
                                Debug.Log("Got None");
                            }break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case 4:
                            {
                                Debug.Log("Got HW & OL");
                                fluids[2] = true;
                                gasses[2] = true;
                            }
                            break;
                        default:
                            {
                                Debug.Log("False Sub");
                            }break;

                    }
                }
                break;
            case "gas":
                {
                    switch (sub)
                    {
                        // 0=of 1=oa 2=ol 3=oz 4=op 5=ot
                        case 0:
                            {
                                Debug.Log("Got FF & OT");
                                solids[1] = true;
                                gasses[5] = true;
                            }
                            break;
                        case 1:
                            {
                                Debug.Log("Got HW & OT");
                                fluids[2] = true;
                                gasses[5] = true;
                            }
                            break;
                        case 2:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case 3:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case 4:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case 5:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        default:
                            {
                                Debug.Log("False Sub");
                            }
                            break;

                    }
                }
                break;
            case "solid":
                {
                    switch (sub)
                    {
                        // 0=ft 1=ff 2=fq 3=fh 4=fs 5=fy
                        case 0:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case 1:
                            {
                                Debug.Log("Got OZ & HY");
                                gasses[3] = true;
                                fluids[3] = true;
                            }
                            break;
                        case 2:
                            {
                                Debug.Log("Got FH & HQ");
                                solids[3] = true;
                                fluids[1] = true;
                            }
                            break;
                        case 3:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case 4:
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case 5:
                            {
                                Debug.Log("Got FZ & OA");
                                solids[6] = true;
                                gasses[1] = true;
                            }
                            break;
                        case 6:
                            {
                                Debug.Log("Got HL & FQ");
                                fluids[4] = true;
                                solids[2] = true;
                            }break;
                        default:
                            {
                                Debug.Log("False Sub");
                            }
                            break;
                    }
                }break;
            default:
                {
                    Debug.Log("False Type");
                }break;
        }
    }
}
