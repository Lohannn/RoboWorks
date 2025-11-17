using UnityEngine;

public class FactoryTreadmill : MonoBehaviour
{
    private Transform siblingTreadmill;
    private FactoryTreadmillManager manager;

    private void Start()
    {
        manager = transform.parent.GetComponent<FactoryTreadmillManager>();

        siblingTreadmill = transform.CompareTag("ImageTreadmillBot") ?
            GameObject.FindGameObjectWithTag("ImageTreadmillTop").transform :
            GameObject.FindGameObjectWithTag("ImageTreadmillBot").transform;
    }

    private void Update()
    {
        transform.Translate(manager.GetSpeed() * Time.deltaTime * Vector3.down);

        if (transform.position.y <= -10.0f)
        {
            transform.position = new Vector3(transform.position.x, 
                siblingTreadmill.position.y + siblingTreadmill.GetComponent<SpriteRenderer>().bounds.size.y - 0.02f, 
                transform.position.z);
        }
    }
}
