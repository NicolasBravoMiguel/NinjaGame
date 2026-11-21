using UnityEngine;

/// <summary>
/// Mueve el fondo más lento que la cámara para dar profundidad.
/// </summary>
public class Parallax : MonoBehaviour
{
    public Transform camara;
    public float factor = 0.8f;

    private Vector3 posicionInicial;
    private Vector3 camaraInicial;

    void Start()
    {
        posicionInicial = transform.position;
        camaraInicial = camara.position;
    }

    void LateUpdate()
    {
        Vector3 delta = camara.position - camaraInicial;
        transform.position = posicionInicial + new Vector3(delta.x * factor, delta.y * factor, 0);
    }
}
