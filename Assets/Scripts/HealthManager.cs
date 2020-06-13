using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health;
    public Fim fim;
    public Text text;

    void Start()
    {
        health = 3;
    }

    void Update()
    {
        text.text = "" + health;
    }

    public void TakeDamage()
    {
        if (health == 0) {
            fim.LoseGame();
        } else health -= 1;
        Debug.Log(health);
    }

    public int CurrentHealth()
    {
        return health;
    }
}
