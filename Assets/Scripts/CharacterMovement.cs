using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    protected Joystick joystick;
    protected SpriteRenderer sr;
    public Animator animator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        float x, y;

        x = joystick.Horizontal;
        y = joystick.Vertical;

        float targetLen = 1.0f;
        float len = Convert.ToSingle( Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) );

        float targetX = x/(len * targetLen);
        float targetY = y/(len * targetLen);

        
        if (x != 0.0f && y != 0.0f)
        {
            animator.SetBool("walking", true);

            //Vector3 movement = new Vector3(targetX, targetY, 0.0f);
            //transform.position += movement * Time.deltaTime * 0.9f;
            rb.velocity = new Vector2(targetX*0.8f, targetY*0.8f);
        }
        else
        {
            animator.SetBool("walking", false);
            rb.velocity = new Vector2(0.0f, 0.0f);
        }

        if (joystick.Horizontal >= 0)
            sr.flipX = false;
        else
            sr.flipX = true;

    }
}
