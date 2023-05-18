using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    
    public float respawnHeight = 1f;
    public GameObject heartIconPrefab;
    public float heartIconSpacing = 20f;

    private float screenWidth;
    private float screenHeight;
    private SpriteRenderer[] spriteRenderers;
    private Coroutine brightenCoroutine;
    private SpriteRenderer[] heartIcons1;
    private SpriteRenderer[] heartIcons2;

    private int lives1 = 3;
    private int lives2 = 3;
    private Transform canvasTransform;
    public GameObject gameOverObject;
    public SpriteRenderer GameOverbackground;

    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float jumpForce = 7f;
    public float fallSpeed = 2f;
    public int maxJumpCount = 2;
    public Transform groundCheck;
    public LayerMask platformLayer;
    
    private Rigidbody2D rb;
    private int jumpCount;
    private bool isGrounded;
    private float horizontalInput;

    public int controlScheme = 1;
    public bool facingRight = true;
    public Launcher launcher;
    
    
    void Start()
    {
        gameOverObject.SetActive(false);
        GameOverbackground.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight * Camera.main.aspect;
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        heartIcons1 = new SpriteRenderer[lives1];
        heartIcons2 = new SpriteRenderer[lives2];


        GameObject heart1 = GameObject.Find("Heart1");
        heart1.transform.position = new Vector3(-8f, -4.19f, 0f);
        if (lives1 >= 1) heartIcons1[0] = heart1.GetComponent<SpriteRenderer>();

        GameObject heart2 = GameObject.Find("Heart2");
        heart2.transform.position = new Vector3(-6.5f, -4.19f, 0f);
        if (lives1 >= 2) heartIcons1[1] = heart2.GetComponent<SpriteRenderer>();

        GameObject heart3 = GameObject.Find("Heart3");
        heart3.transform.position = new Vector3(-5f, -4.19f, 0f);
        if (lives1 >= 3) heartIcons1[2] = heart3.GetComponent<SpriteRenderer>();

        GameObject heart4 = GameObject.Find("Heart4");
        heart4.transform.position = new Vector3(8f, -4.19f, 0f);
        if (lives2 >= 1) heartIcons2[0] = heart4.GetComponent<SpriteRenderer>();

        GameObject heart5 = GameObject.Find("Heart5");
        heart5.transform.position = new Vector3(6.5f, -4.19f, 0f);
        if (lives2 >= 2) heartIcons2[1] = heart5.GetComponent<SpriteRenderer>();

        GameObject heart6 = GameObject.Find("Heart6");
        heart6.transform.position = new Vector3(5f, -4.19f, 0f);
        if (lives2 >= 3) heartIcons2[2] = heart6.GetComponent<SpriteRenderer>();

        
    }


    void Update()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);

if (controlScheme == 1)
{
    // Player 1
    if (Input.GetKeyDown(KeyCode.F)) launcher.Shoot();

if (Input.GetKeyDown(KeyCode.G)) launcher.nextGun();
    horizontalInput = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);

    if (isGrounded)
    {
        jumpCount = maxJumpCount;

        // Check for drop down
        if (Input.GetKey(KeyCode.S))
        {
            StartCoroutine(DropDown());
        }
    }

    if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jumpCount--;
    }
    
}
else if (controlScheme == 2)
{
    // Player 2
    if (Input.GetKeyDown(KeyCode.Keypad0)) launcher.Shoot();

if (Input.GetKeyDown(KeyCode.KeypadPeriod)) launcher.nextGun();
    horizontalInput = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);

    if (isGrounded)
    {
        jumpCount = maxJumpCount;

        // Check for drop down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(DropDown2());
        }
    }

    if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jumpCount--;
    }
}

IEnumerator DropDown()
{
    // Set the player's Collider2D to ignore the platform's Collider2D
    Physics2D.IgnoreLayerCollision(6, 3, true);

    // Wait for a short amount of time
    yield return new WaitForSeconds(0.7f);

    // Re-enable the collision
    Physics2D.IgnoreLayerCollision(6, 3, false);
}
IEnumerator DropDown2()
{
    // Set the player's Collider2D to ignore the platform's Collider2D
    Physics2D.IgnoreLayerCollision(7, 3, true);

    // Wait for a short amount of time
    yield return new WaitForSeconds(0.7f);

    // Re-enable the collision
    Physics2D.IgnoreLayerCollision(7, 3, false);
}

        CheckOutOfBounds();
    }

    void FixedUpdate()
    {
        if (horizontalInput == -1 && facingRight) Flip();
        if (horizontalInput == 1 && !facingRight) Flip();
        float targetVelocityX = horizontalInput * moveSpeed;
        float velocityChangeX = (targetVelocityX - rb.velocity.x) * (Mathf.Approximately(horizontalInput, 0) ? deceleration : acceleration);
        velocityChangeX = Mathf.Clamp(velocityChangeX, -acceleration, acceleration) * Time.fixedDeltaTime;
        rb.velocity = new Vector2(rb.velocity.x + velocityChangeX, rb.velocity.y);
    }

    // IEnumerator DropThroughPlatform()
    // {
    // // Disable collisions between the sprite's collider and the Ground layer
    // Collider2D collider = GetComponent<Collider2D>();
    // Physics2D.IgnoreLayerCollision(collider.gameObject.layer, LayerMask.NameToLayer("Ground"), true);

    // // Wait for a short duration before re-enabling collisions
    // yield return new WaitForSeconds(0.5f);

    // // Re-enable collisions between the sprite's collider and the Ground layer
    // Physics2D.IgnoreLayerCollision(collider.gameObject.layer, LayerMask.NameToLayer("Ground"), false);




    private void CheckOutOfBounds()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y < 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        Vector3 respawnPosition = new Vector3(0f, Camera.main.transform.position.y + screenHeight / 2f + respawnHeight, 0f);
        transform.position = respawnPosition;
        rb.velocity = new Vector2(0, -fallSpeed);
        if (brightenCoroutine != null)
        {
            StopCoroutine(brightenCoroutine);
        }
        brightenCoroutine = StartCoroutine(BrightenCharacter());

        if (gameObject.name == "Character1")
        {
            lives1--;
            if (lives1 >= 0)
            {
                heartIcons1[lives1].enabled = false;
            }

            if (lives1 == 0)
            {
                gameOverObject.SetActive(true);
                GameOverbackground.enabled = true;
                Application.Quit();
            }
        }
        else if (gameObject.name == "Character2")
        {
            lives2--;
            if (lives2 >= 0)
            {
                heartIcons2[lives2].enabled = false;
            }

            if (lives2 == 0)
            {
                gameOverObject.SetActive(true);
                GameOverbackground.enabled = true;
                Application.Quit();
            }
        }
    }


    private IEnumerator BrightenCharacter()
    {
       
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.color = Color.black;
        }

        Color targetColor = Color.white;
        float duration = 3f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].color = Color.Lerp(Color.black, targetColor, elapsedTime / duration);
            }
            yield return null;
        }

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = targetColor;
        }
    }
    public void ResetLives()
    {
        lives1 = 3;
        lives2 = 3;
        foreach (SpriteRenderer sr in heartIcons1)
        {
            sr.enabled = true;
        }
        foreach (SpriteRenderer sr in heartIcons2)
        {
            sr.enabled = true;
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}