using System.Collections;
using UnityEngine;

public class RArm : MonoBehaviour
{
    private enum State
    {
        Broken,
        SemiBroken,
        Perfect
    }
    [SerializeField] private State state;

    [SerializeField] Sprite[] sprites;

    private SpriteRenderer sr;
    private SFXSoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<SFXSoundPlayerManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    private Tool CheckIfHasAToolPicked()
    {
        GameObject[] tools = GameObject.FindGameObjectsWithTag("Tool");
        foreach (var tool in tools)
        {
            if (tool.GetComponent<Tool>().IsPicked())
            {
                return tool.GetComponent<Tool>();
            }
        }
        return null;
    }

    private void OnMouseUpAsButton()
    {
        if (CheckIfHasAToolPicked() != null && CheckIfHasAToolPicked().gameObject.name == "Wrench" || CheckIfHasAToolPicked().gameObject.name == "DoubleWrench")
        {
            uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.FIX_ROBOT);

            if (state == State.SemiBroken)
            {
                sr.sprite = sprites[0];
                state = State.Perfect;
            }

            if (state == State.Broken)
            {
                sr.sprite = sprites[1];
                state = State.SemiBroken;
            }
        }
    }

    public string GetState()
    {
        return state.ToString();
    }
}
