using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_won : MonoBehaviour
{
    public void BackToMain()
    {
        sc_winCondtion.enmyCount = 7;

        SceneManager.LoadScene(0);
    }
}
