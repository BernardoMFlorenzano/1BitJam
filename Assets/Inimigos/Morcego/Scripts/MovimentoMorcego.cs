using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovimentoMorcego : MonoBehaviour
{
    [SerializeField] private MorcegoData morcegoData;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 direcao;
    private bool ativo = false; // Pro player não morrer imediatamente

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(DelayInicio());
    }

    void FixedUpdate()
    {
        if (player)
            direcao = (player.position - transform.position).normalized;
        else
            direcao = Vector2.zero;
        rb.linearVelocity = direcao * morcegoData.velMorcego;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && ativo)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator DelayInicio()
    {
        yield return new WaitForSeconds(0.5f);
        ativo = true;
    }
}
