using UnityEngine;

[CreateAssetMenu(fileName = "JogoDaMemoriaData", menuName = "Scriptable Objects/JogoDaMemoriaData")]
public class JogoDaMemoriaData : ScriptableObject
{
    public int combinacoesCartas = 2;   // Se são duplas, trios etc
    public int quantidadeCombinacoesWin;    // Quantidade minima de combinacoes para ganhar

    public float tempoDelayResultado = 2f;
    public float timerInicial = 30f;
    public float tempoMax = 60f;
    public float timerTempoGanhoComb = 10f;
}
