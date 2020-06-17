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
    bool start;
    float endSpeed;

    public string sceneLose;
    public string sceneWin;
    string scene;

    public AudioSource soundWin;
    public AudioSource soundLose;
    ControladorDeVolume volumeController;
    void Start()
    {
        volumeController = FindObjectOfType<ControladorDeVolume>();
        soundWin.volume = soundLose.volume = volumeController.getVolume();
        endSpeed = 1;
        blackBG.color = new Color(0,0,0,1);
        blackBG.enabled = true;
        end = false;
        start = true;
        text.enabled = false;
    }

    void FixedUpdate()
    {
        if(start == true)
        {
            float fadeInRatio = 0.04f;
            if (blackBG.color.a > fadeInRatio) { blackBG.color -= new Color(0, 0, 0, fadeInRatio); }
            else if(blackBG.color.a <= fadeInRatio) { blackBG.color = new Color(0, 0, 0, 0); blackBG.enabled = false; start = false; }
        }
        if(end == true)
        {
            if (countEnd < 50*endSpeed) { blackBG.color += new Color(0, 0, 0, 0.08f); }
            else if (countEnd > 150*endSpeed) SceneManager.LoadScene(scene);
            countEnd++;
        }
        
    }

    public void WinGame()
    {
        scene = sceneWin;
        player.movEnabled = false;
        player.stopWalk();
        string melancia = "melancias";
        if (scoreManager.getScore() == 1) melancia = "melancia";
        text.text = "Você deu " + scoreManager.getScore() + " " + melancia + " para Chico Melancia!";
        soundWin.enabled = true; soundWin.Play();
        text.enabled = true;
        blackBG.enabled = true;
        end = true;
        endSpeed = 3f;
        
    }
    public void LoseGame()
    {
        scene = sceneLose;
        player.movEnabled = false;
        player.stopWalk();
        text.text = "Você perdeu!";
        blackBG.enabled = true;
        soundLose.enabled = true; soundLose.Play();
        text.enabled = true;
        blackBG.enabled = true;
        end = true;
    }
}
