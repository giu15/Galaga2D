using UnityEngine;
using UnityEngine.InputSystem;

public class ControleDoJogador : MonoBehaviour
{
    public GameObject laserDoJogador;
    public Rigidbody2D oRigidbody2D;
    public float velocidadeDaNave = 5f;
    public Vector2 TeclaPressionada;
    public Transform pontoDeTiro;

    private void Update()
    {
        Movimentarjogador();
        LimiteDeTela();

        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            Atirar();
        }
    }

    private void Movimentarjogador()
    {
        TeclaPressionada = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        oRigidbody2D.linearVelocity =
            TeclaPressionada * velocidadeDaNave;
    }

    private void LimiteDeTela()
    {
        Vector3 posicao = transform.position;

        Vector3 limiteInferior =
            Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        Vector3 limiteSuperior =
            Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        posicao.x = Mathf.Clamp(
            posicao.x, limiteInferior.x, limiteSuperior.x);

        posicao.y = Mathf.Clamp(
            posicao.y, limiteInferior.y, limiteSuperior.y);

        transform.position = posicao;
    }

    private void Atirar()
    {
        if (laserDoJogador != null && pontoDeTiro != null)
        {
            Instantiate(
                laserDoJogador,
                pontoDeTiro.position,
                pontoDeTiro.rotation
            );
        }
    }
}