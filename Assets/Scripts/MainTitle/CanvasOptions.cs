using UnityEngine;
using UnityEngine.UI;

public class CanvasOptions : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private AudioSource musicVolume;
    private AudioSource sfxVolume;

    private UISoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        musicVolume = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>();
        sfxVolume = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<AudioSource>();
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<UISoundPlayerManager>();

        musicVolumeSlider.value = GameManager.musicVolume;
        sfxVolumeSlider.value = GameManager.sfxVolume;

        musicVolumeSlider.onValueChanged.AddListener(delegate { 
            GameManager.musicVolume = musicVolumeSlider.value;

            musicVolume.volume = GameManager.musicVolume;
        });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { 
            GameManager.sfxVolume = sfxVolumeSlider.value;

            sfxVolume.volume = GameManager.sfxVolume;
        });
    }

    public void Back()
    {
        uiSoundPlayer.PlayMusic(UISoundPlayerManager.CLICK);
        GetComponent<Canvas>().enabled = false;
    }
}
