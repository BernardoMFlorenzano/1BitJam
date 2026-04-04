using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CartaTipo10 : ClickCarta
{
    public GameObject prefabGosma;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);

        Instantiate(prefabGosma, transform.position, Quaternion.identity);
    }
}