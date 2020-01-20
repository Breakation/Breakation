using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuiz : MonoBehaviour
{
    [SerializeField] GameObject QuizGameNew;

    public static bool DeaktivateQuiz;

    // Start is called before the first frame update
    void Start()
    {
        QuizGameNew.SetActive(false);
        DeaktivateQuiz = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && SampleUserPolling_ReadWrite.kipp1 && SampleUserPolling_ReadWrite.kipp2 && SampleUserPolling_ReadWrite.kipp3 && SampleUserPolling_ReadWrite.kipp4)
        {
            QuizGameNew.SetActive(true);
        }
        if (DeaktivateQuiz)
        {
            QuizGameNew.SetActive(false);
            DeaktivateQuiz = false;
        }
    }
}
