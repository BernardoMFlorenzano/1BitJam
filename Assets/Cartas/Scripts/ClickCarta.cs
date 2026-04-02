using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCarta : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected JogoDaMemoria jogoDaMemoria;  // protected inves de private para poder usar em classes filhas
    public SpriteRenderer sr;
    public Sprite spriteCoberto;
    public Sprite spriteVirado;
    public Sprite spriteUsado;
    public bool interagivel = true;
    public int tipo;    // tipo da carta para comparar com outras

    void Awake()
    {
        sr.sprite = spriteCoberto;  
    }

    void Start ()
    {
        jogoDaMemoria = GameObject.FindGameObjectWithTag("JogoDaMemoria").GetComponent<JogoDaMemoria>();
    }

    public void FlipCartaPlayer()
    {
        if (interagivel && jogoDaMemoria.podeEscolher)
        {
            sr.sprite = spriteVirado;

            jogoDaMemoria.Interacao(this);
            interagivel = false;

            Debug.Log("Escolheu carta" + name);
        }
    }

    public virtual void EfeitoCarta()
    {
        // Gera efeitos
        sr.sprite = spriteUsado;
        Debug.Log("Gerou efeito " + tipo);
    }

    public void ResetaCarta()
    {
        sr.sprite = spriteCoberto;
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
