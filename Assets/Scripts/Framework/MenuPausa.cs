using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Pausa el juego con Esc y muestra el panel de pausa.
/// </summary>
public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;
    private bool pausado;

    void Start()
    {
        panelPausa.SetActive(false);
    }

    void Update()
    {
        if (!Input.GetKeyDown(Constants.TECLA_PAUSA)) return;

        if (pausado) Reanudar();
        else if (Time.timeScale > 0) Pausar();
    }

    public void Pausar()
    {
        pausado = true;
        panelPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reanudar()
    {
        pausado = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constants.ESCENA_MENU);
    }
}
