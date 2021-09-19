using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public static Player_Controller instance;

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
    private Animator animator;
    private SpriteRenderer renderer;
    private bool falling;

    [Header("On hit player variables")]
    [SerializeField] Transform initialPosition;
    public UnityEvent onPlayerHit;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        renderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
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
            GetComponent<SoundEvent>().PlayClipByIndex(5);
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);

        if (parry.ReadValue<Vector2>().magnitude > .3 && !parrying)
        {
            animator.SetTrigger("parrying");
            StartParry();
        }

        if (rb.velocity.y < 0)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }

        ParryCooldown();
        Animate();
    }

    private void Animate()
    {
        if (movement.ReadValue<float>() > .3)
        {
            renderer.flipX = false;
            animator.SetBool("running", true);
        }
        else if (movement.ReadValue<float>() < -.3)
        {
            renderer.flipX = true;
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        if (rb.velocity.y > 0)
        {
            animator.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
        else
        {
            animator.SetBool("falling", false);
        }
    }

    private void FixedUpdate()
    {
        if (movement.ReadValue<float>() > .3 || movement.ReadValue<float>() < -.3)
        {
            rb.velocity = new Vector2(movement.ReadValue<float>() * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

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
        else if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
            if (falling)
            {
                
                transform.SetParent(collision.gameObject.transform);
            }
        }else if(collision.gameObject.CompareTag("Parryable") || collision.gameObject.CompareTag("Damage"))
        {
            onPlayerHit.Invoke();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rb.velocity.y < 0 && collision.gameObject.CompareTag("Wall") && movement.ReadValue<float>() != 0)
        {
            if (!wallDragFallReset)
            {
                animator.SetBool("sliding", true);
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
            animator.SetBool("sliding", false);
            pushOff = false;
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
        Debug.Log(collision.transform.tag);
        if (collision.gameObject.CompareTag("Wall"))
        {
            animator.SetBool("sliding", false);
            pushOff = false;
            wallDragFallReset = false;
            Physics2D.gravity = initialGravity;
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
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
            else if (GetParryDirection().magnitude <= .3)
            {
                GetComponent<SoundEvent>().PlayClipByIndex(4);
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

    public void TranslatePlayerToInitialPosition()
    {
        if (instance.transform.parent != null)
            instance.transform.SetParent(null);
        instance.transform.position = initialPosition.position;
    }
}
