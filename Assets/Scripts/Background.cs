﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer sr;
    public float backspeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.material.mainTextureOffset=new Vector2(transform.position.x* backspeed, 0);
    }
}
