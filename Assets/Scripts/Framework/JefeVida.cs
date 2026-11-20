using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Vida del mini jefe y del jefe final. Al llegar a 0, el jugador gana el nivel.
/// </summary>
public class JefeVida : MonoBehaviour
{
    public static Action OnJefeGolpeado;
    public Action OnVidaCambio;

    public int vidaMaxima = 5;
    public GameObject efectoGolpe;
    public GameObject efectoDerrota;
    public AudioClip sonidoGolpe;

    public int Vida { get; private set; }

    private SpriteRenderer sprite;
    private Color colorOriginal;
    private bool derrotado;

    void Awake()
    {
        Vida = vidaMaxima;
        sprite = GetComponent<SpriteRenderer>();
        if (sprite != null) colorOriginal = sprite.color;
    }

    public void RecibirDanio(int danio)
    {
        if (derrotado) return;

        Vida -= danio;
        OnVidaCambio?.Invoke();
        OnJefeGolpeado?.Invoke();
        Efectos.Crear(efectoGolpe, transform.position);
        Efectos.Sonar(sonidoGolpe);
        StartCoroutine(Parpadeo());

        if (Vida <= 0)
        {
            derrotado = true;
            Efectos.Crear(efectoDerrota, transform.position);
            GameManager.Instance.Ganar();
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Corrutina: pinta al jefe de rojo un instante cuando recibe daño.
    /// </summary>
    private IEnumerator Parpadeo()
    {
        if (sprite == null) yield break;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = colorOriginal;
    }
}