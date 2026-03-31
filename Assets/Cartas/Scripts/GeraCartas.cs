using System.Collections.Generic;
using UnityEngine;

public class GeraCartas : MonoBehaviour
{
    [SerializeField] private CartasData cartasData;
    private List<GameObject> cartasPoolCopia;
    //private CompositeCollider2D compositeCollider2D;
    private GameObject cartaSpawnada;
    private int rand;

    void Awake()
    {
        //compositeCollider2D = GetComponent<CompositeCollider2D>();
        cartasPoolCopia = new List<GameObject>(cartasData.cartasPool);
        cartasPoolCopia.AddRange(cartasPoolCopia);  // Duplicando a lista para ter os pares

        for (int i = 0; i < cartasData.QuantHorCartas*2; i += 2)    // Multiplicando por 2 porque as cartas tem largura e altura de 2
        {
            for(int j = 0; j < cartasData.QuantVerCartas*2; j += 2)
            {
                if (cartasPoolCopia.Count > 0)  // Verifica se ainda tem cartas para spawnar
                {
                    rand = Random.Range(0,cartasPoolCopia.Count);
                    cartaSpawnada = Instantiate(cartasPoolCopia[rand], this.transform);
                    cartaSpawnada.transform.localPosition = new Vector2(i,j);
                    cartasPoolCopia.Remove(cartasPoolCopia[rand]);
                }
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
