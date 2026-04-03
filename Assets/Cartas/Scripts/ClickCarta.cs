using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCarta : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected JogoDaMemoria jogoDaMemoria;  // protected inves de private para poder usar em classes filhas
    public SpriteRenderer spriteRenderer;
    public Sprite spriteCoberto;
    public Sprite spriteVirado;
    public Sprite spriteUsado;
    public bool interagivel = true;
    public int tipo;    // tipo da carta para comparar com outras

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteCoberto;  
    }

    void Start ()
    {
        jogoDaMemoria = GameObject.FindGameObjectWithTag("JogoDaMemoria").GetComponent<JogoDaMemoria>();
    }

    public void FlipCartaPlayer()
    {
        if (interagivel && jogoDaMemoria.podeEscolher)
        {
            spriteRenderer.sprite = spriteVirado;

            jogoDaMemoria.Interacao(this);
            interagivel = false;

            Debug.Log("Escolheu carta" + name);
        }
    }

    public virtual void EfeitoCarta(int num)
    {
        // Gera efeitos
        spriteRenderer.sprite = spriteUsado;
        Debug.Log("Gerou efeito " + tipo);
    }

    public void ResetaCarta()
    {
        spriteRenderer.sprite = spriteCoberto;
        interagivel = true;
    }
















    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        if (sr.sprite == spriteCoberto)
            sr.sprite = spriteVirado;
        else if (sr.sprite == spriteVirado)
            sr.sprite = spriteCoberto;

        Debug.Log("Clicou na carta" + name);
        */
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
