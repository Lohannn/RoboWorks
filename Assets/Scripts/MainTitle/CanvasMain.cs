using UnityEngine;
using UnityEngine.UI;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private Canvas optionCanvas;
    [SerializeField] private Canvas exitCanvas;

    private UISoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<UISoundPlayerManager>();
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
