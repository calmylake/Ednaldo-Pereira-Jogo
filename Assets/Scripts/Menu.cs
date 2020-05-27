using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string startLevel;

    public string instructions;

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(instructions);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
