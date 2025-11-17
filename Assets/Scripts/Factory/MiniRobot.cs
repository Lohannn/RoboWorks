using UnityEngine;

public class MiniRobot : MonoBehaviour
{
    private FactoryTreadmillManager manager;

    public enum Status
    {
        Perfect,
        Broken
    }
    [SerializeField] private Status status;
    private Status originalStatus;

    [SerializeField] private GameObject defaultHead;
    private GameObject head;
    [SerializeField] private GameObject defaultBody;
    private GameObject body;
    [SerializeField] private GameObject defaultTread;
    private GameObject tread;
    [SerializeField] private GameObject defaultLArm;
    private GameObject lArm;
    [SerializeField] private GameObject defaultRArm;
    private GameObject rArm;

    private MiniRobotSpawner spawner;

    private void OnDisable()
    {
        head = defaultHead;
        body = defaultBody;
        tread = defaultTread;
        lArm = defaultLArm;
        rArm = defaultRArm;
    }

    private void Start()
    {
        manager = transform.parent.GetComponent<FactoryTreadmillManager>();
        spawner = GameObject.FindGameObjectWithTag("MiniRobotSpawner").GetComponent<MiniRobotSpawner>();
        originalStatus = status;
    }

    void Update()
    {
        transform.Translate(manager.GetSpeed() * Time.deltaTime * Vector3.down);

        if (transform.position.y <= -6.5f)
        {
            spawner.RobotSended();
            ResetAndDeactivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TreadmillStopPoint"))
        {
            manager.Deactivate();
        }
    }

    #region Getters and Setters
    public string GetStatus()
    {
        return status.ToString();
    }

    public void SetStatus(Status robotStatus)
    {
        status = robotStatus;
    }

    public GameObject GetHead()
    {
        return head;
    }

    public void SetHead(GameObject head)
    {
        this.head = head;
    }

    public GameObject GetBody()
    {
        return body;
    }

    public void SetBody(GameObject body)
    {
        this.body = body;
    }

    public GameObject GetTread()
    {
        return tread;
    }

    public void SetTread(GameObject tread)
    {
        this.tread = tread;
    }

    public GameObject GetLArm()
    {
        return lArm;
    }

    public void SetLArm(GameObject lArm)
    {
        this.lArm = lArm;
    }

    public GameObject GetRArm()
    {
        return rArm;
    }

    public void SetRArm(GameObject rArm)
    {
        this.rArm = rArm;
    }
    #endregion

    public void ResetAndDeactivate()
    {
        head = defaultHead;
        body = defaultBody;
        tread = defaultTread;
        lArm = defaultLArm;
        rArm = defaultRArm;
        status = originalStatus;
        transform.SetParent(null);
        transform.position = new Vector2(-9.5f, 0.5f);
        gameObject.SetActive(false);
    }
}
