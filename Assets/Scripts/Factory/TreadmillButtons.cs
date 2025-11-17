using UnityEngine;

public class TreadmillButtons : MonoBehaviour
{
    private SpriteRenderer shade;
    private Color32 shadeColor;

    [SerializeField] private FactoryTreadmillManager treadmill;
    [SerializeField] private RepairDesk repairDesk;

    [SerializeField] private enum ButtonFunction
    {
        SendRobot,
        RepairRobot
    }

    [SerializeField] private ButtonFunction buttonFunction;

    private void Start()
    {
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
            repairDesk.SetTargetPosition(Vector3.zero);
        }
    }

    private void OnMouseUp()
    {
        shade.color = shadeColor;
    }
}
