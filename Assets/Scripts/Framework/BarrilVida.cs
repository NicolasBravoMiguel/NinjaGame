using System.Collections;
using UnityEngine;

/// <summary>
/// Vida del barril: se rompe después de recibir 2 golpes de shuriken.
/// </summary>
public class BarrilVida : MonoBehaviour
{
    public int vida = 2;
    public GameObject efectoRomper;

    private SpriteRenderer sprite;
    private Color colorOriginal;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (sprite != null) colorOriginal = sprite.color;
    }

    public void RecibirDanio(int danio)
    {
        vida -= danio;

        if (vida <= 0)
        {
            Efectos.Crear(efectoRomper, transform.position);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Parpadeo());
        }
    }

    /// <summary>
    /// Corrutina: pinta el barril de rojo un instante al recibir el primer golpe.
    /// </summary>
    private IEnumerator Parpadeo()
    {
        if (sprite == null) yield break;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = colorOriginal;
    }
}