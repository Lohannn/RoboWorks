using UnityEngine;

public class MusicPlayerManager : MonoBehaviour
{
    private static MusicPlayerManager instance;
    [SerializeField] private AudioClip[] musicClips;

    public const int MAIN_TITLE = 0;
    public const int STAGE = 1;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayMusic(MAIN_TITLE);
    }

    public void PlayMusic(int musicIndex)
    {
        audioSource.resource = musicClips[musicIndex];
        audioSource.Play();
    }
}
