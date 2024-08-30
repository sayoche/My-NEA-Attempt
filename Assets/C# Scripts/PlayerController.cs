using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Animator animator;
    private bool isFacingRight = true;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
        UpdatePlayerFacingDirection();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void UpdatePlayerFacingDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePosition.x < playerScreenPoint.x && isFacingRight)
        {
            RotatePlayer();
        }
        else if (mousePosition.x > playerScreenPoint.x && !isFacingRight)
        {
            RotatePlayer();
        }
    }

    private void RotatePlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the x-axis scale to mirror the sprite
        transform.localScale = scale;
    }

    private void ProcessInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("MovingX", movement.x);
        animator.SetFloat("MovingY", movement.y);
    }
}
