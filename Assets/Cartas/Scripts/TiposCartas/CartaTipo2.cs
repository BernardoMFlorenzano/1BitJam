using UnityEngine;

public class CartaTipo2 : ClickCarta
{
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Destroy(gameObject);
    }
}