using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo6 : ClickCarta
{
    public GameObject prefabTurret;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Instantiate(prefabTurret, transform.position, Quaternion.identity);
    }
}