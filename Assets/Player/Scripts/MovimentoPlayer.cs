using System;
using System.Collections;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;


public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private EfeitosParticulas efeitosPlayer;
    private PausaJogo pausaJogo;
    public float velMult = 1f;
    public float puloMult = 1f;
    private Rigidbody2D rb;
    private CircleCollider2D colliderCai;
    private Vector2 direcao;
    //private float rotacao;
    public LayerMask cartasLayer;
    public bool podeCair = false;   // Metodo que cria cartas vai alterar isso no começo
    private bool podePular = true;
    private bool podeMover = true;
    public bool pulando = false;
    private bool moveu = false;
    private Coroutine corPulo;
    private Coroutine corDelayAtivaQueda;
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
        efeitosPlayer = GetComponentInChildren<EfeitosParticulas>();
        pausaJogo = GameObject.FindGameObjectWithTag("JogoDaMemoria").GetComponent<PausaJogo>();
        //velMov = playerData.velMov;
    }

    public void OnPause()
    {
        pausaJogo.PausaPlayer();
    }


    public void OnMove(InputValue value)
    {
        if (!moveu)
        {
            moveu = true;
            EventosManager.TriggerComecaJogo();
        }


        direcao = value.Get<Vector2>();
        direcao = direcao.normalized;

        if (direcao != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -direcao);
        }

    }

    public void OnJump()
    {
        if (!pulando && podePular)
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
        if (corDelayAtivaQueda != null)
            StopCoroutine(corDelayAtivaQueda);
        
        podeCair = false;
        podePular = false;
        pulando = true;
        Debug.Log("Pula");   

        SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.jumpSound, transform);

        corPulo = StartCoroutine(Pulo(playerData.duracaoPulo * puloMult));

        if (puloMult != 1f)
            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.trampolimSound, transform);

        puloMult = 1f;  // Reseta o multiplicador
    }

    void EscolheCarta()
    {
        if (corPulo != null)
        {
            spriteRenderer.transform.localScale = new Vector2(1f,1f);
            StopCoroutine(corPulo);
            corPulo = null;
            if (!podePular)
                StartCoroutine(CooldownPulo());
            if (podeMover)
                StartCoroutine(PausaMovPosPulo());
            //corDelayAtivaQueda = StartCoroutine(DelayAtivaQueda());
        }
        podeCair = true;
        pulando = false;

        velMult = 1f; // Reseta a velocidade quando cai (gosma)
        animator.SetTrigger("descendo");

        if (cartaSelect = Physics2D.OverlapPoint(transform.position, cartasLayer))
        {
            cartaSelect.GetComponent<ClickCarta>().FlipCartaPlayer();
            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.landSound, transform);
        }

        Debug.Log("Escolheu carta");
        Debug.Log(cartaSelect);

        if (efeitosPlayer)
        {
            efeitosPlayer.PlayEfeitoQueda();
        }

    }


    void FixedUpdate()
    {
        if (podeMover)
            rb.linearVelocity = direcao * playerData.velMov*velMult;
        else
            rb.linearVelocity = Vector2.zero;
        
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

        spriteRenderer.transform.localScale = new Vector2(1.2f,1.2f);

        yield return new WaitForSeconds(duracaoPulo/2);

        animator.SetTrigger("descendo");

        spriteRenderer.transform.localScale = new Vector2(1f,1f);
        //podeCair = true;
        pulando = false;
        Debug.Log("termina pulo");
        velMult = 1f; // Reseta a velocidade quando cai (gosma)

        if (!podePular)
            StartCoroutine(CooldownPulo());
        if (podeMover)
            StartCoroutine(PausaMovPosPulo());
        corDelayAtivaQueda = StartCoroutine(DelayAtivaQueda());

        if (colliderCai.IsTouchingLayers(cartasLayer))
            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.landSound, transform);
    }

    IEnumerator DelayAtivaQueda()
    {
        yield return new WaitForSeconds(playerData.delayAtivaQueda);
        podeCair = true;
    }

    IEnumerator CooldownPulo()
    {
        yield return new WaitForSeconds(playerData.cooldownPulo);
        podePular = true;
    }

    IEnumerator PausaMovPosPulo()
    {
        podeMover = false;
        podePular = false;
        yield return new WaitForSeconds(playerData.delayParadoPosPulo);
        podeMover = true;
        podePular = true;
    }

}
