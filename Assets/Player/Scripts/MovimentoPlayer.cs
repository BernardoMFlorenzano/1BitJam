using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    public float velMult = 1f;
    public float puloMult = 1f;
    private Rigidbody2D rb;
    private CircleCollider2D colliderCai;
    private Vector2 direcao;
    //private float rotacao;
    public LayerMask cartasLayer;
    public bool podeCair = false;   // Metodo que cria cartas vai alterar isso no começo
    public bool pulando = false;
    private Coroutine corPulo;
    private Collider2D cartaSelect;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderCai = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        //velMov = playerData.velMov;
    }


    public void OnMove(InputValue value)
    {
        direcao = value.Get<Vector2>();
        direcao = direcao.normalized;

        if (direcao != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -direcao);
        }

    }

    public void OnJump()
    {
        if (!pulando)
        {
            Pula();
        }
        else if (pulando)
        {
            // ground pound \ escolher carta 
            EscolheCarta();
        }
    }

    void Pula()
    {
        podeCair = false;
        pulando = true;
        Debug.Log("Pula");
        corPulo = StartCoroutine(Pulo(playerData.duracaoPulo * puloMult));
        puloMult = 1f;  // Reseta o multiplicador
    }

    void EscolheCarta()
    {
        if (corPulo != null)
        {
            spriteRenderer.transform.localScale = new Vector2(1f,1f);
            StopCoroutine(corPulo);
            corPulo = null;
        }
        podeCair = true;
        pulando = false;

        velMult = 1f; // Reseta a velocidade quando cai (gosma)
        animator.SetTrigger("descendo");

        if (cartaSelect = Physics2D.OverlapPoint(transform.position, cartasLayer))
        {
            cartaSelect.GetComponent<ClickCarta>().FlipCartaPlayer();
        }
        Debug.Log("Escolheu carta");
        Debug.Log(cartaSelect);
    }


    void FixedUpdate()
    {
        rb.linearVelocity = direcao * playerData.velMov*velMult;
        
        if (!colliderCai.IsTouchingLayers(cartasLayer) && podeCair)
        {
            Debug.Log("Caiu");
            EventosManager.TriggerCaiu();
        }   

        animator.SetFloat("vel", MathF.Abs(rb.linearVelocityX + rb.linearVelocityY)/2);
    }

    IEnumerator Pulo(float duracaoPulo)
    {
        spriteRenderer.transform.localScale = new Vector2(1.1f,1.1f);
        animator.SetTrigger("subindo");

        yield return new WaitForSeconds(duracaoPulo/2);

        yield return new WaitForSeconds(duracaoPulo/2);

        animator.SetTrigger("descendo");

        spriteRenderer.transform.localScale = new Vector2(1f,1f);
        podeCair = true;
        pulando = false;
        Debug.Log("termina pulo");
        velMult = 1f; // Reseta a velocidade quando cai (gosma)
    }



}
