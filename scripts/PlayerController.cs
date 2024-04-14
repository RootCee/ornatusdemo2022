using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public GameObject attackPrefab;
    public Transform attackSpawnPoint;
    public Rigidbody2D rb;
    public int maxHealth = 100;
    private int currentHealth;

    private bool isGrounded = false;
    private Vector2 moveInput;

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Instantiate(attackPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement player death logic
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Implement item collection logic
            Destroy(other.gameObject);
        }
    }
}
