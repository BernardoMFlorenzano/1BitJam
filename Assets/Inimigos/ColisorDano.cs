using System.Collections;
using UnityEngine;

public class ColisorDano : MonoBehaviour
{
    private bool ativo = false; // Pro player não morrer imediatamente
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
            EventosManager.TriggerDanoPlayer();
        }
    }

    IEnumerator DelayInicio()
    {
        yield return new WaitForSeconds(0.5f);
        ativo = true;
    }
}
