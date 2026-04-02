using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo5 : ClickCarta
{
    public GameObject prefabTwhomp;
    public override void EfeitoCarta()
    {
        base.EfeitoCarta();

        Instantiate(prefabTwhomp, transform.position, Quaternion.identity);
    }
}