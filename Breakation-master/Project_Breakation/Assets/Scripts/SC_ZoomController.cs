using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ZoomController : MonoBehaviour
{
    private bool copyCreated = false;
    public GameObject maincamera;
    public Vector3 distToCam = new Vector3(0, -2, 2);

    public GameObject closeZoomButton;

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

    public void closeZoom()
    {
        Object.Destroy(tempCopy.gameObject);
        copyCreated = false;
        closeZoomButton.SetActive(false);
    }


    public void zoomIn(string prefabName,string objType, GameObject creator)
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
                        

                        for (int i = 12; i < 17; i++)
                        {
                            GameObject tempChild = creator.transform.GetChild(i).gameObject;
                            if (tempChild.activeSelf)
                            {
                                string tempName = tempChild.name;
                                Debug.Log(tempName);
                                GameObject tempMyChild = tempCopy.transform.Find(tempName).gameObject;
                                tempMyChild.SetActive(true);
                                if (tempChild.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite != null)
                                {
                                    SpriteRenderer tempSpriteR = tempChild.transform.GetChild(0).GetComponent<SpriteRenderer>();

                                    GameObject tempMyChildChild = tempMyChild.transform.Find("New Sprite").gameObject;
                                    SpriteRenderer tempMySprite = tempMyChildChild.GetComponent<SpriteRenderer>();
                                    tempMySprite.sprite = tempSpriteR.sprite;
                                }

                            }
                            else
                            {
                                string tempName = tempChild.name;
                                GameObject tempMyChild = tempCopy.transform.Find(tempName).gameObject;
                                tempMyChild.SetActive(false);
                            }
                        }

                        
                    }break;
                case "automatGas":
                    {
                        for (int i = 12; i < 18; i++)
                        {
                            GameObject tempChild = creator.transform.GetChild(i).gameObject;
                            if (tempChild.activeSelf)
                            {
                                string tempName = tempChild.name;
                                Debug.Log(tempName);
                                GameObject tempMyChild = tempCopy.transform.Find(tempName).gameObject;
                                tempMyChild.SetActive(true);


                                if (tempChild.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite != null)
                                {
                                    SpriteRenderer tempSpriteR = tempChild.transform.GetChild(0).GetComponent<SpriteRenderer>();

                                    GameObject tempMyChildChild = tempMyChild.transform.Find("New Sprite").gameObject;
                                    SpriteRenderer tempMySprite = tempMyChildChild.GetComponent<SpriteRenderer>();
                                    tempMySprite.sprite = tempSpriteR.sprite;
                                }
                            }
                            else
                            {
                                string tempName = tempChild.name;
                                GameObject tempMyChild = tempCopy.transform.Find(tempName).gameObject;
                                tempMyChild.SetActive(false);
                            }
                        }
                    }
                    break;
                case "automatSolid":
                    {
                        for (int i = 12; i < 19; i++)
                        {
                            GameObject tempChild = creator.transform.GetChild(i).gameObject;
                            if (tempChild.activeSelf)
                            {
                                string tempName = tempChild.name;
                                Debug.Log(tempName);
                                GameObject tempMyChild = tempCopy.transform.Find(tempName).gameObject;
                                tempMyChild.SetActive(true);

                                

                                if (tempChild.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite != null)
                                {
                                    SpriteRenderer tempSpriteR = tempChild.transform.GetChild(0).GetComponent<SpriteRenderer>();
                                    
                                    GameObject tempMyChildChild = tempMyChild.transform.Find("New Sprite").gameObject;
                                    SpriteRenderer tempMySprite = tempMyChildChild.GetComponent<SpriteRenderer>();
                                    tempMySprite.sprite = tempSpriteR.sprite;
                                }
                            }
                            else
                            {
                                string tempName = tempChild.name;
                                GameObject tempMyChild = tempCopy.transform.Find(tempName).gameObject;
                                tempMyChild.SetActive(false);
                            }
                        }
                    }
                    break;
                case "notiz":
                    {
                        tempCopy.transform.eulerAngles = new Vector3(45, 0, 0);
                    }break;
                default:
                    {




                        Debug.Log("falscher Typ");
                    }
                    break;
            }

            copyCreated = true;
            closeZoomButton.SetActive(true);
        }
        else
        {
            Debug.Log("Destroy");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                copyCreated = false;
                Object.Destroy(tempCopy.gameObject);
                closeZoomButton.SetActive(false);
            }

        }
    }
}
