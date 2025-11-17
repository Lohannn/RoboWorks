using UnityEngine;

public class LArm : MonoBehaviour
{
    private enum State
    {
        Broken,
        SemiBroken,
        Perfect
    }

    [SerializeField] private State state;
}
