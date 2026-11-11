using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 2f;
    public GameObject tiroInimigo;
    public float intervaloTiro = 2f;
    public bool podeAtirar = false;

    private float proximoTiro;

    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        if (podeAtirar && Time.time >= proximoTiro)
        {
            Atirar();
            proximoTiro = Time.time + intervaloTiro;
        }
    }

    void Atirar()
    {
        if (tiroInimigo == null)
            return;

        Instantiate(
            tiroInimigo,
            transform.position,
            Quaternion.identity
        );
    }
}