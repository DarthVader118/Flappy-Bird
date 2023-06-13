using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float jumpForce;

    [SerializeField]
    GameController gameController;
    
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // jump mechanic
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * jumpForce; 
        }

        if (transform.position.y > GameController.SCREENTOP || transform.position.y < GameController.SCREENBOTTOM)
        {
            gameController.endGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hello");
        gameController.endGame();
    }
}
