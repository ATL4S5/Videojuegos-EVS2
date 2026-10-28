using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Detección de Suelo")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip walkClip;
    [SerializeField] private float footstepInterval = 0.4f;
    private float footstepTimer;

    [Header("Referencias Visuales y Animación")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();

        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        // Lógica de Salto
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump")) && isGrounded)
        {
            Jump();
        }

        HandleFootsteps();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0f && spriteRenderer != null)
        {
            spriteRenderer.flipX = horizontalInput < 0f;
        }

        if (animator != null)
        {
            animator.SetBool("isRunning", horizontalInput != 0f);
        }
    }

    private void HandleFootsteps()
    {
        if (horizontalInput != 0f && isGrounded)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0f)
            {
                if (audioSource != null && walkClip != null)
                {
                    audioSource.PlayOneShot(walkClip);
                }
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        if (audioSource != null && jumpClip != null)
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}