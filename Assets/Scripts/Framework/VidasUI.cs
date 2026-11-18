using TMPro;
using UnityEngine;

/// <summary>
/// Actualiza el texto de vidas cuando el GameManager avisa un cambio.
/// </summary>
public class VidasUI : MonoBehaviour
{
    public TextMeshProUGUI vidasText;

    private void OnEnable()
    {
        GameManager.OnVidasCambiaron += ActualizarVidas;
    }

    private void OnDisable()
    {
        GameManager.OnVidasCambiaron -= ActualizarVidas;
    }

    private void ActualizarVidas()
    {
        vidasText.text = $"Vidas: {GameManager.Vidas}";
    }
}