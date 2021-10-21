using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public float delay = 4;
    public float timer = 0;
    public float resetTime = 7;
    public  int movespeed = 5;
    public Vector3 userDirection = Vector3.right;

    void Start()
    {

    }

    void Update()
    {
        // increase the timer
        timer += Time.deltaTime;

        // if timer is less than delay, keep moving forward
        if (timer <= delay)
        {


            float step = movespeed * Time.deltaTime;
            transform.Translate(userDirection * movespeed * Time.deltaTime);




        }
        // else, move backward
        if (timer > delay)
        {

            float step = movespeed * Time.deltaTime;
            transform.Translate(userDirection * -movespeed * Time.deltaTime);

            if(timer > resetTime)
            {
                timer = 0; // reset to move back and forth
            }

        }
    }
}
