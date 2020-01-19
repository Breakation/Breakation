using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuiz : MonoBehaviour
{

    [SerializeField] GameObject Quiz;
    public bool ControllerActiveQuiz = false;


    // Start is called before the first frame update
    void Start()
    {
        Quiz.SetActive(false);
        ControllerActiveQuiz = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SampleUserPolling_ReadWrite.kipp1 && SampleUserPolling_ReadWrite.kipp2 && SampleUserPolling_ReadWrite.kipp3 && SampleUserPolling_ReadWrite.kipp4)
        {
            ControllerActiveQuiz = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && !GameManagerQuiz.QuizDoneOnceExit && ControllerActiveQuiz)
        {
            Quiz.SetActive(true);
        }
    }
}
