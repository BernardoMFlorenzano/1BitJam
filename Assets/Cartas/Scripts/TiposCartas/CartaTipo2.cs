using UnityEngine;

public class CartaTipo2 : ClickCarta
{
    public override void EfeitoCarta()
    {
        base.EfeitoCarta();

        Destroy(gameObject);
    }
}