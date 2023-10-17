using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Public members
    public float speed = 8f;
    public float gravity = -9;
    public LayerMask whatIsGround;
    public float waitOnDeath;

    // Components
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D mCollider;
    private Animator playerAnimator;

    // Private members
    private bool isGrounded = true;
    private float horizontal;
    private bool isFacingRight = true;
    bool isDying = false;

    // Public members
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool facingUp = true;

    public Vector2 spawnPoint = new Vector2(0.0f, 0.0f);


   void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        RespondToGravityInput();
        Flip();
    }

    void FixedUpdate()
    {
        if (!isDying)
        {
            isGrounded = CheckIsGrounded();

            // De -1.0 a 1.0 al pulsar A o D
            horizontal = Input.GetAxisRaw("Horizontal");

            // Aplicamos la velocidad en X y la gravedad en Y
            rb.velocity = new Vector2(horizontal * speed, isGrounded ? 0.0f : gravity);

            playerAnimator.SetBool("isWalking", false);

            if (horizontal > 0.0f || horizontal < 0.0f)
            {
                playerAnimator.SetBool("isWalking", true);
            }
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            StartCoroutine(ManageDeath());
        }
    }
    IEnumerator ManageDeath()
    {

        isDying = true;
        playerAnimator.SetBool("isDying", true);

        rb.Sleep();

        yield return new WaitForSeconds(waitOnDeath);

        playerAnimator.SetBool("isDying", false);

        if (gravity > 0.0f)
        {
            FlipVertically();
            gravity *= -1;
        }

        transform.position = spawnPoint;

        rb.WakeUp();

        isDying = false;
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
    private void FlipVertically()
    {
        facingUp = !facingUp;
        Vector2 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
    bool CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(mCollider.bounds.center, mCollider.bounds.size, 0f, facingUp ? Vector2.down : Vector2.up, 0.1f, whatIsGround);

        return raycastHit.collider != null;
    }


    void RespondToGravityInput()
    {
        // Al pulsar la W, solo si el personaje está grounded

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            // invertimos la gravedad y el sprite del personaje

            gravity = -gravity;
            FlipVertically();
        }


    }
}