using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; // Speed of player movement
    [SerializeField] private float jumpHeight = 5f; // Height of player jump
    [SerializeField] private bool isGrounded = false; // Tracks if the player is on the ground
    [SerializeField] private Rigidbody2D rb; // Player's Rigidbody2D component

    [SerializeField] private KeyCode moveLeft = KeyCode.A; // Key for moving left
    [SerializeField] private KeyCode moveRight = KeyCode.D; // Key for moving right
    [SerializeField] private KeyCode jumpKey = KeyCode.Space; // Key for jumping
    [SerializeField] private KeyCode shootKey = KeyCode.None; // Key for shooting (placeholder)

    private enum PlayerState { Idle, MovingLeft, MovingRight, Jumping }
    private PlayerState currentState = PlayerState.Idle;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Handle horizontal movement
        if (Input.GetKey(moveLeft))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            currentState = isGrounded ? PlayerState.MovingLeft : currentState;
        }
        else if (Input.GetKey(moveRight))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            currentState = isGrounded ? PlayerState.MovingRight : currentState;
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            currentState = PlayerState.Idle;
        }

        // Handle jumping
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded = false;
            currentState = PlayerState.Jumping;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            currentState = PlayerState.Idle;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
