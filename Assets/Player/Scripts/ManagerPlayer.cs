using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPlayer : MonoBehaviour
{
    public float tempoAnimMorte;
    private PausaJogo pausaJogo;
    private GameObject player;
    private Animator animatorPlayer;
    private bool morreu = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausaJogo = GetComponent<PausaJogo>();
        player = GameObject.FindGameObjectWithTag("Player");
        animatorPlayer = player.GetComponentInChildren<Animator>();

        Debug.Log(animatorPlayer);

        EventosManager.Caiu +=  QuedaPlayer;
        EventosManager.DanoPlayer += DanoPlayer;
    }

    private void OnDisable()
    {
        EventosManager.Caiu -= QuedaPlayer;
        EventosManager.DanoPlayer -= DanoPlayer;
    }

    void QuedaPlayer()  // Trata o que acontece na queda
    {
        if (!morreu)
        {
            morreu = true;
            StartCoroutine(MortePlayerDano());   
        }
    }

    void DanoPlayer()   // Trata o que acontece ao levar dano
    {
        if (!morreu)
        {
            morreu = true;
            StartCoroutine(MortePlayerDano());   
        }
    }

    IEnumerator MortePlayerDano()
    {
        animatorPlayer.SetTrigger("morte");
        yield return new WaitForSeconds(tempoAnimMorte);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
