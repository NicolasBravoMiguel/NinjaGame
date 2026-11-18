using UnityEngine;

/// <summary>
/// Controla el movimiento horizontal y el salto del jugador.
/// Usa el Input Manager clásico, igual que el PlayerController de los laboratorios.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce = 12.0f;
    public float horizontalInput;

    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    /// <summary>
    /// Se llama antes del primer frame: guarda la referencia al Rigidbody2D.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Se llama una vez por frame: lee el teclado, mueve al jugador y salta.
    /// </summary>
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}