using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 17;
    [SerializeField]
    private float wallPush = 17;
    [SerializeField]
    private float wallDrag = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;
    [SerializeField]
    private float jumpVelocity;

    private PlayerInputSystem playerInputSystem;
    private InputAction movement;
    private Rigidbody2D rb;
    private Vector2 initialGravity;
    private bool wallDragFallReset = false;
    private bool canJump = false;
    private bool pushOff = false;
    private bool canPushOff = false;
    private float pushOffDirection;

    private void Awake()
    {
        initialGravity = Physics2D.gravity;
        rb = GetComponent<Rigidbody2D>();
        playerInputSystem = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        movement = playerInputSystem.Player.Movement;
        movement.Enable();
        playerInputSystem.Player.Jump.started += Jump;
        playerInputSystem.Player.Jump.Enable();
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (wallDragFallReset)
        {
            if (transform.position.x > 0)
            {
                rb.AddForce(Vector2.left * wallPush);
            }
        }

        if (pushOff)
        {
            pushOff = false;
            canPushOff = true;
        }

        if (canJump)
        {
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputSystem.Player.Jump.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.ReadValue<float>() * speed, rb.velocity.y);
        rb.velocity += new Vector2(0, Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        if (canPushOff)
        {
            canPushOff = false;
            rb.AddForce(new Vector2 (pushOffDirection * wallPush, 0), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rb.velocity.y < 0 && collision.gameObject.CompareTag("Wall") && movement.ReadValue<float>() != 0)
        {
            if (!wallDragFallReset)
            {
                pushOffDirection = movement.ReadValue<float>() * -1;
                wallDragFallReset = true;
                canJump = true;
                pushOff = true;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

            Physics2D.gravity /= wallDrag;
        }
        else
        {
            wallDragFallReset = false;
            Physics2D.gravity = initialGravity;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallDragFallReset = false;
        }
    }


}
