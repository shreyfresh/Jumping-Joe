using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBetterJumping : MonoBehaviour
{
    private Rigidbody2D rb;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
