using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    protected Joystick joystick;
    protected SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("H:" + joystick.Horizontal + " V:" + joystick.Vertical);


        if (joystick.Horizontal >= 0)
            sr.flipX = false;
        else
            sr.flipX = true;

        float slope, x, y;

        x = joystick.Horizontal;
        y = joystick.Vertical;
        slope = y / x;
        if (x != 0.0f && y != 0.0f)
        {
            float max_x, max_y;

            if (x > 0)
                max_x = 1.0f;
            else
                max_x = -1.0f;

            max_y = max_x * slope;

            if (Math.Abs(max_y) > Math.Abs(max_x))
            {
                if (y > 0)
                    max_y = 1.0f;
                else
                    max_y = -1.0f;

                max_x = max_y / slope;
            }


            Vector3 movement = new Vector3(max_x, max_y, 0.0f);
            transform.position += movement * Time.deltaTime * 0.8f;
        }
    }
}
