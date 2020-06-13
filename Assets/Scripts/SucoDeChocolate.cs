using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucoDeChocolate : MonoBehaviour
{
    bool taken;
    CapsuleCollider2D capsuleCol;
    Vector3 startScale;

    int cooldown;
    void Start()
    {
        capsuleCol = FindObjectOfType<CapsuleCollider2D>();
        startScale = transform.localScale;
        cooldown = 0;
        taken = false;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (cooldown >= 90)
        {
            Spawn();
        }
        else if (taken == true)
        {
            cooldown++;
        }
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        Take();
    }

    public void Spawn()
    {
        transform.localScale = startScale;
        taken = false;
        capsuleCol.enabled = true;
        cooldown = 0;
    }

    public void Take()
    {
        Movement mv = FindObjectOfType<Movement>();
        mv.dash = false;
        transform.localScale = new Vector3(0,0,0);
        taken = true;
        capsuleCol.enabled = false;
    }
}
