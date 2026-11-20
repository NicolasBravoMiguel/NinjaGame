using UnityEngine;

/// <summary>
/// Movimiento, salto y escaleras del jugador con el Input Manager clásico.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce = 12.0f;
    public float climbSpeed = 4.0f;
    public float horizontalInput;
    public float verticalInput;

    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundLayer;

    public GameObject efectoSalto;
    public AudioClip sonidoSalto;

    public bool IsGrounded { get; private set; }
    public bool EnEscalera { get; private set; }

    private Rigidbody2D rb;
    private float gravedadOriginal;
    private bool cercaDeEscalera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravedadOriginal = rb.gravityScale;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // Se agarra a la escalera solo si está cerca y presiona arriba o abajo
        if (cercaDeEscalera && Mathf.Abs(verticalInput) > 0.1f) EnEscalera = true;
        if (!cercaDeEscalera) EnEscalera = false;

        // Mientras escala, atraviesa las plataformas (capa Ground)
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer(Constants.CAPA_SUELO), EnEscalera);

        if (EnEscalera)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * climbSpeed);
        }
        else
        {
            rb.gravityScale = gravedadOriginal;
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded || EnEscalera))
        {
            EnEscalera = false;
            rb.gravityScale = gravedadOriginal;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Efectos.Crear(efectoSalto, groundCheck.position);
            Efectos.Sonar(sonidoSalto);
        }

        Voltear();
    }

    /// <summary>
    /// Voltea al jugador hacia donde camina (también voltea a sus hijos, como PuntoDisparo).
    /// </summary>
    private void Voltear()
    {
        if (horizontalInput == 0) return;
        Vector3 escala = transform.localScale;
        escala.x = Mathf.Sign(horizontalInput) * Mathf.Abs(escala.x);
        transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.TAG_ESCALERA)) cercaDeEscalera = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Constants.TAG_ESCALERA)) cercaDeEscalera = false;
    }
}