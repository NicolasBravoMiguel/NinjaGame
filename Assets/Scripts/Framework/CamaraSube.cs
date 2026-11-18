using UnityEngine;

/// <summary>
/// Cámara que sigue al jugador suavemente hacia arriba y hacia abajo.
/// Nunca baja más allá de la lava ni sube más allá de la meta.
/// </summary>
public class CamaraSube : MonoBehaviour
{
    public GameObject player;
    public Collider2D lava;
    public float adelante = 2.0f;      // cuánto ve por encima del jugador
    public float suavizado = 3.0f;     // qué tan rápido se mueve hacia el jugador
    public float margenLava = 1.0f;    // cuánta lava se ve en el borde de abajo
    public float alturaMaxima = 25.0f; // donde se detiene (a la altura de la Meta)

    private Vector3 posicionInicial;
    private Camera camara;

    void Start()
    {
        camara = GetComponent<Camera>();
        posicionInicial = transform.position;
    }

    private void OnEnable()
    {
        GameManager.OnJugadorReaparecio += Reiniciar;
    }

    private void OnDisable()
    {
        GameManager.OnJugadorReaparecio -= Reiniciar;
    }

    void LateUpdate()
    {
        // 1. A dónde quiere ir: un poco arriba del jugador
        float objetivo = player.transform.position.y + adelante;

        // 2. Lo más abajo que puede ir: que la lava apenas se vea en el borde inferior
        float superficieLava = lava.bounds.max.y;
        float minimo = superficieLava - margenLava + camara.orthographicSize;

        // 3. Respeta los límites (no bajo la lava, no arriba de la meta)
        objetivo = Mathf.Max(objetivo, minimo);
        objetivo = Mathf.Min(objetivo, alturaMaxima);

        // 4. Se mueve poco a poco hacia ese punto
        float y = Mathf.Lerp(transform.position.y, objetivo, suavizado * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    /// <summary>
    /// Cuando el jugador reaparece abajo, la cámara regresa de golpe al inicio.
    /// </summary>
    private void Reiniciar()
    {
        transform.position = posicionInicial;
    }
}