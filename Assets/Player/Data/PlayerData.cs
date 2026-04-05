using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float velMov;
    public float duracaoPulo;
    public float cooldownPulo = 0.5f;
    public float delayParadoPosPulo = 0f;
    public float delayAtivaQueda = 0.5f;  // delay pra ativar queda depois que termina pulo
}
