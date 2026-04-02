using UnityEngine;

public class CartaTipo4 : ClickCarta
{
    public GameObject prefabEspinho;
    public override void EfeitoCarta()
    {
        base.EfeitoCarta();

        Instantiate(prefabEspinho, transform.position, Quaternion.identity);
    }
}