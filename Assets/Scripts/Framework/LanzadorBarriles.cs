using UnityEngine;

/// <summary>
/// El ayudante del jefe lanza barriles cada cierto tiempo, como en Donkey Kong.
/// </summary>
public class LanzadorBarriles : MonoBehaviour
{
    public GameObject barrilPrefab;
    public float intervalo = 2.5f;
    public float velocidadInicial = 3.0f;
    public float direccion = 1;

    private float timer;
    private Animator animator;

    void Start()
    {
        // El Animator está en el MiniJefe (el padre del Lanzador).
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < intervalo) return;
        timer = 0;

        if (animator != null) animator.SetTrigger("Attack");

        GameObject barril = Instantiate(barrilPrefab, transform.position, Quaternion.identity);
        barril.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direccion * velocidadInicial, 0);
        Destroy(barril, 100.0f);
    }
}