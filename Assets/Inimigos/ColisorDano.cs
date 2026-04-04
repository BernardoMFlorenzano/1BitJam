using System.Collections;
using UnityEngine;

public class ColisorDano : MonoBehaviour
{
    private bool ativo = false; // Pro player não morrer imediatamente
    public float tempoDelay = 0.5f;
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
            Debug.Log("Dano player");
        }
    }

    IEnumerator DelayInicio()
    {
        yield return new WaitForSeconds(tempoDelay);
        ativo = true;
    }
}
