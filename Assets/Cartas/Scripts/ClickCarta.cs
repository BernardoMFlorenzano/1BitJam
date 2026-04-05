using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCarta : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected JogoDaMemoria jogoDaMemoria;  // protected inves de private para poder usar em classes filhas
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite spriteCoberto;
    public Sprite spriteVirado;
    public Sprite spriteUsado;
    public bool interagivel = true;
    public int tipo;    // tipo da carta para comparar com outras

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer.sprite = spriteCoberto;  
    }

    void Start ()
    {
        jogoDaMemoria = GameObject.FindGameObjectWithTag("JogoDaMemoria").GetComponent<JogoDaMemoria>();
    }

    public void FlipCartaPlayer()
    {
        if (interagivel && jogoDaMemoria.podeEscolher && animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            //spriteRenderer.sprite = spriteVirado;
            animator.SetBool("acerta", false);
            animator.SetBool("reseta", false);
            animator.SetTrigger("seleciona");
            animator.SetBool("selecionada", true);

            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.selectSound, transform);
            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.flipCardSound, transform);

            jogoDaMemoria.Interacao(this);
            interagivel = false;

            Debug.Log("Escolheu carta" + name);
        }
    }

    public virtual void EfeitoCarta(int num)
    {
        // Gera efeitos
        spriteRenderer.sprite = spriteUsado;
        animator.SetBool("acerta", true);
        animator.SetBool("selecionada", false);

        Debug.Log("Gerou efeito " + tipo);
    }

    public void ResetaCarta()
    {
        //spriteRenderer.sprite = spriteCoberto;

        animator.SetBool("reseta", true);
        animator.SetBool("selecionada", false);

        SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.flipCardSound, transform);
        

        interagivel = true;
    }

    public void FlipSprite()
    {
        if (spriteRenderer.sprite == spriteCoberto)
            spriteRenderer.sprite = spriteVirado;
        else if (spriteRenderer.sprite == spriteVirado)
            spriteRenderer.sprite = spriteCoberto;
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
