using UnityEngine;

public class CartaTipo4 : ClickCarta
{
    public GameObject prefabEspinho;
    public override void EfeitoCarta(int num)
    {
        base.EfeitoCarta(num);
        
        Instantiate(prefabEspinho, transform.position, Quaternion.identity);
    }
}