using UnityEngine;

public class MovimentoLaser : MonoBehaviour
{
    public float velocidade = 10f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = Vector2.right * velocidade;
        Destroy(gameObject, 3f);
    }
}