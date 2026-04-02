using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Rigidbody2D rb;
    private CircleCollider2D colliderCai;
    private Vector2 direcao;
    public LayerMask cartasLayer;
    public bool podeCair = false;   // Metodo que cria cartas vai alterar isso no começo
    public bool pulando = false;
    private Coroutine corPulo;
    private Collider2D cartaSelect;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderCai = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //velMov = playerData.velMov;
    }


    public void OnMove(InputValue value)
    {
        direcao = value.Get<Vector2>();
        direcao = direcao.normalized;
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
        corPulo = StartCoroutine(Pulo(playerData.duracaoPulo));
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

        if (cartaSelect = Physics2D.OverlapPoint(this.transform.position, cartasLayer))
        {
            cartaSelect.GetComponent<ClickCarta>().FlipCartaPlayer();
        }
        Debug.Log("Escolheu carta");
        Debug.Log(cartaSelect);
    }


    void FixedUpdate()
    {
        rb.linearVelocity = direcao * playerData.velMov;
        
        if (!colliderCai.IsTouchingLayers(cartasLayer) && podeCair)
        {
            Debug.Log("Caiu");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Pulo(float duracaoPulo)
    {
        spriteRenderer.transform.localScale = new Vector2(1.1f,1.1f);
        yield return new WaitForSeconds(duracaoPulo);
        spriteRenderer.transform.localScale = new Vector2(1f,1f);
        podeCair = true;
        pulando = false;
        Debug.Log("termina pulo");
    }



}
