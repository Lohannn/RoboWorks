using UnityEngine;
using UnityEngine.UI;

public class CanvasExit : MonoBehaviour
{
    private UISoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<UISoundPlayerManager>();
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
        uiSoundPlayer.PlayMusic(UISoundPlayerManager.CLICK);
        GetComponent<Canvas>().enabled = false;
    }
}
