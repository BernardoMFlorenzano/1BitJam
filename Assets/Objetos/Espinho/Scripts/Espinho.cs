using System;
using System.Collections;
using UnityEngine;


public class Espinho : MonoBehaviour
{
    private bool ativo = false;



    void Start()
    {
        StartCoroutine(DelayInicio());    
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && ativo)
        {
            if (!collision.GetComponentInParent<MovimentoPlayer>().pulando)
            {
                EventosManager.TriggerDanoPlayer();  
            }
        }
    }

    IEnumerator DelayInicio()
    {
        yield return new WaitForSeconds(0.5f);
        ativo = true;
    }
}
