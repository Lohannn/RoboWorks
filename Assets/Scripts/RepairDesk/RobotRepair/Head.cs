using UnityEngine;

public class Head : MonoBehaviour
{
    private enum State
    {
        BrokenTurnedOff,
        Broken,
        TurnedOff,
        Perfect
    }
    [SerializeField] private State state;

    [SerializeField] Sprite[] sprites;

    private SpriteRenderer sr;

    private void Start()
    {
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
        if (CheckIfHasAToolPicked())
        {
            if (state == State.BrokenTurnedOff && CheckIfHasAToolPicked().gameObject.name == "Hammer")
            {
                sr.sprite = sprites[2];
                state = State.Broken;
            }
            else if (state == State.BrokenTurnedOff && CheckIfHasAToolPicked().gameObject.name == "Screwdriver")
            {
                sr.sprite = sprites[1];
                state = State.TurnedOff;
            }

            if (state == State.Broken && CheckIfHasAToolPicked().gameObject.name == "Screwdriver")
            {
                sr.sprite = sprites[0];
                state = State.Perfect;
            }

            if (state == State.TurnedOff && CheckIfHasAToolPicked().gameObject.name == "Hammer")
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
