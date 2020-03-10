using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 10)]
    public float speed = 10f;
    [Range(1, 10)]
    public float jumpVelocity = 7f;
    [Range(1, 10)]
    public float fallMultiplier = 2.5f;
    [Range(1, 10)]
    public float lowJumpMultiplier = 2f;

    public Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

    }
}
