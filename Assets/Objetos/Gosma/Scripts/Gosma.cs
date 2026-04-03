using UnityEngine;

public class Gosma : MonoBehaviour
{
    public float velMult = 0.5f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && !collision.GetComponentInParent<MovimentoPlayer>().pulando)
        {
            collision.GetComponentInParent<MovimentoPlayer>().velMult = velMult;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && !collision.GetComponentInParent<MovimentoPlayer>().pulando)
        {
            collision.GetComponentInParent<MovimentoPlayer>().velMult = 1f;
        }
    }

}