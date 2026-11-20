using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Administra la partida en todos los niveles: vidas, victoria, derrota y cambio de escena.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Action OnVidasCambiaron;
    public static Action OnJugadorGolpeado;
    public static Action OnJugadorReaparecio;

    public static int Vidas { get; private set; }

    public GameObject player;
    public Transform puntoDeInicio;
    public GameObject panelGameOver;
    public GameObject panelVictoria;
    public float tiempoReaparicion = 1.0f;

    public GameObject efectoMuerte;
    public AudioClip sonidoGolpe;

    private bool partidaTerminada;
    private bool nivelCompletado;
    private bool reapareciendo;

    // Regresa las vidas a 0 cada vez que se da Play en el editor
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ReiniciarEstaticos() { Vidas = 0; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        // Si se da Play directo en un nivel, empieza con 3 vidas
        if (Vidas <= 0) NuevaPartida();
        panelGameOver.SetActive(false);
        panelVictoria.SetActive(false);
        OnVidasCambiaron?.Invoke();
    }

    void Update()
    {
        if (partidaTerminada && Input.GetKeyDown(Constants.TECLA_REINICIO))
        {
            NuevaPartida();
            SceneManager.LoadScene(Constants.ESCENA_NIVEL1);
        }

        if (nivelCompletado && Input.GetKeyDown(Constants.TECLA_CONTINUAR))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    /// <summary>
    /// Empieza una partida nueva con 3 vidas (la usa también el menú principal).
    /// </summary>
    public static void NuevaPartida()
    {
        Vidas = Constants.VIDAS_INICIALES;
    }

    public void JugadorGolpeado()
    {
        if (partidaTerminada || nivelCompletado || reapareciendo) return;

        Vidas--;
        OnVidasCambiaron?.Invoke();
        OnJugadorGolpeado?.Invoke();
        Efectos.Crear(efectoMuerte, player.transform.position);
        Efectos.Sonar(sonidoGolpe);

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

    public void Ganar()
    {
        if (partidaTerminada || nivelCompletado) return;
        nivelCompletado = true;
        panelVictoria.SetActive(true);
        Time.timeScale = 0;
    }

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