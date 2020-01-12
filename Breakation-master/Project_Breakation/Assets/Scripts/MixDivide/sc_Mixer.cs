using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_Mixer : MonoBehaviourPun, IPunObservable
{
    private PhotonView pv;

    public GameObject dispObj;
    private DispOpener dispOpen;

    // 0=hd 1=hq 2=hw 3=hy 4=hl
    public bool[] fluids = new bool[5];

    // 0=of 1=oa 2=ol 3=oz 4=op 5=ot
    public bool[] gasses = new bool[6];

    // 0=ft 1=ff 2=fq 3=fh 4=fs 5=fy 6=fz
    public bool[] solids = new bool[7];


    private string[] possibleCombs = { "34*24", "23*13", "12*22","33*11","12*25","11*30","31*25","14*32","36*21", "13*22", "24*34", "13*23" , "22*12", "11*33", "25*12", "30*11" , "25*31" , "32*14", "21*36" , "22*13" };
    private string[] possibleDivs = { "10#" ,"20#", "35#", "11#", "30#", "31#","25#", "36#", "21#", "14#", "32#"};

    private string[] finalComb = { "HD*OF*FY", "HD*FY*OF", "OF*HD*FY", "OF*FY*HD", "FY*HD*OF", "FY*OF*HD"};


    private char firstType;
    private char firstSub;
    private char secType;
    private char secSub;

    public GameObject steinObj;


    public GameObject firstSubField;
    public GameObject secondSubField;
    public GameObject firstTypeField;
    public GameObject secondTypeField;

    public GameObject subField;
    public GameObject typeField;

    public GameObject flaskPrefab;

    public GameObject FTflask;
    public GameObject FFflask;
    public GameObject FQflask;
    public GameObject FHflask;
    public GameObject FSflask;
    public GameObject FYflask;
    public GameObject FZflask;


    public GameObject HDflask;
    public GameObject HQflask;
    public GameObject HWflask;
    public GameObject HYflask;
    public GameObject HLflask;

    public GameObject OFflask;
    public GameObject OAflask;
    public GameObject OLflask;
    public GameObject OZflask;
    public GameObject OPflask;
    public GameObject OTflask;


    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        dispOpen = dispObj.GetComponent<DispOpener>();


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
        if (fluids[0])
        {
            HDflask.SetActive(true);
        }
        if (fluids[1])
        {
            HQflask.SetActive(true);
        }
        if (fluids[2])
        {
            HWflask.SetActive(true);
        }
        if (fluids[3])
        {
            HYflask.SetActive(true);
        }
        if (fluids[4])
        {
            HLflask.SetActive(true);
        }
        if (gasses[0])
        {
            OFflask.SetActive(true);
        }
        if (gasses[1])
        {
            OAflask.SetActive(true);
        }
        if (gasses[2])
        {
            OLflask.SetActive(true);
        }
        if (gasses[3])
        {
            OZflask.SetActive(true);
        }
        if (gasses[4])
        {
            OPflask.SetActive(true);
        }
        if (gasses[5])
        {
            OTflask.SetActive(true);
        }
        if (solids[0])
        {
            FTflask.SetActive(true);
        }
        if (solids[1])
        {
            FFflask.SetActive(true);
        }
        if (solids[2])
        {
            FQflask.SetActive(true);
        }
        if (solids[3])
        {
            FHflask.SetActive(true);
        }
        if (solids[4])
        {
            FSflask.SetActive(true);
        }
        if (solids[5])
        {
            FYflask.SetActive(true);
        }
        if (solids[6])
        {
            FZflask.SetActive(true);
        }
        if (testkeypad.teststring.Length == 3)
        {
            for (int i = 0; i < possibleDivs.Length; i++)
            {
                if(testkeypad.teststring == possibleDivs[i])
                {
                    firstType = possibleDivs[i][0];
                    firstSub = possibleDivs[i][1];
                    Debug.Log("start divide" + firstType + "  " + firstSub);


                    switch (firstType)
                    {
                        case '1':
                            {
                                if (fluids[(int)Char.GetNumericValue(firstSub)])
                                {
                                    divProcess(firstSub, firstType);
                                }
                            }break;
                        case '2':
                            {
                                if (gasses[(int)Char.GetNumericValue(firstSub)])
                                {
                                    divProcess(firstSub, firstType);
                                }
                            }break;
                        case '3':
                            {
                                if (solids[(int)Char.GetNumericValue(firstSub)])
                                {
                                    divProcess(firstSub, firstType);
                                }
                            }break;
                        default:
                            {
                                Debug.Log("Falsche Eigabe");
                            }break;
                    }

                    

                    testkeypad.teststring = "";
                }
            }
        }

        if(testkeypad.teststring.Length == 5)
        {
            for (int i = 0; i < possibleCombs.Length; i++)
            {
                if(testkeypad.teststring == possibleCombs[i])
                {
                    firstType = possibleCombs[i][0];
                    firstSub = possibleCombs[i][1];

                    secType = possibleCombs[i][3];
                    secSub = possibleCombs[i][4];

                    

                    switch (firstType)
                    {
                        case '1':
                            {
                                if (fluids[(int)Char.GetNumericValue(firstSub)])
                                {
                                    switch (secType)
                                    {
                                        case '1':
                                            {
                                                if (fluids[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        case '2':
                                            {
                                                if (gasses[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                if (solids[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                Debug.Log("Falsche Eigabe");
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        case '2':
                            {
                                if (gasses[(int)Char.GetNumericValue(firstSub)])
                                {
                                    switch (secType)
                                    {
                                        case '1':
                                            {
                                                if (fluids[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        case '2':
                                            {
                                                if (gasses[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                if (solids[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                Debug.Log("Falsche Eigabe");
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        case '3':
                            {
                                if (solids[(int)Char.GetNumericValue(firstSub)])
                                {
                                    switch (secType)
                                    {
                                        case '1':
                                            {
                                                if (fluids[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        case '2':
                                            {
                                                if (gasses[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                if (solids[(int)Char.GetNumericValue(secSub)])
                                                {
                                                    mixProcess(firstSub, firstType, secSub, secType);
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                Debug.Log("Falsche Eigabe");
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        default:
                            {
                                Debug.Log("Falsche Eigabe");
                            }
                            break;
                    }



                    testkeypad.teststring = "";
                }
            }
        }

        if(testkeypad.teststring.Length == 8)
        {
            if(fluids[0] && gasses[0] && solids[5])
            {
                Debug.Log("final MIX");

                dispOpen.trigger = true;

                // benutze dispenser um bombe auszugeben

            }
           

        }

        if (Input.GetKey(KeyCode.Space))
        {
            bombStone();
           
        }


        pv.RPC("RPC_syncShelf", RpcTarget.AllBuffered, fluids, gasses, solids, dispOpen.trigger);
    }


    public void startMix()
    {
        //string tempFirstT = firstTypeField.GetComponent<InputField>().text;
        //string tempSecT = secondTypeField.GetComponent<InputField>().text;
        //int tempFirstS = int.Parse(firstSubField.GetComponent<InputField>().text);
        //int tempSecondS = int.Parse(secondSubField.GetComponent<InputField>().text);

        

        //mixProcess(tempFirstS, tempFirstT, tempSecondS, tempSecT);
    }

    public void startDivide()
    {
        //string tempType = typeField.GetComponent<InputField>().text;
        //int tempSub = int.Parse(subField.GetComponent<InputField>().text);

        //divProcess(tempSub, tempType);
    }


    private  void mixProcess(char firstSubs,char firstType, char secondSubs,char secondType)
    {
        switch (firstType){
            case '1':
                {
                    // 0=hd 1=hq 2=hw 3=hy 4=hl
                    switch (firstSubs)
                    {
                        case '1':
                            {
                                // HQ

                                if((secondType == '3') && (secondSubs == '0'))
                                {
                                    Debug.Log("Mix");
                                    // => HD
                                    fluids[0] = true;
                                    HDflask.SetActive(true);
                                }
                                else if ((secondType == '3') && (secondSubs == '3'))
                                {
                                    Debug.Log("Mix");
                                    // => FQ
                                    solids[2] = true;
                                    FQflask.SetActive(true);
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                        case '2':
                            {
                                // HW

                                if ((secondType == '2') && (secondSubs == '2'))
                                {
                                    Debug.Log("Mix");
                                    // => HL
                                    fluids[4] = true;
                                    HLflask.SetActive(true);
                                }
                                else if ((secondType == '2') && (secondSubs == '3'))
                                {
                                    Debug.Log("Mix");
                                    // ot?
                                    gasses[5] = true;
                                    OTflask.SetActive(true);
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                }
                            }
                            break;
                        case '3':
                            {
                                // HY

                                if ((secondType == '2') && (secondSubs == '3'))
                                {
                                    Debug.Log("Mix");
                                    // => FF
                                    solids[1] = true;
                                    FFflask.SetActive(true);
                                }
                                else if ((secondType == '2') && (secondSubs == '2'))
                                {
                                    Debug.Log("Mix");
                                    // => OA
                                    gasses[1] = true;
                                    OAflask.SetActive(true);
                                }
                                else
                                {
                                    Debug.Log("Fail");
                                    
                                }
                            }
                            break;
                        case '4':
                            {
                                // HL

                                if ((secondType == '3') && (secondSubs == '2'))
                                {
                                    Debug.Log("Mix");
                                    // => FZ ?
                                    solids[6] = true;
                                    FZflask.SetActive(true);
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
            case '2':
                {
                    // 0=of 1=oa 2=ol 3=oz 4=op
                    switch (firstSubs)
                    {

                        case '1':
                            {
                                // OA

                                if ((secondType == '3') && (secondSubs == '4'))
                                {
                                    // fz?
                                    Debug.Log("Mix");
                                    // => FY
                                    solids[5] = true;
                                    FYflask.SetActive(true);
                                }


                            }
                            break;
                        case '2':
                            {
                                // OL

                                if ((secondType == '1') && (secondSubs == '2'))
                                {
                                    Debug.Log("Mix");
                                    // => HL
                                    fluids[4] = true;
                                    HLflask.SetActive(true);
                                }
                                if ((secondType == '1') && (secondSubs == '3'))
                                {
                                    Debug.Log("Mix");
                                    // => OA
                                    gasses[1] = true;
                                    OAflask.SetActive(true);
                                }
                            }
                            break;
                        case '3':
                            {
                                // OZ

                                if ((secondType == '1') && (secondSubs == '3'))
                                {
                                    Debug.Log("Mix");
                                    // => FF
                                    solids[1] = true;
                                    FFflask.SetActive(true);
                                }
                            }
                            break;
                        case '4':
                            {
                                // OP

                                if ((secondType == '3') && (secondSubs == '4'))
                                {
                                    Debug.Log("Mix");
                                    // => HQ
                                    fluids[1] = true;
                                    HQflask.SetActive(true);
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
            case '3':
                {
                    // 0=ft 1=ff 2=fq 3=fh 4=fs
                    switch (firstSubs)
                    {
                        case '0':
                            {
                                // FT

                                if ((secondType == '1') && (secondSubs == '1'))
                                {
                                    Debug.Log("Mix");
                                    // => HD
                                    fluids[0] = true;
                                    HDflask.SetActive(true);
                                }
                            }
                            break;
                        case '1':
                            {
                                // FF

                                if ((secondType == '2') && (secondSubs == '0'))
                                {
                                    // OT?
                                    Debug.Log("Mix");
                                    // => OF
                                    gasses[0] = true;
                                    OFflask.SetActive(true);
                                }
                            }
                            break;
                        case '2':
                            {
                                // FQ

                                if ((secondType == '1') && (secondSubs == '4'))
                                {
                                    Debug.Log("Mix");
                                    // => FZ
                                    solids[6] = true;
                                    FZflask.SetActive(true);
                                }
                            }
                            break;
                        case '3':
                            {
                                // FH

                                if ((secondType == '1') && (secondSubs == '1'))
                                {
                                    Debug.Log("Mix");
                                    // => FQ
                                    solids[2] = true;
                                    FQflask.SetActive(true);
                                }
                            }
                            break;
                        case '4':
                            {
                                // FS

                                if ((secondType == '2') && (secondSubs == '4'))
                                {
                                    Debug.Log("Mix");
                                    // => HQ
                                    fluids[1] = true;
                                    HQflask.SetActive(true);
                                }
                            }
                            break;
                        
                        case '6':
                            {
                                // FZ

                                if((secondType == '2')&& (secondSubs == '1'))
                                {
                                    Debug.Log("Mix");
                                    // => FY
                                    FYflask.SetActive(true);
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

    private void divProcess(char sub, char stype)
    {
        switch (stype)
        {
            case '1':
                {
                    switch (sub)
                    {
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case '0':
                            {
                                Debug.Log("Got HQ & FT");
                                fluids[1] = true;
                                solids[0] = true;
                                HQflask.SetActive(true);
                                FTflask.SetActive(true);

                            }break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case '1':
                            {
                                Debug.Log("Got FS & OP");
                                solids[4] = true;
                                gasses[4] = true;
                                FSflask.SetActive(true);
                                OPflask.SetActive(true);
                            }
                            break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case '2':
                            {
                                Debug.Log("Got None");

                            }
                            break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case '3':
                            {
                                Debug.Log("Got None");
                            }break;
                        // 0=hd 1=hq 2=hw 3=hy 4=hl
                        case '4':
                            {
                                Debug.Log("Got HW & OL");
                                fluids[2] = true;
                                gasses[2] = true;
                                HWflask.SetActive(true);
                                OLflask.SetActive(true);
                            }
                            break;
                        default:
                            {
                                Debug.Log("False Sub");
                            }break;

                    }
                }
                break;
            case '2':
                {
                    switch (sub)
                    {
                        // 0=of 1=oa 2=ol 3=oz 4=op 5=ot
                        case '0':
                            {
                                Debug.Log("Got FF & OT");
                                solids[1] = true;
                                FFflask.SetActive(true);
                                gasses[5] = true;
                                OTflask.SetActive(true);
                            }
                            break;
                        case '1':
                            {
                                Debug.Log("Got HW & OT");
                                fluids[2] = true;
                                gasses[5] = true;
                                HWflask.SetActive(true);
                                OTflask.SetActive(true);
                            }
                            break;
                        case '2':
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case '3':
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case '4':
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case '5':
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
            case '3':
                {
                    switch (sub)
                    {
                        // 0=ft 1=ff 2=fq 3=fh 4=fs 5=fy
                        case '0':
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case '1':
                            {
                                Debug.Log("Got OZ & HY");
                                gasses[3] = true;
                                fluids[3] = true;
                                OZflask.SetActive(true);
                                HYflask.SetActive(true);
                            }
                            break;
                        case '2':
                            {
                                Debug.Log("Got FH & HQ");
                                solids[3] = true;
                                fluids[1] = true;
                                FHflask.SetActive(true);
                                HQflask.SetActive(true);
                            }
                            break;
                        case '3':
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case '4':
                            {
                                Debug.Log("Got None");
                            }
                            break;
                        case '5':
                            {
                                Debug.Log("Got FZ & OA");
                                solids[6] = true;
                                gasses[1] = true;
                                FZflask.SetActive(true);
                                OAflask.SetActive(true);
                            }
                            break;
                        case '6':
                            {
                                Debug.Log("Got HL & FQ");
                                fluids[4] = true;
                                solids[2] = true;
                                HLflask.SetActive(true);
                                FQflask.SetActive(true);
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


    public void bombStone()
    {
        steinObj.SetActive(false);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    [PunRPC]
    void RPC_syncShelf(bool[] pFluids, bool[] pGasses, bool[] pSolids, bool openerTrigger)
    {
        for (int i = 0; i < pFluids.Length; i++)
        {
            fluids[i] = pFluids[i];
        }
        for (int i = 0; i < pGasses.Length; i++)
        {
            gasses[i] = pGasses[i];
        }
        for (int i = 0; i < pSolids.Length; i++)
        {
            solids[i] = pSolids[i];
        }

        dispOpen.trigger = openerTrigger;
    }
}
