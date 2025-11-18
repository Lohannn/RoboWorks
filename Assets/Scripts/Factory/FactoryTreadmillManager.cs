using UnityEngine;

public class FactoryTreadmillManager : MonoBehaviour
{
    [SerializeField] private float treadmillMoveSpeed;
    private float currentTreadmillSpeed;
    private bool isActive = true;

    private MiniRobot currentRobot;

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
            currentTreadmillSpeed -= 1f * Time.deltaTime;

            if (currentTreadmillSpeed > 0.0f && currentTreadmillSpeed < 0.1f)
            {
                currentTreadmillSpeed = 0;
            }
        }
    }

    public MiniRobot GetCurrentRobot()
    {
        return currentRobot;
    }

    public void SetCurrentRobot(MiniRobot robot)
    {
        currentRobot = robot;
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
        if (currentTreadmillSpeed <= 0)
        {
            isActive = true;
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
