using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo5 : ClickCarta
{
    public GameObject prefabTwhomp;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Instantiate(prefabTwhomp, transform.position, Quaternion.identity);
    }
}