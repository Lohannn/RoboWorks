using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private Canvas optionsCanvas;

    private SFXSoundPlayerManager uiSoundPlayer;
    private MusicPlayerManager musicPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<SFXSoundPlayerManager>();
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayerManager>();
    }

    public void ResumeGame()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.CLICK);
        this.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void OpenOptions()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.CLICK);
        optionsCanvas.enabled = true;
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        musicPlayer.PlayMusic(MusicPlayerManager.MAIN_TITLE);
        SceneManager.LoadScene("MainTitleScene");
    }
}
