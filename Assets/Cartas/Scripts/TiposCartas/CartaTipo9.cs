using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo9 : ClickCarta
{
    public GameObject prefabTrampolim;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Instantiate(prefabTrampolim, transform.position, Quaternion.identity);
    }
}