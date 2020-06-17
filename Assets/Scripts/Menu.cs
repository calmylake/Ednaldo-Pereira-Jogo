using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string startLevel;

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
