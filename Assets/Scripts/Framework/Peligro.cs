using UnityEngine;

/// <summary>
/// Quita una vida al tocar al jugador, sea trigger (ninja, proyectiles) o choque físico (barriles).
/// </summary>
public class Peligro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Golpear(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Golpear(collision.gameObject);
    }

    private void Golpear(GameObject objeto)
    {
        if (objeto.CompareTag(Constants.TAG_PLAYER))
        {
            GameManager.Instance.JugadorGolpeado();
        }
    }
}