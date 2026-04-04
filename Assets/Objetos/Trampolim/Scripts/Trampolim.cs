using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public float puloMult = 2f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && !collision.GetComponentInParent<MovimentoPlayer>().pulando)
        {
            collision.GetComponentInParent<MovimentoPlayer>().puloMult = puloMult;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer"))
        {
            collision.GetComponentInParent<MovimentoPlayer>().puloMult = 1f;
        }
    }
}