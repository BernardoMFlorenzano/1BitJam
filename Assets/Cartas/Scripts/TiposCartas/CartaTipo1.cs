using UnityEngine;

public class CartaTipo1 : ClickCarta
{
    public override void EfeitoCarta()
    {
        base.EfeitoCarta();

        sr.sprite = spriteUsado;
    }
}
