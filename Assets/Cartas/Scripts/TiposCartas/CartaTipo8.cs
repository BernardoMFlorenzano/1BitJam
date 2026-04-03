using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo8 : ClickCarta
{
    public GameObject prefabMachado;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Instantiate(prefabMachado, transform.position, Quaternion.identity);
    }
}