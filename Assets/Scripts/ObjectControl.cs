using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject obstacleObject;
    public GameObject gateObject;

    [Header("Movement Settings")]
    public bool canMovePlayer = true;
    public bool canMoveObstacle = true;
    public bool canMoveGate = true;

    public float speed = 8f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the object is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (playerObject != null && this.gameObject == playerObject && canMovePlayer)
        {
            HandlePlayerInput();
        }
        else if (this.gameObject == obstacleObject && canMoveObstacle)
        {
            HandleObstacleOrGateInput();
        }
        else if (this.gameObject == gateObject && canMoveGate)
        {
            HandleObstacleOrGateInput();
        }
    }

    void HandlePlayerInput()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void HandleObstacleOrGateInput()
    {
        // Shared obstacle/gate control logic
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Implement any additional shared logic here
    }
}
