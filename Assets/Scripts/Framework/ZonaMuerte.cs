using UnityEngine;

/// <summary>
/// Zona debajo del nivel: quita una vida si el jugador cae y borra todo lo demás.
/// </summary>
public class ZonaMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.TAG_PLAYER))
        {
            GameManager.Instance.JugadorGolpeado();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}