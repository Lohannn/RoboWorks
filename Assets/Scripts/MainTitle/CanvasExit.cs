using UnityEngine;
using UnityEngine.UI;

public class CanvasExit : MonoBehaviour
{
    private SFXSoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<SFXSoundPlayerManager>();
    }

    public void Confirm()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Cancel()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.CLICK);
        GetComponent<Canvas>().enabled = false;
    }
}
