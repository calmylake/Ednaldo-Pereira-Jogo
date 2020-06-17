using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Image blackBG;
    public Movement player;
    public Text text;
    int countEnd;
    bool end;

    public AudioSource soundWin;
    public AudioSource soundLose;
    ControladorDeVolume volumeController;
    void Start()
    {
        volumeController = FindObjectOfType<ControladorDeVolume>();
        soundWin.volume = soundLose.volume = volumeController.getVolume();

        blackBG.color = new Color(0,0,0,0);
        blackBG.enabled = false;
        end = false;
        text.enabled = false;
    }

    void FixedUpdate()
    {
        if(end == true)
        {
            if (countEnd < 100) { blackBG.color += new Color(0, 0, 0, 0.08f); }
            else if (countEnd > 200) SceneManager.LoadScene("menu");
            countEnd++;
        }
        
    }

    public void WinGame()
    {
        player.enabled = false;
        string melancia = "melancias";
        if (scoreManager.getScore() == 1) melancia = "melancia";
        text.text = "Você deu " + scoreManager.getScore() + " " + melancia + " para Chico Melancia!";
        soundWin.enabled = true; soundWin.Play();
        text.enabled = true;
        blackBG.enabled = true;
        end = true;
        
    }
    public void LoseGame()
    {
        player.enabled = false;
        text.text = "Você perdeu!";
        blackBG.enabled = true;
        soundLose.enabled = true; soundLose.Play();
        text.enabled = true;
        blackBG.enabled = true;
        end = true;
    }
}
