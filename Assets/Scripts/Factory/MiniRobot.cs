using UnityEngine;

public class MiniRobot : MonoBehaviour
{
    private FactoryTreadmillManager manager;

    private void Start()
    {
        manager = transform.parent.GetComponent<FactoryTreadmillManager>();
    }

    void Update()
    {
        transform.Translate(manager.GetSpeed() * Time.deltaTime * Vector3.down);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TreadmillStopPoint"))
        {
            manager.Deactivate();
        }
    }
}
