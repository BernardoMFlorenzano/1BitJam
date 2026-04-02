using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPlayer : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       EventosManager.Caiu +=  QuedaPlayer;
       EventosManager.DanoPlayer += DanoPlayer;
    }

    void QuedaPlayer()  // Trata o que acontece na queda
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DanoPlayer()   // Trata o que acontece ao levar dano
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        EventosManager.Caiu -= QuedaPlayer;
        EventosManager.DanoPlayer -= DanoPlayer;
    }
}
