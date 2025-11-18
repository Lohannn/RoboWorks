using UnityEditor;
using UnityEngine;

public class ButtonConfirmSend : MonoBehaviour
{
    private SpriteRenderer shade;
    private RepairDesk desk;
    private Ronaldo ronaldo;

    private MiniRobot currentRobot;
    private GameObject[] robotParts;

    private SpriteRenderer sr;
    private Collider2D col; 

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        ronaldo = GameObject.FindGameObjectWithTag("Ronaldo").GetComponent<Ronaldo>();
        desk = transform.parent.GetComponent<RepairDesk>();
        shade = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (robotParts != null)
        {
            if (!sr.enabled && CheckIfAllPartsAreFixed(robotParts))
            {
                Show();
            }
        }
    }

    private void OnMouseOver()
    {
        if (desk.IsInteractable())
        {
            shade.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        shade.enabled = false;
    }

    private void OnMouseDown()
    {
        if (desk.IsInteractable()) {
            GameObject[] tools = GameObject.FindGameObjectsWithTag("Tool");

            foreach (var tool in tools)
            {
                if (tool.GetComponent<Tool>().IsPicked())
                {
                    tool.GetComponent<Tool>().SwitchTool();
                    break;
                }
            }

            currentRobot.Repair();
            foreach (var part in robotParts)
            {
                Destroy(part);
            }
            robotParts = null;
            desk.SetTargetPosition(desk.GetOriginalPosition());
            ronaldo.SetTarget(new Vector3(-0.35f, ronaldo.transform.position.y, 0), Ronaldo.WALK_LEFT);
        }
    }

    public void Hide()
    {
        col.enabled = false;
        sr.enabled = false;
    }

    public void Show()
    {
        print(CheckIfAllPartsAreFixed(robotParts));
        col.enabled = true;
        sr.enabled = true;
    }

    public void SetRobot(MiniRobot robot)
    {
        currentRobot = robot;
    }

    public void SetRobotParts(GameObject[] parts)
    {
        robotParts = parts;
    }

    private bool CheckIfAllPartsAreFixed(GameObject[] parts)
    {
        int partsFixed = 0;

        if (parts != null)
        {
            foreach (var part in parts)
            {
                if (part.name.Contains("Head") && part.GetComponent<Head>().GetState() == "Perfect")
                {
                    partsFixed++;
                }
                else if (part.name.Contains("Body") && part.GetComponent<Body>().GetState() == "Perfect")
                {
                    partsFixed++;
                }
                else if (part.name.Contains("Tread") && part.GetComponent<Tread>().GetState() == "Perfect")
                {
                    partsFixed++;
                }
                else if (part.name.Contains("LArm") && part.GetComponent<LArm>().GetState() == "Perfect")
                {
                    partsFixed++;
                }
                else if (part.name.Contains("RArm") && part.GetComponent<RArm>().GetState() == "Perfect")
                {
                    partsFixed++;
                }
            }
        }

        if (partsFixed >= 5)
        {
            return true;
        }

        return false;
    }
}
