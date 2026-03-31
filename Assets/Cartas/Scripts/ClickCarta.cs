using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCarta : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public SpriteRenderer sr;
    public Sprite spriteCoberto;
    public Sprite spriteVirado;

    void Awake()
    {
        sr.sprite = spriteCoberto;  
        Debug.Log(sr);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (sr.sprite == spriteCoberto)
            sr.sprite = spriteVirado;
        else if (sr.sprite == spriteVirado)
            sr.sprite = spriteCoberto;

        Debug.Log("Clicou na carta" + name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
