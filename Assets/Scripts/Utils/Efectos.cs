using UnityEngine;

/// <summary>
/// Crea partículas y reproduce sonidos solo si se asignaron en el Inspector.
/// </summary>
public static class Efectos
{
    public static void Crear(GameObject prefab, Vector3 posicion)
    {
        if (prefab == null) return;
        GameObject efecto = Object.Instantiate(prefab, posicion, Quaternion.identity);
        Object.Destroy(efecto, 2.0f);
    }

    public static void Sonar(AudioClip clip)
    {
        if (clip == null || Camera.main == null) return;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
