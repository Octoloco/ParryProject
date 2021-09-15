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
    [SerializeField]
    private float parryCooldown;
    [SerializeField]
    private GameObject parryArea;

    private Vector2 parryDirection;
    private float parryCooldownTimer = 0;
    private bool cooldownStart = false;
    private PlayerInputSystem playerInputSystem;
    private InputAction movement;
    private InputAction parry;
    private Rigidbody2D rb;
    private Parry parryScript;
    private Vector2 initialGravity;
    private bool wallDragFallReset = false;
    private bool canJump = false;
    private bool pushOff = false;
    private bool canPushOff = false;
    private float pushOffDirection;
    private bool parrying = false;

    private void Awake()
    {
        initialGravity = Physics2D.gravity;
        rb = GetComponent<Rigidbody2D>();
        parryScript = GetComponent<Parry>();
        playerInputSystem = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        movement = playerInputSystem.Player.Movement;
        movement.Enable();
        parry = playerInputSystem.Player.Parry;
        parry.Enable();
        playerInputSystem.Player.Jump.started += Jump;
        playerInputSystem.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        parry.Disable();
        playerInputSystem.Player.Jump.Disable();
    }

    public void FinishedParrying()
    {
        cooldownStart = true;
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

    private void Update()
    {
        if (parry.ReadValue<Vector2>().magnitude > 0 && !parrying)
        {
            StartParry();
        }

        ParryCooldown();
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

    public Vector2 GetParryDirection()
    {
        return parry.ReadValue<Vector2>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallDragFallReset = false;
            Physics2D.gravity = initialGravity;
        }
    }

    public void StartParry()
    {
        parrying = true;
        if (parryCooldownTimer <= 0)
        {
            StartCoroutine(WaitForDirection());
        }

        parryCooldownTimer = parryCooldown;
    }

    private void ParryCooldown()
    {
        if (cooldownStart)
        {
            if (parryCooldownTimer > 0)
            {
                parryCooldownTimer -= Time.deltaTime;
            }
            else if (GetParryDirection().magnitude <= 0)
            {
                cooldownStart = false;
                parrying = false;
            }
        }
    }

    IEnumerator WaitForDirection()
    {
        yield return new WaitForSeconds(.05f);
        cooldownStart = true;
        parryDirection = GetParryDirection();
        if (parryDirection.magnitude > 0)
        {
            parryArea.SetActive(true);
        }
        else
        {
            parryCooldownTimer = 0;
        }
    }


}
