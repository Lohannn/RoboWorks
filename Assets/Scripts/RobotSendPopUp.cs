using System.Collections;
using UnityEngine;

public class RobotSendPopUp : MonoBehaviour
{
    private Vector2 originalPosition;
    private bool canMove;

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.up * 2.5f * Time.deltaTime);
        }
    }

    public void Activate()
    {
        originalPosition = transform.position;
        StartCoroutine(PopUpTimer());
    }

    private IEnumerator PopUpTimer()
    {
        canMove = true;
        yield return new WaitForSeconds(1f);
        canMove = false;
        transform.position = originalPosition;
    }
}
