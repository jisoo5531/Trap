using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
