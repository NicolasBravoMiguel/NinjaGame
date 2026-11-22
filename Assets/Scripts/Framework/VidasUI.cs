using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Muestra las vidas con texto, con iconos o con ambos.
/// </summary>
public class VidasUI : MonoBehaviour
{
    public TextMeshProUGUI vidasText;
    public Image[] corazones;

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
        if (vidasText != null) vidasText.text = $"Vidas: {GameManager.Vidas}";

        if (corazones == null) return;
        for (int i = 0; i < corazones.Length; i++)
        {
            if (corazones[i] != null) corazones[i].enabled = i < GameManager.Vidas;
        }
    }
}
