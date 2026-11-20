using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Botones del menú principal y de la pantalla final.
/// </summary>
public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        GameManager.NuevaPartida();
        SceneManager.LoadScene(Constants.ESCENA_NIVEL1);
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene(Constants.ESCENA_MENU);
    }

    public void Salir()
    {
        Application.Quit();
    }
}