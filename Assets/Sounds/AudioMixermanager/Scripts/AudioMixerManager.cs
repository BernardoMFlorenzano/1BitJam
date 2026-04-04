using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    
     [SerializeField] AudioMixer audioMixer;

     public void setMasterVolume(float level)
     {
            audioMixer.SetFloat("MasterMixerVolume", Mathf.Log10(level) * 20);
     }

     public void setSoundFXVolume(float level)
     {
            audioMixer.SetFloat("SFXMixerVolume", Mathf.Log10(level) * 20);
     }

     public void setMusicVolume(float level)
     {
            audioMixer.SetFloat("MusicMixerVolume", Mathf.Log10(level) * 20);
     }
    
}
