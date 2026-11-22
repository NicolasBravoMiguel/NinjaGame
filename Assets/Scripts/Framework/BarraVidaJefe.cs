using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Barra de vida del mini jefe o del jefe final.
/// </summary>
public class BarraVidaJefe : MonoBehaviour
{
    public JefeVida jefe;
    public Slider barra;

    private void OnEnable()
    {
        if (jefe != null) jefe.OnVidaCambio += Actualizar;
    }

    private void OnDisable()
    {
        if (jefe != null) jefe.OnVidaCambio -= Actualizar;
    }

    void Start()
    {
        barra.maxValue = jefe.vidaMaxima;
        Actualizar();
    }

    private void Actualizar()
    {
        barra.value = jefe.Vida;
    }
}
