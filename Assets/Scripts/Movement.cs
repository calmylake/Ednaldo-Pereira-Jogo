using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MoveSpeed;
    public float JumpHeight;

    public Animator animator;
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    public bool Grounded;
    public SpriteRenderer spriteRenderer;

    public bool dash;
    public bool dashing;
    public int dashAnimation;
    public bool movEnabled;
    public int timeToEnable;

    public bool l, u, d, r, c, x, z;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MoveSpeed = 5;
        JumpHeight = 4*rb.gravityScale;
        l = false; u = false; d = false; r = false;
        dashAnimation = 0;
        dashing = false;
        movEnabled = false;
        timeToEnable = 250;
    }

    void FixedUpdate()
    {
        if (timeToEnable < 0)
        {
            movEnabled = true;
        }
        else timeToEnable--;
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
        if (Grounded) animator.SetBool("Grounded", true);
        else animator.SetBool("Grounded", false);
        if (dashing == true)
        {
            if(dashAnimation >= 30 || Grounded)
            {
                dashing = false;
                dashAnimation = 0;
                rb.gravityScale = 3;
            }
            dashAnimation++;
        }
    }

    void Update()
    {
        if (!movEnabled) { return; }
        setAllInputVarFalse();
        setSomeInputVarTrue();

        //left and right movement
        if (l && !dashing)
        {
            rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
        }
        if (r && !dashing)
        {
            rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
        }

        //stop walk
        if ((l && r) || (!(l || r)) && !dashing)
        {
            stopWalk();
        }

        if (l) spriteRenderer.flipX = true;
        if (r) spriteRenderer.flipX = false;

        //jump and double jump
        if (Grounded) dash = false;
        if (c && Grounded) rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        if (x && !dash)
        {
            float tempX = 0;
            float tempY = 0;

            if (l) tempX = -JumpHeight;
            if (r) tempX = JumpHeight;
            if (u) tempY = JumpHeight;
            if (d) tempY = -JumpHeight;

            if (tempX != 0 && tempY != 0) Dash(new Vector2(tempX * 0.8f, tempY * 0.8f));
            else if (tempX == 0 && tempY == 0) { }
            else Dash(new Vector2(tempX, tempY));

        }

        animator.SetFloat("Velocity", Math.Abs(rb.velocity.x));

    }



    private void setAllInputVarFalse()
    {
        l = false; u = false; d = false; r = false; c = false; x = false; z = false;
    }

    private void setSomeInputVarTrue()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) l = true;
        if (Input.GetKey(KeyCode.UpArrow)) u = true;
        if (Input.GetKey(KeyCode.DownArrow)) d = true;
        if (Input.GetKey(KeyCode.RightArrow)) r = true;
        if (Input.GetKeyDown(KeyCode.C)) c = true;
        if (Input.GetKeyDown(KeyCode.X)) x = true;
        if (Input.GetKey(KeyCode.Z)) z = true;
    }

    public void stopWalk()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Dash(Vector2 vector) {
        rb.velocity = vector;
        dash = true;
        dashing = true;
        rb.gravityScale = 0;
    }
}