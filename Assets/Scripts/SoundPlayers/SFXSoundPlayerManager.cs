using UnityEngine;

public class SFXSoundPlayerManager : MonoBehaviour
{
    private static SFXSoundPlayerManager instance;
    [SerializeField] private AudioClip[] soundClips;

    public const int CLICK = 0;
    public const int TOOLS = 1;
    public const int FIX_ROBOT = 2;
    public const int SEND_ROBOT = 3;

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
    }

    public void PlayMusic(int soundIndex)
    {
        audioSource.resource = soundClips[soundIndex];

        audioSource.Play();
    }
}
