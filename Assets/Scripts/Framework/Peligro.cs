using UnityEngine;

/// <summary>
/// Todo objeto con este script le quita una vida al jugador al tocarlo.
/// </summary>
public class Peligro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.TAG_PLAYER))
        {
            GameManager.Instance.JugadorGolpeado();
        }
    }
}