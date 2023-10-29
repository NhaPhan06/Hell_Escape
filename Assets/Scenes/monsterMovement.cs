using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 1.25f;
    private bool isFacingRight = true;
    private bool isPlayerMoving = false;
    [SerializeField] private float distanceThreshold = 10f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float health= 10f;
    [SerializeField] private float maxHealth= 10f;

    [SerializeField] private MonsterHealth MonsterHealth;

    private void Awake()
    {
        MonsterHealth = GetComponentInChildren<MonsterHealth>();
    }

    public void TakeDame(float damage)
    {
        health -= damage;
        MonsterHealth.UpdateHealthBar(health, 10); 
        if (maxHealth <= 0) ;
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        Vector3 monsterPosition = transform.position;

        horizontal = playerPosition.x - monsterPosition.x;

        // Disable jumping
        // rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        // Check if player is moving
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            isPlayerMoving = true;
        }
        else
        {
            isPlayerMoving = false;
        }

        // Check if player is close enough
        float distance = Vector3.Distance(playerPosition, monsterPosition);
        if (distance < distanceThreshold)
        {
            // Move monster
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            // Stop monster
            rb.velocity = Vector2.zero;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}