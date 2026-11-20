using UnityEngine;

/// <summary>
/// El shuriken del jugador: daña a jefes y barriles, y se destruye al chocar con el escenario.
/// </summary>
public class GolpeJugador : MonoBehaviour
{
    public int danio = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        JefeVida jefe = other.GetComponent<JefeVida>();
        if (jefe != null)
        {
            jefe.RecibirDanio(danio);
            Destroy(gameObject);
            return;
        }

        BarrilVida barril = other.GetComponent<BarrilVida>();
        if (barril != null)
        {
            barril.RecibirDanio(danio);
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer(Constants.CAPA_SUELO))
        {
            Destroy(gameObject);
        }
    }
}