using UnityEngine;

/// <summary>
/// La música no se destruye al cambiar de escena (grupo Systems del Laboratorio 4).
/// </summary>
public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instancia;

    void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }
        instancia = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }
}
