using UnityEngine;

/// <summary>
/// Sacude la cámara cuando golpean al jugador o al jefe. Escucha eventos, como TimeUI.
/// Va en la Main Camera, que es hija del CamaraRig.
/// </summary>
public class SacudidaCamara : MonoBehaviour
{
    public float duracion = 0.2f;
    public float intensidad = 0.2f;

    private float timer;

    private void OnEnable()
    {
        GameManager.OnJugadorGolpeado += Sacudir;
        JefeVida.OnJefeGolpeado += SacudirSuave;
    }

    private void OnDisable()
    {
        GameManager.OnJugadorGolpeado -= Sacudir;
        JefeVida.OnJefeGolpeado -= SacudirSuave;
    }

    private void Sacudir() { timer = duracion; }

    private void SacudirSuave() { timer = duracion * 0.5f; }

    void LateUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
            transform.localPosition = (Vector3)(Random.insideUnitCircle * intensidad);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
