using UnityEngine;

/// <summary>
/// Hace que la lava suba sin parar, como el MoveForward de los autobuses.
/// Cuando el jugador reaparece, la lava regresa a su posición inicial.
/// </summary>
public class Lava : MonoBehaviour
{
    public float speed = 0.8f;
    public float espera = 2.0f;

    private Vector3 posicionInicial;
    private float tiempoEspera;

    void Start()
    {
        posicionInicial = transform.position;
        tiempoEspera = espera;
    }

    private void OnEnable()
    {
        GameManager.OnJugadorReaparecio += Reiniciar;
    }

    private void OnDisable()
    {
        GameManager.OnJugadorReaparecio -= Reiniciar;
    }

    void Update()
    {
        if (tiempoEspera > 0)
        {
            tiempoEspera -= Time.deltaTime;
            return;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void Reiniciar()
    {
        transform.position = posicionInicial;
        tiempoEspera = espera;
    }
}