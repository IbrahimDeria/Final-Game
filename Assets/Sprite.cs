using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float jumpForce = 7f;
    public int maxJumpCount = 2;
    public Transform groundCheck;
    public LayerMask platformLayer;
    
    private Rigidbody2D rb;
    private int jumpCount;
    private bool isGrounded;
    private float horizontalInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);

        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }


        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0 && isGrounded)
    {
        StartCoroutine(DropThroughPlatform());
    }
    }

    void FixedUpdate()
    {
        float targetVelocityX = horizontalInput * moveSpeed;
        float velocityChangeX = (targetVelocityX - rb.velocity.x) * (Mathf.Approximately(horizontalInput, 0) ? deceleration : acceleration);
        velocityChangeX = Mathf.Clamp(velocityChangeX, -acceleration, acceleration) * Time.fixedDeltaTime;
        rb.velocity = new Vector2(rb.velocity.x + velocityChangeX, rb.velocity.y);
    }

    IEnumerator DropThroughPlatform()
{
    // Disable collisions between the sprite's collider and the Ground layer
    Collider2D collider = GetComponent<Collider2D>();
    Physics2D.IgnoreLayerCollision(collider.gameObject.layer, LayerMask.NameToLayer("Ground"), true);

    // Wait for a short duration before re-enabling collisions
    yield return new WaitForSeconds(0.5f);

    // Re-enable collisions between the sprite's collider and the Ground layer
    Physics2D.IgnoreLayerCollision(collider.gameObject.layer, LayerMask.NameToLayer("Ground"), false);
}
}
