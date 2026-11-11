using UnityEngine;

public class MovimentoTiroInimigo : MonoBehaviour
{
    public float velocidade = 5f;

    private Transform jogador;
    private Vector2 direcao;

    void Start()
    {
        GameObject objetoJogador = GameObject.FindGameObjectWithTag("Player");

        if (objetoJogador != null)
        {
            jogador = objetoJogador.transform;
            direcao = ((Vector2)jogador.position - (Vector2)transform.position).normalized;
        }
        else
        {
            direcao = Vector2.down;
        }

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += (Vector3)(direcao * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Destroy(outro.gameObject);
            Destroy(gameObject);
        }
    }
}