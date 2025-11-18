using System.Collections;
using UnityEngine;

public class MiniRobotSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    private int spawnedRobotsCount = 0;

    private MiniRobotPool pool;
    private SFXSoundPlayerManager uiSoundPlayer;

    private void Start()
    {
        uiSoundPlayer = GameObject.FindGameObjectWithTag("UISoundPlayer").GetComponent<SFXSoundPlayerManager>();
        pool = GameObject.FindGameObjectWithTag("MiniRobotPool").GetComponent<MiniRobotPool>();
        StartCoroutine(SpawnRobots(timeToSpawn));
    }

    private IEnumerator SpawnRobots(float time)
    {
        yield return new WaitForSeconds(time);
        if (spawnedRobotsCount < 2)
        {
            pool.GetRandomRobot(transform.position, transform.parent);
            spawnedRobotsCount++;
        }
        StartCoroutine(SpawnRobots(time));
    }

    public void RobotSended()
    {
        uiSoundPlayer.PlayMusic(SFXSoundPlayerManager.SEND_ROBOT);
        spawnedRobotsCount--;
    }
}
