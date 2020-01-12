using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ZoomController : MonoBehaviour
{
    private bool copyCreated = false;
    public GameObject maincamera;
    public Vector3 distToCam = new Vector3(0, -2, 2);

    private GameObject tempCopy;

    public GameObject[] zoomableObject;

    Ray ray;
    RaycastHit raycastHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void zoomIn(string prefabName,string objType)
    {
        if (!copyCreated)
        {
            Vector3 tempPos = maincamera.transform.position;
            Vector3 newPos = tempPos + distToCam;
            Vector3 RotationAdd = new Vector3(0, 180, 0);
            Vector3 nullRot = new Vector3(0, 0, 0);
            Debug.Log("Click");

            tempCopy = PhotonNetwork.Instantiate(prefabName, newPos, maincamera.transform.rotation);
            SC_Zoomable tempscript = tempCopy.GetComponent<SC_Zoomable>();

            tempscript.isCopy = true;

            tempCopy.transform.Rotate(new Vector3(0, tempscript.rotationNmbr, 0));

            switch (objType)
            {
                case "automatFluid":
                    {
                        GameObject tempMixer = GameObject.Find("Mixer");
                        sc_Mixer mixContr = tempMixer.GetComponent<sc_Mixer>();
                        if (mixContr.fluids[0])
                        {
                            GameObject hd = tempCopy.transform.Find("HD").gameObject;

                            hd.SetActive(true);


                        }
                        if (mixContr.fluids[1])
                        {
                            GameObject hq = tempCopy.transform.Find("HQ").gameObject;
                            hq.SetActive(true);
                        }
                        if (mixContr.fluids[2])
                        {
                            GameObject hw = tempCopy.transform.Find("HW").gameObject;
                            hw.SetActive(true);
                        }
                        if (mixContr.fluids[3])
                        {
                            GameObject hy = tempCopy.transform.Find("HY").gameObject;
                            hy.SetActive(true);
                        }
                        if (mixContr.fluids[4])
                        {
                            GameObject hl = tempCopy.transform.Find("HL").gameObject;
                            hl.SetActive(true);
                        }

                    }
                    break;
                case "automatGas":
                    {
                        GameObject tempMixer = GameObject.Find("Mixer");
                        sc_Mixer mixContr = tempMixer.GetComponent<sc_Mixer>();
                        if (mixContr.gasses[0])
                        {
                            GameObject of = tempCopy.transform.Find("OF").gameObject;
                            of.SetActive(true);
                        }
                        if (mixContr.gasses[1])
                        {
                            GameObject oa = tempCopy.transform.Find("OA").gameObject;
                            oa.SetActive(true);
                        }
                        if (mixContr.gasses[2])
                        {
                            GameObject ol = tempCopy.transform.Find("OL").gameObject;
                            ol.SetActive(true);
                        }
                        if (mixContr.gasses[3])
                        {
                            GameObject oz = tempCopy.transform.Find("OZ").gameObject;
                            oz.SetActive(true);
                        }
                        if (mixContr.gasses[4])
                        {
                            GameObject op = tempCopy.transform.Find("OP").gameObject;
                            op.SetActive(true);
                        }
                        if (mixContr.gasses[5])
                        {
                            GameObject ot = tempCopy.transform.Find("OT").gameObject;
                            ot.SetActive(true);
                        }
                    }
                    break;
                case "automatSolid":
                    {
                        GameObject tempMixer = GameObject.Find("Mixer");
                        sc_Mixer mixContr = tempMixer.GetComponent<sc_Mixer>();
                        if (mixContr.solids[0])
                        {
                            GameObject ft = tempCopy.transform.Find("FT").gameObject;
                            ft.SetActive(true);
                        }
                        if (mixContr.solids[1])
                        {
                            GameObject ff = tempCopy.transform.Find("FF").gameObject;
                            ff.SetActive(true);
                        }
                        if (mixContr.solids[2])
                        {
                            GameObject fq = tempCopy.transform.Find("FQ").gameObject;
                            fq.SetActive(true);
                        }
                        if (mixContr.solids[3])
                        {
                            GameObject fh = tempCopy.transform.Find("FH").gameObject;
                            fh.SetActive(true);
                        }
                        if (mixContr.solids[4])
                        {
                            GameObject fs = tempCopy.transform.Find("FS").gameObject;
                            fs.SetActive(true);
                        }
                        if (mixContr.solids[5])
                        {
                            GameObject fy = tempCopy.transform.Find("FY").gameObject;
                            fy.SetActive(true);
                        }
                        if (mixContr.solids[6])
                        {
                            GameObject fz = tempCopy.transform.Find("FZ").gameObject;
                            fz.SetActive(true);
                        }
                    }
                    break;
                default:
                    {




                        Debug.Log("falscher Typ");
                    }
                    break;
            }

            copyCreated = true;
        }
        else
        {
            Debug.Log("Destroy");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                copyCreated = false;
                Object.Destroy(tempCopy.gameObject);
            }

        }
    }
}
