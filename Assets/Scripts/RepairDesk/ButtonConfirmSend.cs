using UnityEditor;
using UnityEngine;

public class ButtonConfirmSend : MonoBehaviour
{
    private SpriteRenderer shade;
    private RepairDesk desk;
    private Ronaldo ronaldo;
    private void Start()
    {
        ronaldo = GameObject.FindGameObjectWithTag("Ronaldo").GetComponent<Ronaldo>();
        desk = transform.parent.GetComponent<RepairDesk>();
        shade = transform.GetChild(0).GetComponent<SpriteRenderer>();
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

            desk.SetTargetPosition(desk.GetOriginalPosition());
            ronaldo.SetTarget(new Vector3(-0.35f, ronaldo.transform.position.y, 0), Ronaldo.WALK_LEFT);
        }
    }
}
