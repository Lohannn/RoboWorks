using UnityEngine;

public class Body : MonoBehaviour
{
    private enum State
    {
        Broken,
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
        if (CheckIfHasAToolPicked() != null && CheckIfHasAToolPicked().gameObject.name == "Screwdriver")
        {
            uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.FIX_ROBOT);

            if (state == State.Broken)
            {
                sr.sprite = sprites[0];
                state = State.Perfect;
            }
        }
    }

    public string GetState()
    {
        return state.ToString();
    }
}
