using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;


    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioSource _musicSource;


    [Header("--SoundSFX---")]
    public AudioClip jumpSound;
    public AudioClip laserSound;
    public AudioClip successSound;
    public AudioClip failSound;
    public AudioClip creatureSound;
    public AudioClip trasitionSound;


    [Header("--Musics---")]
    public AudioClip gameMusic;
    public AudioClip menuMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

       
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "FinalMenu")
            Music(menuMusic);

        else
            Music(gameMusic);
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume, float pitch = 1f)
    {
        AudioSource audioSource = Instantiate(_audioSource, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.pitch = pitch;

        audioSource.Play();

        float clipLenght = audioClip.length;

        //Destroi depois de tocar o clip;
        Destroy(audioSource.gameObject, clipLenght);


    }

    public void Music(AudioClip musicClip)
    {
        if (_musicSource.clip != musicClip)
        {
            _musicSource.clip = musicClip;
            _musicSource.loop = true;
            _musicSource.Play();
        }
    }
}
