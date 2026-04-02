using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Scriptable Objects/TurretData")]
public class TurretData : ScriptableObject
{
    public float flechaVel;
    public float cooldownTiro;  // Tempo ate atirar de novo
    public float delayPosTiro;  // Tempo parado depois de atirar
    public float delayPreTiro;  // Tempo de preparo antes de atirar
}
