using UnityEngine;

/// <summary>
/// Lanza un shuriken hacia donde mira el jugador al presionar J.
/// </summary>
public class PlayerAtaque : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreAtaques = 0.3f;
    public AudioClip sonidoAtaque;

    private float timer;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(Constants.TECLA_ATAQUE) && timer <= 0 && Time.timeScale > 0)
        {
            timer = tiempoEntreAtaques;
            GameObject shuriken = Instantiate(shurikenPrefab, puntoDisparo.position, Quaternion.identity);
            float direccion = Mathf.Sign(transform.localScale.x);
            shuriken.GetComponent<Proyectil>().direccion = new Vector2(direccion, 0);

            if (animator != null) animator.SetTrigger("Attack");
            Efectos.Sonar(sonidoAtaque);
        }
    }
}