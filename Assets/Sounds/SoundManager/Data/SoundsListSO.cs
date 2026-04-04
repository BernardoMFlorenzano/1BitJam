using UnityEngine;

[CreateAssetMenu(fileName = "SoundsListSO", menuName = "Scriptable Objects/SoundsListSO")]
public class SoundsListSO : ScriptableObject
{
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip flipCardSound;
    public AudioClip correctSound;
    public AudioClip failSound;
    public AudioClip deathSound;
    public AudioClip trampolimSound;
    public AudioClip selectSound;

}
