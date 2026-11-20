using UnityEngine;

/// <summary>
/// Mueve un proyectil en línea recta y lo hace girar. Lo usan el shuriken y los ataques del jefe.
/// </summary>
public class Proyectil : MonoBehaviour
{
    public Vector2 direccion = Vector2.right;
    public float velocidad = 10.0f;
    public float giro = 720.0f;
    public float tiempoDeVida = 3.0f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direccion.normalized * velocidad;
        rb.angularVelocity = giro;
        Destroy(gameObject, tiempoDeVida);
    }
}