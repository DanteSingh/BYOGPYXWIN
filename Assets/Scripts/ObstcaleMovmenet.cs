using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleMovmenet : MonoBehaviour
{public float moveSpeed = 5f;
    public float jumpHeight = 1f;
    public float jumpDuration = 0.5f;

    private bool isJumping = false;
    private float jumpStartTime;
    private Vector2 initialPosition;
    private float horizontalInput;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Handle jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            StartJump();
        }

        // If jumping, calculate the new position
        if (isJumping)
        {
            float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;
            if (jumpProgress < 1f)
            {
                // Calculate the new position based on the jump curve and horizontal movement
                float jumpHeightOffset = Mathf.Sin(jumpProgress * Mathf.PI);
                float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime;
                transform.position = new Vector2(transform.position.x + horizontalMovement, initialPosition.y + jumpHeightOffset * jumpHeight);
            }
            else
            {
                // End the jump
                EndJump();
            }
        }
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement
        float horizontalMovement = horizontalInput * moveSpeed * Time.fixedDeltaTime;
        transform.position = new Vector2(transform.position.x + horizontalMovement, transform.position.y);
    }

    private void StartJump()
    {
        isJumping = true;
        jumpStartTime = Time.time;
    }

    private void EndJump()
    {
        isJumping = false;
        transform.position = new Vector2(transform.position.x, initialPosition.y); // Reset the object's Y position to the ground
    }
}
