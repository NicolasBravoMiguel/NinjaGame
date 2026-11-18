using UnityEngine;

/// <summary>
/// Al tocar la meta, el jugador gana el nivel.
/// </summary>
public class Meta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.TAG_PLAYER))
        {
            GameManager.Instance.Ganar();
        }
    }
}