using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text text;
    int countEnd;
    bool end;
    void Start()
    {
        end = false;
        text.enabled = false;
    }

    void Update()
    {
        if(end == true)
        {
            if (countEnd > 200)
            {
                SceneManager.LoadScene("menu");
            }
            countEnd++;
        }
        
    }

    public void EndGame()
    {
        string melancia = "melancias";
        if (scoreManager.getScore() == 1) melancia = "melancia";
        text.text = "Você deu "+scoreManager.getScore()+" "+melancia+" para Chico Melancia!";
        text.enabled = true;
        end = true;
    }
}
