using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Administra la partida: vidas, victoria, derrota y reinicio.
/// Lanza eventos con Action.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Action OnVidasCambiaron;
    public static Action OnJugadorReaparecio;

    public static int Vidas { get; private set; }

    public GameObject player;
    public Transform puntoDeInicio;
    public GameObject panelGameOver;
    public GameObject panelVictoria;
    public float tiempoReaparicion = 1.0f;

    private bool partidaTerminada;
    private bool reapareciendo;

    /// <summary>
    /// Se llama al crear el objeto: guarda la instancia para que otros scripts la usen.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Inicializa la partida con 3 vidas y oculta los paneles.
    /// </summary>
    void Start()
    {
        Time.timeScale = 1;
        Vidas = Constants.VIDAS_INICIALES;
        panelGameOver.SetActive(false);
        panelVictoria.SetActive(false);
        OnVidasCambiaron?.Invoke();
    }

    /// <summary>
    /// Si la partida terminó, la tecla R recarga la escena.
    /// </summary>
    void Update()
    {
        if (partidaTerminada && Input.GetKeyDown(Constants.TECLA_REINICIO))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Quita una vida. Con 0 vidas muestra Game Over. Si no, el jugador reaparece.
    /// </summary>
    public void JugadorGolpeado()
    {
        if (partidaTerminada || reapareciendo) return;

        Vidas--;
        OnVidasCambiaron?.Invoke();

        if (Vidas <= 0)
        {
            partidaTerminada = true;
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(Reaparecer());
        }
    }

    /// <summary>
    /// Muestra la pantalla de victoria y detiene el juego.
    /// </summary>
    public void Ganar()
    {
        if (partidaTerminada) return;
        partidaTerminada = true;
        panelVictoria.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Corrutina: oculta al jugador, espera y lo regresa al punto de inicio.
    /// </summary>
    private IEnumerator Reaparecer()
    {
        reapareciendo = true;
        player.SetActive(false);

        yield return new WaitForSeconds(tiempoReaparicion);

        player.transform.position = puntoDeInicio.position;
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        player.SetActive(true);
        OnJugadorReaparecio?.Invoke();
        reapareciendo = false;
    }
}