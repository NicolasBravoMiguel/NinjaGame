using UnityEngine;

/// <summary>
/// Envía al Animator el estado del jugador: velocidad, si está en el suelo y si está trepando.
/// El trigger "Attack" lo activa PlayerAtaque.
/// </summary>
public class PlayerAnimacion : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerMovement movimiento;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movimiento = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("Grounded", movimiento.IsGrounded);
        animator.SetBool("Climbing", movimiento.EnEscalera);
    }
}
