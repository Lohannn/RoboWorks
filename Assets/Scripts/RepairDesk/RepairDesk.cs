using UnityEngine;

public class RepairDesk : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool isInteractable;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.02f)
            {
                transform.position = targetPosition;

                if (targetPosition != originalPosition)
                {
                    isInteractable = true;
                }
            }
        }
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;

        if (targetPosition == originalPosition)
        {
            isInteractable = false;
        }
    }

    public Vector3 GetOriginalPosition()
    {
        return originalPosition;
    }

    public bool IsInteractable()
    {
        return isInteractable;
    }
}
