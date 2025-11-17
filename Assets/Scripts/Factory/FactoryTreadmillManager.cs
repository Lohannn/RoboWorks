using UnityEngine;

public class FactoryTreadmillManager : MonoBehaviour
{
    [SerializeField] private float treadmillMoveSpeed;
    private float currentTreadmillSpeed;
    private bool isActive = true;

    private void Start()
    {
        currentTreadmillSpeed = treadmillMoveSpeed;
    }

    private void Update()
    {
        Acceleration();
        Deceleration();
    }

    private void Acceleration()
    {
        if (isActive && currentTreadmillSpeed < treadmillMoveSpeed)
        {
            currentTreadmillSpeed += 0.5f * Time.deltaTime;

            if (currentTreadmillSpeed < treadmillMoveSpeed && currentTreadmillSpeed > treadmillMoveSpeed - 0.1f)
            {
                currentTreadmillSpeed = treadmillMoveSpeed;
            }
        }
    }

    private void Deceleration()
    {
        if (!isActive && currentTreadmillSpeed > 0.0f)
        {
            currentTreadmillSpeed -= 0.5f * Time.deltaTime;

            if (currentTreadmillSpeed > 0.0f && currentTreadmillSpeed < 0.1f)
            {
                currentTreadmillSpeed = 0;
            }
        }
    }

    public float GetSpeed()
    {
        return currentTreadmillSpeed;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
