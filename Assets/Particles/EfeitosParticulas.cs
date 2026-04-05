using System.Runtime.Serialization;
using UnityEngine;

public class EfeitosParticulas : MonoBehaviour
{
    [SerializeField] private ParticleSystem efeitoQueda;

    public void PlayEfeitoQueda()
    {
        efeitoQueda.Play();
    }
}
