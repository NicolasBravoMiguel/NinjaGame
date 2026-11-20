using System.Collections;
using UnityEngine;

/// <summary>
/// Comportamiento del jefe final: va y viene entre dos puntos y dispara en abanico.
/// Con la mitad de vida entra a la fase 2: más rápido y más proyectiles.
/// </summary>
public class JefeFinal : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3.0f;
    public float pausaEntreAtaques = 1.5f;
    public float apertura = 15.0f;

    private JefeVida vida;
    private Transform player;

    void Start()
    {
        vida = GetComponent<JefeVida>();
        player = GameObject.FindWithTag(Constants.TAG_PLAYER).transform;
        StartCoroutine(Comportamiento());
    }

    private bool EnFase2()
    {
        return vida.Vida <= vida.vidaMaxima / 2;
    }

    private IEnumerator Comportamiento()
    {
        Transform destino = puntoA;
        while (true)
        {
            float velocidadActual = EnFase2() ? velocidad * 1.6f : velocidad;
            while (Vector2.Distance(transform.position, destino.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidadActual * Time.deltaTime);
                yield return null;
            }

            destino = (destino == puntoA) ? puntoB : puntoA;
            Disparar();
            yield return new WaitForSeconds(pausaEntreAtaques);
        }
    }

    private void Disparar()
    {
        int cantidad = EnFase2() ? 5 : 3;
        Vector2 haciaJugador = (player.position - transform.position).normalized;

        for (int i = 0; i < cantidad; i++)
        {
            float angulo = (i - (cantidad - 1) / 2f) * apertura;
            Vector2 direccion = Quaternion.Euler(0, 0, angulo) * haciaJugador;
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
            proyectil.GetComponent<Proyectil>().direccion = direccion;
        }
    }
}