using System.Collections;
using UnityEngine;

public class ColisorDano : MonoBehaviour
{
    private bool ativo = false; // Pro player não morrer imediatamente
    public float tempoDelay = 0.5f;
    public bool pulavel = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayInicio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && ativo)
        {
            if (pulavel)
            {
                if (!collision.GetComponentInParent<MovimentoPlayer>().pulando)
                {
                    EventosManager.TriggerDanoPlayer();  
                }
            }
            else
                EventosManager.TriggerDanoPlayer();
        }
    }

    IEnumerator DelayInicio()
    {
        yield return new WaitForSeconds(tempoDelay);
        ativo = true;
    }
}
