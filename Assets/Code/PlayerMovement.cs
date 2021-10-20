using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //========= Setting Variables =============

    private Rigidbody2D rb;
    public float jumpValue = 0f;
    public float startingJump = 0f;
    public float maxJump = 80.0f;
    public float speed = 0f;
    private bool left, right;
    public ParticleSystem Dust;
    public bool isGrounded;
    public LayerMask groundMask;
    //public float jumpTime;
    //private float jumpTimeCounter;
    public bool isJumping;

    private float moveInput;

    void Start()
    {
        right = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

    }

    void Update()
    {
       

       isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 2f, transform.position.y - 0.5f), 
           new Vector2(transform.position.x + 2f, transform.position.y - 0.5f), groundMask);

      if (isGrounded)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
   

       if (moveInput > 0)
        {
            faceRight();
        }
        if (moveInput < 0)
        {
            faceLeft();
        }


        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && isGrounded && Input.GetKey(KeyCode.Space))
        {
            speed += 0.5f;
            if (speed >= 31)
            {
                speed = 30;
            }
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
            {

            // isJumping = true;
            jumpValue += 1f;
            //jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            if(jumpValue >= maxJump)
            {
                jumpValue = maxJump;
            }
            Invoke("resetJump", 1f);
            
            
        }

        if(jumpValue >= maxJump && isGrounded)
        {
            createDust();
            float tempx = moveInput * speed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
        }


        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(isGrounded)
            {
                createDust();
                rb.velocity = new Vector2(moveInput * speed, jumpValue);
                jumpValue = 0.0f;
            }
            isJumping = true;
        }

                /* Another method to jump higher base on "time"

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && isJumping)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                
                rb.velocity = Vector2.up * jump;
                jumpTimeCounter -= Time.deltaTime;
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }
            else
            {
                isJumping = false;
            }
            
        }

        

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        */
 

    }

    void resetJump()
    {
        isJumping = false;
        jumpValue = startingJump;
        speed = 10;
    }

    public void faceLeft()
    {
       if (left)
        {
            return;
        }
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }
    public void faceRight()
    {
        if (right)
        {
            return;
        }
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = false;
        right = true;
    }

    // Dust functions to play and stop them
    void createDust()
    {
        Dust.Play();
    }
    void stopDust()
    {
        Dust.Stop();
    }

}
