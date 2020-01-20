using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerQuiz : MonoBehaviour
{
    [SerializeField] GameObject Question1;
    [SerializeField] GameObject Question2;
    [SerializeField] GameObject Question3;
    [SerializeField] GameObject Question4;

    [SerializeField] GameObject Answer11;
    [SerializeField] GameObject Answer12;
    [SerializeField] GameObject Answer13;
    [SerializeField] GameObject Answer14;

    [SerializeField] GameObject Answer21;
    [SerializeField] GameObject Answer22;
    [SerializeField] GameObject Answer23;
    [SerializeField] GameObject Answer24;

    [SerializeField] GameObject Answer31;
    [SerializeField] GameObject Answer32;
    [SerializeField] GameObject Answer33;
    [SerializeField] GameObject Answer34;

    [SerializeField] GameObject Answer41;
    [SerializeField] GameObject Answer42;
    [SerializeField] GameObject Answer43;
    [SerializeField] GameObject Answer44;

    [SerializeField] GameObject KippOn1;
    [SerializeField] GameObject KippOn2;
    [SerializeField] GameObject KippOn3;
    [SerializeField] GameObject KippOn4;

    [SerializeField] GameObject TrueText;
    [SerializeField] GameObject FalseText;

    [SerializeField] GameObject GameEndeCanvas;
    [SerializeField] GameObject GameCanvas;

    public bool button1 = false;
    public bool button2 = false;
    public bool button3 = false;
    public bool button4 = false;


    private int Score = 0;
    private int QuestionNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEndeCanvas.SetActive(false);


        KippOn1.SetActive(false);
        KippOn2.SetActive(false);
        KippOn3.SetActive(false);
        KippOn4.SetActive(false);

        TrueText.SetActive(false);
        FalseText.SetActive(false);


        Score = 0;
        QuestionNumber = 0;

        Question1.SetActive(true);
        Question2.SetActive(false);
        Question3.SetActive(false);
        Question4.SetActive(false);

        Answer11.SetActive(true);
        Answer12.SetActive(true);
        Answer13.SetActive(true);
        Answer14.SetActive(true);

        Answer21.SetActive(false);
        Answer22.SetActive(false);
        Answer23.SetActive(false);
        Answer24.SetActive(false);

        Answer31.SetActive(false);
        Answer32.SetActive(false);
        Answer33.SetActive(false);
        Answer34.SetActive(false);

        Answer41.SetActive(false);
        Answer42.SetActive(false);
        Answer43.SetActive(false);
        Answer44.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (SampleUserPolling_ReadWrite.kipp1)
        {
            button1 = true;
            KippOn1.SetActive(true);
        } 
        if(!SampleUserPolling_ReadWrite.kipp1)
        {
            KippOn1.SetActive(false);
            button1 = false;
        }
        if (SampleUserPolling_ReadWrite.kipp2)
        {
            button2 = true;
            KippOn2.SetActive(true);
        }
        if (!SampleUserPolling_ReadWrite.kipp2)
        {
            KippOn2.SetActive(false);
            button2 = false;
        }
        if (SampleUserPolling_ReadWrite.kipp3)
        {
            button3 = true;
            KippOn3.SetActive(true);
        }
        if (!SampleUserPolling_ReadWrite.kipp3)
        {
            KippOn3.SetActive(false);
            button3 = false;
        }
        if (SampleUserPolling_ReadWrite.kipp4)
        {
            button4 = true;
            KippOn4.SetActive(true);
        }
        if (!SampleUserPolling_ReadWrite.kipp4)
        {
            KippOn4.SetActive(false);
            button4 = false;
        }
    }

                    public void next()
    {
        CommitAnswer();

        QuestionNumber++;

        if(QuestionNumber.Equals(1))
        {
            Question1.SetActive(false);
            Question2.SetActive(true);
            Question3.SetActive(false);
            Question4.SetActive(false);

            Answer11.SetActive(false);
            Answer12.SetActive(false);
            Answer13.SetActive(false);
            Answer14.SetActive(false);

            Answer21.SetActive(true);
            Answer22.SetActive(true);
            Answer23.SetActive(true);
            Answer24.SetActive(true);

            Answer31.SetActive(false);
            Answer32.SetActive(false);
            Answer33.SetActive(false);
            Answer34.SetActive(false);

            Answer41.SetActive(false);
            Answer42.SetActive(false);
            Answer43.SetActive(false);
            Answer44.SetActive(false);
        }

        if (QuestionNumber.Equals(2))
        {
            Question1.SetActive(false);
            Question2.SetActive(false);
            Question3.SetActive(true);
            Question4.SetActive(false);

            Answer11.SetActive(false);
            Answer12.SetActive(false);
            Answer13.SetActive(false);
            Answer14.SetActive(false);

            Answer21.SetActive(false);
            Answer22.SetActive(false);
            Answer23.SetActive(false);
            Answer24.SetActive(false);

            Answer31.SetActive(true);
            Answer32.SetActive(true);
            Answer33.SetActive(true);
            Answer34.SetActive(true);

            Answer41.SetActive(false);
            Answer42.SetActive(false);
            Answer43.SetActive(false);
            Answer44.SetActive(false);
        }

        if (QuestionNumber.Equals(3))
        {
            Question1.SetActive(false);
            Question2.SetActive(false);
            Question3.SetActive(false);
            Question4.SetActive(true);

            Answer11.SetActive(false);
            Answer12.SetActive(false);
            Answer13.SetActive(false);
            Answer14.SetActive(false);

            Answer21.SetActive(false);
            Answer22.SetActive(false);
            Answer23.SetActive(false);
            Answer24.SetActive(false);

            Answer31.SetActive(false);
            Answer32.SetActive(false);
            Answer33.SetActive(false);
            Answer34.SetActive(false);

            Answer41.SetActive(true);
            Answer42.SetActive(true);
            Answer43.SetActive(true);
            Answer44.SetActive(true);
        }

    }

    //1.1, 2.3, 3.2, 4.3

    void CommitAnswer()
    {

        switch (QuestionNumber)
        {

            case 0 :
                
                    if (button1 && !button2 && !button3 && !button4)
                    {
                        Score += 1;
                        TrueText.SetActive(true);
                        StartCoroutine(HideTureFalse());
                    }
                    else { FalseText.SetActive(true); StartCoroutine(HideTureFalse()); }

                ResetButton();


                break;

            case 1:
                     if (!button1 && !button2 && button3 && !button4)
                     {
                        Score += 1;
                        TrueText.SetActive(true);
                        StartCoroutine(HideTureFalse());
                     }
                    else { FalseText.SetActive(true); StartCoroutine(HideTureFalse()); }

                ResetButton();

                break;

            case 2:
                    if (!button1 && button2 && !button3 && !button4)
                    {
                        Score += 1;
                        TrueText.SetActive(true);
                        StartCoroutine(HideTureFalse());
                    }
                else { FalseText.SetActive(true); StartCoroutine(HideTureFalse()); }

                ResetButton();

                break;

            case 3 :
         
        
                    if (!button1 && !button2 && button3 && !button4)
                    {
                        Score += 1;
                        TrueText.SetActive(true);
                        StartCoroutine(HideTureFalse());
                    }
                else { FalseText.SetActive(true); StartCoroutine(HideTureFalse()); }

                ResetButton();

                break;

            default :

                GameEndeCanvas.SetActive(true);
                GameCanvas.SetActive(false);

                break;
        }

        Debug.Log(Score);

    }

    void ResetButton()
    {
        button1 = false;
        button2 = false;
        button3 = false;
        button4 = false;
    }

    IEnumerator HideTureFalse()
    {
        yield return new WaitForSeconds(2);

        TrueText.SetActive(false);
        FalseText.SetActive(false);
    }

    public void ExitGame()
    {
        ActivateQuiz.DeaktivateQuiz = true;

        button1 = false;
        button2 = false;
        button3 = false;
        button4 = false;

        KippOn1.SetActive(false);
        KippOn2.SetActive(false);
        KippOn3.SetActive(false);
        KippOn4.SetActive(false);

        TrueText.SetActive(false);
        FalseText.SetActive(false);


        Score = 0;
        QuestionNumber = 0;

        Question1.SetActive(true);
        Question2.SetActive(false);
        Question3.SetActive(false);
        Question4.SetActive(false);

        Answer11.SetActive(true);
        Answer12.SetActive(true);
        Answer13.SetActive(true);
        Answer14.SetActive(true);

        Answer21.SetActive(false);
        Answer22.SetActive(false);
        Answer23.SetActive(false);
        Answer24.SetActive(false);

        Answer31.SetActive(false);
        Answer32.SetActive(false);
        Answer33.SetActive(false);
        Answer34.SetActive(false);

        Answer41.SetActive(false);
        Answer42.SetActive(false);
        Answer43.SetActive(false);
        Answer44.SetActive(false);
    }
}
