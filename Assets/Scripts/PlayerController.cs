using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 7.0f;
    public float jumpHeight = 10.0f;
    public float gravityScale = 1.5f;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Rigidbody2D rb;
    CapsuleCollider2D mainCollider;
    Transform t;
    private float moveValue = 0f;

    // UI
    public Text coinsText;
    public Text livesText;
    public GameObject message;
    public Text messageText;
    public GameObject gameOver;
    public GameObject restartButton;
    private static int coins;
    private static int lives = 1;

    // Audio
    public AudioSource audioCoin;
    public AudioSource audioLife;
    public AudioSource audioLifeLost;
    public AudioSource audioLose;

    void Start()
    {
        t = transform;
        rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        coinsText = GameObject.Find("CoinsText").GetComponent<Text>();
        coinsText.text = coins.ToString();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        livesText.text = lives.ToString();
        gameOver.SetActive(false);
        restartButton.SetActive(false);
        message.SetActive(false);
        Time.timeScale = 1f;
        Physics2D.IgnoreLayerCollision(0, 7);
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && (isGrounded || Mathf.Abs(rb.velocity.x) > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
            moveValue = 1f;
        }
        else
        {
            if (isGrounded || rb.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
                moveValue = 0f;
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);

        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);

        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        rb.velocity = new Vector2((moveDirection) * maxSpeed, rb.velocity.y);

        // Apply animation
        gameObject.GetComponent<Animator>().SetFloat("MoveValue", System.Math.Abs(Input.GetAxis("Horizontal")));

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, mainCollider.bounds))
        {
            Lose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinsText.text = coins.ToString();
            audioCoin.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", true);
            audioLifeLost.Play();
            lives--;
            livesText.text = lives.ToString();
            if (lives == 0) Lose();
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            lives++;
            livesText.text = lives.ToString();
            audioLife.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().name == "Level1") {
                messageText.text = coins.ToString() + " coins will buy some masks, thanks (you already have a helmet).\n\nSecond wave is coming...";
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                messageText.text = "Please hurry.\n\nWe think we saw walking trees...";
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                messageText.text = "You're our hero!\n\nScientists will make the vaccine and everyone will be safe again.";
                GameObject.Find("Music").GetComponent<AudioSource>().Stop();
                GameObject.Find("MusicEnd").GetComponent<AudioSource>().Play();
            }
            message.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Lose()
    {
        coins = 0;
        lives = 1;
        audioLose.Play();
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();
        Time.timeScale = 0;
        gameOver.SetActive(true);
        restartButton.SetActive(true);
    }
}