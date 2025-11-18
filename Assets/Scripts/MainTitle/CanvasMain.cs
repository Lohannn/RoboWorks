using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private Canvas optionCanvas;
    [SerializeField] private Canvas exitCanvas;

    private SFXSoundPlayerManager uiSoundPlayer;
    private MusicPlayerManager musicPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<SFXSoundPlayerManager>();
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayerManager>();
    }

    public void Play()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.CLICK);
        musicPlayer.PlayMusic(MusicPlayerManager.STAGE);
        SceneManager.LoadScene("FactoryScene");
    }

    public void Options()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.CLICK);
        optionCanvas.enabled = true;
    }

    public void Exit()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.CLICK);
        exitCanvas.enabled = true;
    }
}
