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

    public string GetState()
    {
        return state.ToString();
    }
}
