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

    public string GetState()
    {
        return state.ToString();
    }
}
