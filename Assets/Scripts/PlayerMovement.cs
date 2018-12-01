using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float moveSpeed = 75f, jumpValue = 1500f;
    private Rigidbody2D rb;
    private bool jumped = false, doubleJumped = false;
    Controls controls;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = GetComponent<Controls>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = 0, yDir = 0;

        if (Input.GetKeyDown(controls.Jump))
        {
            // Jump
            if (!jumped)
            {
                yDir += 1;
                jumped = true;
            }   
            else if (!doubleJumped)
            {
                yDir += 1;
                doubleJumped = true;
            }
        }

        if (Input.GetKey(controls.Left))
        {
            // Move left
            xDir -= 1;
        }

        if (Input.GetKey(controls.Right))
        {
            // Move right
            xDir += 1;
        }

        rb.AddForce(new Vector2(xDir * moveSpeed, yDir * jumpValue));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.GetHashCode() == "Floor".GetHashCode())
        {
            // If we've landed on the floor, we can jump again
            jumped = false;
            doubleJumped = false;
        }
    }
}
