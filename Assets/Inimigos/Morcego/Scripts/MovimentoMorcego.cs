using System;
using System.Collections;
using UnityEngine;


public class MovimentoMorcego : MonoBehaviour
{
    [SerializeField] private MorcegoData morcegoData;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 direcao;

    private float offsetTempo;  // Gerar variacao entre cada morcego

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        offsetTempo = UnityEngine.Random.Range(0f, 100f);
        //offsetTempo = 0f;
    }

    void FixedUpdate()
    {
        if (player)
        {
            direcao = (player.position - transform.position).normalized;
            
            // Logica de variacao no movimento

            float ruidoX = Mathf.PerlinNoise(Time.time * morcegoData.frequenciaRuido + offsetTempo, 0) * 2 - 1;
            float ruidoY = Mathf.PerlinNoise(0, Time.time * morcegoData.frequenciaRuido + offsetTempo) * 2 - 1;
            
            Vector2 desvio = new Vector2(ruidoX, ruidoY) * morcegoData.amplitudeRuido;

            direcao = (direcao + desvio).normalized;
        }
        else
            direcao = Vector2.zero;

        rb.linearVelocity = direcao * morcegoData.velMorcego;
    }
}
