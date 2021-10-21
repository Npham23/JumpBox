using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //========= Setting Variables =============

    private Rigidbody2D rb;

    // basic stats for player movement
    public float jumpValue = 0f;
    public float startingJump = 0f;
    public float startingSpeed = 0f;
    public float maxJump = 80.0f;
    public float speed = 0f;

    // player direction
    private bool left, right;

    // to create dust effects
    public ParticleSystem Dust;
    public ParticleSystem Fireworks;

    // for checking objects
    public bool isGrounded;
    public bool isAWall = false;
    public bool isVictory = false;
    public LayerMask groundMask;
    public LayerMask wallMask;
    public LayerMask winMask;

    // checking if the player is in the air
    public bool isJumping;

    // basic movement
    private float moveInput;

    // to play the sounds
    public AudioSource jumpSound;
    public AudioSource landingSound;
    public AudioSource bouncingSound;
    private bool landSound = false;

    void Start()
    {

        // starts player direction right side
        right = true;
        // for changes in position x y
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal"); // moving on the x axis, basic player movement

    }

    void Update()
    {

        // checks if the player is grounded within a certain radius
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.2f, transform.position.y - 0.5f),
        new Vector2(transform.position.x + 0.2f, transform.position.y - 0.5f), groundMask);

        // checks if the player is touching the wall within a certain radius
        isAWall = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.35f, transform.position.y - 0.5f),
        new Vector2(transform.position.x + 0.35f, transform.position.y - 0.5f), wallMask);

        isVictory = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
        new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), winMask);

        if(isVictory)
        {
        
                createFirework();

            
        }


        if (isAWall) // if the player touches the wall
        {
            bouncingSound.Play(); // play sound bounce
            isAWall = false; // set to false until the player is touching the wall
        }

        if (isGrounded) // We do not want the player to be moving in air
        { // However, they are allowed to launch themselves at a certain speed x, and height, y
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // move horizontally in air
            if (landSound) // if true
            {
                landingSound.Play(); // play the landing sound
                landSound = false;
            }
        }

        if(isGrounded == false)
        {
            speed = startingSpeed; //resetting speed
            landSound = true; // reset it to true so when the player is in the air, it will play the sound upon impact
        }

        // left side is negative while the right side is positive
        if (moveInput > 0) // if the player moved to the right
        {
            faceRight();
        }
        if (moveInput < 0) // if the player moved to the left
        {
            faceLeft();
        }

        // checks if the player is holding both Space bar and (A or D keys)
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && isGrounded && Input.GetKey(KeyCode.Space))
        {
            speed += 0.2f; // horizontal
            if (speed >= 10) // can never exceed 30 speed, this is the cap
            {
                speed = 10;
            }
        }

        // checks if the player is holding space bar which charges the jump value
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            jumpValue += 0.8f; // vertical
            rb.velocity = new Vector2(0.0f, rb.velocity.y); // effect the y axis only
            if (jumpValue >= maxJump) // never exceed the max jump value
            {
                jumpValue = maxJump;
            }
            Invoke("resetJump", 0.4f); // stops it from jumping constantly with delay
            

        }

        if (jumpValue >= maxJump && isGrounded) // the player is forced to jump after holding in their power (just a joke)
        {
            jumpSound.Play(); // play jumping sound
            createDust(); // creates dust effects
            float tempx = moveInput * speed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy); // jumps
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isGrounded)
            {
                jumpSound.Play();

                createDust();
                rb.velocity = new Vector2(moveInput * speed, jumpValue);
                jumpValue = 0.0f;
            }
            isJumping = true;
        }

    }

    void resetJump()
    {
        isJumping = false;
        jumpValue = startingJump;
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

    void createFirework()
    {
        Fireworks.Play();
    }
    void stopFirework()
    {
        Fireworks.Stop();
    }



}