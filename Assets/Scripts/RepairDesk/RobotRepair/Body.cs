using UnityEngine;

public class Body : MonoBehaviour
{
    private enum State
    {
        Broken,
        Perfect
    }

    [SerializeField] private State state;

    public string GetState()
    {
        return state.ToString();
    }
}
