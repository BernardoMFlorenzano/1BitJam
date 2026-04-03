using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo3 : ClickCarta
{
    public GameObject prefabMorcego;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Instantiate(prefabMorcego, transform.position, Quaternion.identity);
    }
}