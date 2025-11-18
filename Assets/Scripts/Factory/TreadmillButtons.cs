using UnityEngine;

public class TreadmillButtons : MonoBehaviour
{
    private SpriteRenderer shade;
    private Color32 shadeColor;

    [SerializeField] private FactoryTreadmillManager treadmill;
    [SerializeField] private RepairDesk repairDesk;

    [SerializeField] private Transform robotHeadSpawner;
    [SerializeField] private Transform robotBodySpawner;
    [SerializeField] private Transform robotTreadSpawner;
    [SerializeField] private Transform robotLArmSpawner;
    [SerializeField] private Transform robotRArmSpawner;

    [SerializeField] private ButtonConfirmSend confirmSend;
    private Ronaldo ronaldo;

    [SerializeField] private enum ButtonFunction
    {
        SendRobot,
        RepairRobot
    }

    [SerializeField] private ButtonFunction buttonFunction;

    private void Start()
    {
        ronaldo = GameObject.FindGameObjectWithTag("Ronaldo").GetComponent<Ronaldo>();

        shade = transform.Find((transform.name) + "Shade").GetComponent<SpriteRenderer>();
        shadeColor = shade.color;
    }

    private void OnMouseEnter()
    {
        shade.enabled = true;
    }

    private void OnMouseExit()
    {
        shade.enabled = false;
    }

    private void OnMouseDown()
    {
        #region ia code made by Copilot
        //Feito com ajuda do Copilot da Unity a partir da seguinte linha:
        //"shade.color = new Color32(shadeColor.r - 100, shadeColor.g - 100, shadeColor.b - 100, shadeColor.a);"
        shade.color = new Color32(
            (byte)Mathf.Clamp(shadeColor.r - 100, 0, 255),
            (byte)Mathf.Clamp(shadeColor.g - 100, 0, 255),
            (byte)Mathf.Clamp(shadeColor.b - 100, 0, 255),
            shadeColor.a
        );
        #endregion

        if (buttonFunction == ButtonFunction.SendRobot)
        {
            treadmill.Activate();
        }
        else
        {
            if (treadmill.GetSpeed() == 0 && treadmill.GetCurrentRobot() != null)
            {
                ronaldo.SetTarget(new Vector3(5.25f, ronaldo.transform.position.y, 0), Ronaldo.WALK_RIGHT);

                SpawnRobotParts(treadmill.GetCurrentRobot());

                repairDesk.SetTargetPosition(Vector3.zero);
            }
        }
    }

    private void OnMouseUp()
    {
        shade.color = shadeColor;
    }

    private void SpawnRobotParts(MiniRobot currentRobot)
    {
        if (robotHeadSpawner.childCount > 0)
        {
            Destroy(robotHeadSpawner.GetChild(0).gameObject);
        }
        GameObject head = Instantiate(currentRobot.GetHead(), robotHeadSpawner.position, Quaternion.identity);
        head.transform.SetParent(robotHeadSpawner);

        if (robotBodySpawner.childCount > 0)
        {
            Destroy(robotBodySpawner.GetChild(0).gameObject);
        }
        GameObject body = Instantiate(currentRobot.GetBody(), robotBodySpawner.position, Quaternion.identity);
        body.transform.SetParent(robotBodySpawner);

        if (robotTreadSpawner.childCount > 0)
        {
            Destroy(robotTreadSpawner.GetChild(0).gameObject);
        }
        GameObject tread = Instantiate(currentRobot.GetTread(), robotTreadSpawner.position, Quaternion.identity);
        tread.transform.SetParent(robotTreadSpawner);

        if (robotLArmSpawner.childCount > 0)
        {
            Destroy(robotLArmSpawner.GetChild(0).gameObject);
        }
        GameObject lArm = Instantiate(currentRobot.GetLArm(), robotLArmSpawner.position, Quaternion.identity);
        lArm.transform.SetParent(robotLArmSpawner);

        if (robotRArmSpawner.childCount > 0)
        {
            Destroy(robotRArmSpawner.GetChild(0).gameObject);
        }
        GameObject rArm = Instantiate(currentRobot.GetRArm(), robotRArmSpawner.position, Quaternion.identity);
        rArm.transform.SetParent(robotRArmSpawner);

        confirmSend.SetRobotParts(GameObject.FindGameObjectsWithTag("RobotPart"));
        confirmSend.SetRobot(treadmill.GetCurrentRobot());
        confirmSend.Hide();
    }
}
