using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPlayer : MonoBehaviour
{
    public float tempoAnimMorte;
    private PausaJogo pausaJogo;
    private GameObject menuMorte;
    private GameObject player;
    private Animator animatorPlayer;
    private bool podeMorrer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausaJogo = GetComponent<PausaJogo>();
        player = GameObject.FindGameObjectWithTag("Player");
        animatorPlayer = player.GetComponentInChildren<Animator>();
        menuMorte = GameObject.FindGameObjectWithTag("MenuMorte");

        EventosManager.Caiu +=  QuedaPlayer;
        EventosManager.DanoPlayer += DanoPlayer;
        menuMorte.SetActive(false);

        podeMorrer = true; 
    }

    private void OnDisable()
    {
        EventosManager.Caiu -= QuedaPlayer;
        EventosManager.DanoPlayer -= DanoPlayer;
    }

    void QuedaPlayer()  // Trata o que acontece na queda
    {
        if (podeMorrer)
        {
            podeMorrer = false;
            StartCoroutine(MortePlayerDano());   
        }
    }

    void DanoPlayer()   // Trata o que acontece ao levar dano
    {
        if (podeMorrer)
        {
            podeMorrer = false;
            StartCoroutine(MortePlayerDano());   
        }
    }

    IEnumerator MortePlayerDano()
    {
        animatorPlayer.SetTrigger("morte");
        pausaJogo.PausaLogica();
        yield return new WaitForSecondsRealtime(tempoAnimMorte);

        // Apareceria menu de morte
        menuMorte.SetActive(true);
        //pausaJogo.PassaCena();

    }
    
}
