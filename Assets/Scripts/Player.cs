using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Singleton
    public static Player player;

    // Public members
    public float speed = 8f;
    public float gravity = -9;
    public LayerMask whatIsGround;
    public float waitOnDeath;
 
    // Components
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D mCollider;
    private Animator playerAnimator;

    // Private members
    private bool isGrounded = true;
    private float horizontal;
    private bool isFacingRight = true;
    bool isDying = false;

    //private GameObject gC;
    private GameController gameController;

    // Public members
    [HideInInspector]
    public bool facingUp = true;
    public Vector2 spawnPoint = new(0.0f, 0.0f);


    void Awake()
    {
        if (Player.player == null) Player.player = this;
        else Destroy(this.gameObject);
    }

   void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gemstone"))
        {

            int sceneIndex = SceneManager.GetActiveScene().buildIndex-1;
            GameController.gC.gemstonesDestroyed[sceneIndex] = true;
            other.gameObject.SetActive(false);
            gameController.AddGemstone();
        }
    }
    IEnumerator ManageDeath()
    {
        isDying = true;
        playerAnimator.SetBool("isDying", true);
  
        rb.Sleep();
        if (gravity > 0.0f)
        {
            FlipVertically();
            gravity *= -1;
        }

        yield return new WaitForSeconds(waitOnDeath);

        gameController.RespawnPlayer(this);
        playerAnimator.SetBool("isDying", false);
        isDying = false;
        rb.WakeUp();
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

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !isDying)
        {
            // invertimos la gravedad y el sprite del personaje

            gravity = -gravity;
            FlipVertically();
        }


    }
}