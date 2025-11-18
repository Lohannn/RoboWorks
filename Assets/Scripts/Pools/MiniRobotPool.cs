using UnityEngine;

public class MiniRobotPool : MonoBehaviour
{
    [SerializeField] private GameObject miniPerfectRobot;
    private GameObject[] miniPerfectRobotPool = new GameObject[3];
    [SerializeField] private GameObject miniBrokenRobot;
    private GameObject[] miniBrokenRobotPool = new GameObject[3];

    [SerializeField] private GameObject[] heads;
    [SerializeField] private GameObject[] bodies;
    [SerializeField] private GameObject[] lArms;
    [SerializeField] private GameObject[] rArms;
    [SerializeField] private GameObject[] treads;

    private void Start()
    {
        InstantiatePerfectRobots();
        InstantiateBrokenRobots();
    }

    public GameObject GetRandomRobot(Vector2 position, Transform parent)
    {
        if (Random.Range(0, 2) == 0)
        {
            return GetPerfectRobot(position, parent);
        }
        else
        {
            return GetBrokenRobot(position, parent);
        }
    }

    private void InstantiatePerfectRobots()
    {
        for (int i = 0; i < miniPerfectRobotPool.Length; i++)
        {
            miniPerfectRobotPool[i] = Instantiate(miniPerfectRobot);
            miniPerfectRobotPool[i].SetActive(false);
        }
    }

    public GameObject GetPerfectRobot(Vector2 position, Transform parent)
    {
        foreach (var robot in miniPerfectRobotPool)
        {
            if (!robot.activeInHierarchy)
            {
                CreatePerfectRobot(robot);
                robot.transform.SetParent(parent);
                robot.transform.localPosition = position;
                robot.SetActive(true);
                return robot;
            }
        }
        Debug.LogError("Error: Not enough perfect robots in Pool.");
        return null;
    }

    private void InstantiateBrokenRobots()
    {
        for (int i = 0; i < miniBrokenRobotPool.Length; i++)
        {
            miniBrokenRobotPool[i] = Instantiate(miniBrokenRobot);
            miniBrokenRobotPool[i].SetActive(false);
        }
    }

    public GameObject GetBrokenRobot(Vector2 position, Transform parent)
    {
        foreach (var robot in miniBrokenRobotPool)
        {
            if (!robot.activeInHierarchy)
            {
                CreateBrokenRobot(robot);
                robot.transform.SetParent(parent);
                robot.transform.localPosition = position;
                robot.SetActive(true);
                return robot;
            }
        }
        Debug.LogError("Error: Not enough broken robots in Pool.");
        return null;
    }

    private void CreatePerfectRobot(GameObject robot)
    {
        MiniRobot robotPrefab = robot.GetComponent<MiniRobot>();
        robotPrefab.SetHead(heads[0]);
        robotPrefab.SetBody(bodies[0]);
        robotPrefab.SetLArm(lArms[0]);
        robotPrefab.SetRArm(rArms[0]);
        robotPrefab.SetTread(treads[0]);
    }

    private void CreateBrokenRobot(GameObject robot)
    {
        MiniRobot robotPrefab = robot.GetComponent<MiniRobot>();

        while (IsAllThePartsPerfect(robotPrefab))
        {
            robotPrefab.SetHead(heads[Random.Range(0, heads.Length)]);
            robotPrefab.SetBody(bodies[Random.Range(0, bodies.Length)]);
            robotPrefab.SetLArm(lArms[Random.Range(0, lArms.Length)]);
            robotPrefab.SetRArm(rArms[Random.Range(0, rArms.Length)]);
            robotPrefab.SetTread(treads[Random.Range(0, treads.Length)]);
        }
    }

    private bool IsAllThePartsPerfect(MiniRobot robot)
    {
        return robot.GetHead().GetComponent<Head>().GetState() == "Perfect" &&
               robot.GetBody().GetComponent<Body>().GetState() == "Perfect" &&
               robot.GetLArm().GetComponent<LArm>().GetState() == "Perfect" &&
               robot.GetRArm().GetComponent<RArm>().GetState() == "Perfect" &&
               robot.GetTread().GetComponent<Tread>().GetState() == "Perfect";
    }
}
