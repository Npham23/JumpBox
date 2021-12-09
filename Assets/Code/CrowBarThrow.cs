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
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Destroy(gameObject, 10f); // disappear if it never hits
    }

    private void Update()
    {
        target = GameObject.FindObjectOfType<PlayerMovement>(); // find player
        direction = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);
    }

 
}
