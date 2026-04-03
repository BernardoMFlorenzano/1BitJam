using System.Collections;
using UnityEngine;

public class CartaTipo7 : ClickCarta    // Carta 7 só funciona com pares
{
    public float delayTroca = 1f;
    private Vector3 pos1;
    private Vector3 pos2;
    private bool ativa = false;
    private bool podeTrocar = true;
    private bool trocando = false;

    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        pos1 = jogoDaMemoria.cartasSelecionadas[0].transform.position;
        pos2 = jogoDaMemoria.cartasSelecionadas[1].transform.position;

        if (num % 2 == 0)
        {
            Destroy(gameObject);
        }

        ativa = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ativa && podeTrocar)
        {
            if (!collision.GetComponent<MovimentoPlayer>().pulando)
            {
                podeTrocar = false;
                StartCoroutine(TrocaPos());
            }
        }
    }

    IEnumerator TrocaPos()
    {
        trocando = true;
        StartCoroutine(AnimTroca());
        yield return new WaitForSeconds(delayTroca);

        if (transform.position == pos1)
            transform.position = pos2;
        else 
            transform.position = pos1;

        trocando = false;
        podeTrocar = true;
        
    }

    IEnumerator AnimTroca()
    {
        while (trocando)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.enabled = true;
    }
}
