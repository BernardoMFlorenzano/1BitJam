using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CartasData", menuName = "Scriptable Objects/CartasData")]
public class CartasData : ScriptableObject
{
    public List<GameObject> cartasPool; // Possibilidades de cartas (unicas)
    public int quantHorCartas = 4;  // Quantidade de cartas horizontalmente  
    public int quantVerCartas = 4;  // Quantidade de cartas verticalmente 
    public float espacoEntreCartas = 0;
}
