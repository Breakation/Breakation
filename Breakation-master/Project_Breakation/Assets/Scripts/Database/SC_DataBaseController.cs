using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_DataBaseController : MonoBehaviour
{

    public GameObject dataBaseButton;
    public GameObject closeDataBaseBut;
    public GameObject dataBaseBackground;
    public GameObject backButton;
    public GameObject xButton;

    public Sprite nicImage1;
    public Sprite nicImage2;

    public GameObject folder1Button;
    public GameObject folder2Button;
    public GameObject folder3Button;
    public GameObject folder4Button;

    public GameObject dataButton;
    public GameObject data2Button;

    public GameObject placeholderImage;
    public GameObject blackScreen;
    private Image dataImage;

    private string currentPage = "start";


    // Start is called before the first frame update
    void Start()
    {
        dataImage = placeholderImage.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startDataBase()
    {
        dataBaseBackground.SetActive(true);
        closeDataBaseBut.SetActive(true);
        dataBaseButton.SetActive(false);
        folder1Button.SetActive(true);
        folder2Button.SetActive(true);
        folder3Button.SetActive(true);
        folder4Button.SetActive(true);
    }

    public void closeDataBase()
    {
        dataBaseBackground.SetActive(false);
        closeDataBaseBut.SetActive(false);
        dataBaseButton.SetActive(true);
        folder1Button.SetActive(false);
        folder2Button.SetActive(false);
        folder3Button.SetActive(false);
        folder4Button.SetActive(false);
        backButton.SetActive(false);
        dataButton.SetActive(false);
        data2Button.SetActive(false);
        placeholderImage.SetActive(false);
        xButton.SetActive(false);
        blackScreen.SetActive(false);

    }

    public void openFolderOne()
    {
        backButton.SetActive(true);
        folder1Button.SetActive(false);
        folder2Button.SetActive(false);
        folder3Button.SetActive(false);
        folder4Button.SetActive(false);
        dataButton.SetActive(true);
        data2Button.SetActive(true);
        

        currentPage = "folder1";
    }
    public void openFolderTwo()
    {
        backButton.SetActive(true);
        folder1Button.SetActive(false);
        folder2Button.SetActive(false);
        folder3Button.SetActive(false);
        folder4Button.SetActive(false);
       

        currentPage = "folder2";
    }
    public void openFolderThree()
    {
        backButton.SetActive(true);
        folder1Button.SetActive(false);
        folder2Button.SetActive(false);
        folder3Button.SetActive(false);
        folder4Button.SetActive(false);
        

        currentPage = "folder3";
    }
    public void openFolderFour()
    {
        backButton.SetActive(true);
        folder1Button.SetActive(false);
        folder2Button.SetActive(false);
        folder3Button.SetActive(false);
        folder4Button.SetActive(false);
        

        currentPage = "folder4";
    }


    public void backButtonPressed()
    {
        switch (currentPage)
        {
            case "folder1":
                {
                    folder1Button.SetActive(true);
                    folder2Button.SetActive(true);
                    folder3Button.SetActive(true);
                    folder4Button.SetActive(true);
                    backButton.SetActive(false);
                    dataButton.SetActive(false);
                    data2Button.SetActive(false);
                    blackScreen.SetActive(false);
                    xButton.SetActive(false);
                    placeholderImage.SetActive(false);
                }
                break;
            case "folder2":
                {
                    folder1Button.SetActive(true);
                    folder2Button.SetActive(true);
                    folder3Button.SetActive(true);
                    folder4Button.SetActive(true);
                    backButton.SetActive(false);
                }
                break;
            case "folder3":
                {
                    folder1Button.SetActive(true);
                    folder2Button.SetActive(true);
                    folder3Button.SetActive(true);
                    folder4Button.SetActive(true);
                    backButton.SetActive(false);
                }
                break;
            case "folder4":
                {
                    folder1Button.SetActive(true);
                    folder2Button.SetActive(true);
                    folder3Button.SetActive(true);
                    folder4Button.SetActive(true);
                    backButton.SetActive(false);
                }
                break;
            default:
                {
                    Debug.Log("Fehler");
                }break;

        }
    }

    public void openData1()
    {
        placeholderImage.SetActive(true);
        blackScreen.SetActive(true);
        dataImage.sprite = nicImage1;
        xButton.SetActive(true);
    }
    public void openData2()
    {
        blackScreen.SetActive(true);
        placeholderImage.SetActive(true);
        dataImage.sprite = nicImage2;
        xButton.SetActive(true);
    }

    public void closeData()
    {
        blackScreen.SetActive(false);
        placeholderImage.SetActive(false);
        xButton.SetActive(false);
    }
}
