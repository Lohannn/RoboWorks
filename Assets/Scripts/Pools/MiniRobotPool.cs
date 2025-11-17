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
}
