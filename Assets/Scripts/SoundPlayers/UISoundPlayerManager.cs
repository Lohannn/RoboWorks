using UnityEngine;

public class UISoundPlayerManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;

    public const int CLICK = 0;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(int soundIndex)
    {
        audioSource.PlayOneShot(soundClips[soundIndex]);
    }
}
