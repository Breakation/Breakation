using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_gameOver : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
