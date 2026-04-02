using UnityEngine;

[CreateAssetMenu(fileName = "JogoDaMemoriaData", menuName = "Scriptable Objects/JogoDaMemoriaData")]
public class JogoDaMemoriaData : ScriptableObject
{
    public int combinacoesCartas = 2;   // Se são duplas, trios etc
    public int quantidadeCombinacoesWin;    // Quantidade minima de combinacoes para ganhar

    
}
