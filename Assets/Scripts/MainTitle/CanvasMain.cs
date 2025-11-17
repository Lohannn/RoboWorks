using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private Canvas optionCanvas;
    [SerializeField] private Canvas exitCanvas;

    private UISoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<UISoundPlayerManager>();
    }

    public void Play()
    {
        uiSoundPlayer.PlayMusic(UISoundPlayerManager.CLICK);
        SceneManager.LoadScene("FactoryScene");
    }

    public void Options()
    {
        uiSoundPlayer.PlayMusic(UISoundPlayerManager.CLICK);
        optionCanvas.enabled = true;
    }

    public void Exit()
    {
        uiSoundPlayer.PlayMusic(UISoundPlayerManager.CLICK);
        exitCanvas.enabled = true;
    }
}
