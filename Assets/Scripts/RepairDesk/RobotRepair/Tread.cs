using UnityEngine;

public class Tread : MonoBehaviour
{
    private enum State
    {
        Broken,
        HalfBroken,
        SemiBroken,
        Perfect
    }

    [SerializeField] private State state;
}
