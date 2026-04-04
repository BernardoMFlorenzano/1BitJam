using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSetup : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;                  // Arraste o AudioMixer aqui pelo Inspector
    [SerializeField] private string exposedParam = "masterVolume";   // Nome do parâmetro no AudioMixer
    [SerializeField] private Slider slider;                          // Arraste o Slider aqui, ou use GetComponent

    private void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        if (audioMixer.GetFloat(exposedParam, out float valueInDb))
        {
            slider.value = DbToLinear(valueInDb);
        }
    }

    private float DbToLinear(float db)
    {
        return Mathf.Pow(10f, db / 20f);
    }
}
