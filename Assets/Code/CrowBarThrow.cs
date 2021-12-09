using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowBarThrow : MonoBehaviour
{
    GameObject player;
    float speed = 5.0f; // speed of crowbar
    Rigidbody rb;

    PlayerMovement target; // player is the target
    Vector2 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerMovement>(); // find player
        moveDirection = (target.transform.position - transform.position).normalized * speed; 
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 10f); // disappear if it never hits
    }

    void onTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // game over
        }
    }
}
