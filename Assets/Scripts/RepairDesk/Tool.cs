using UnityEngine;

public class Tool : MonoBehaviour
{
    private bool canBePicked;
    private bool isPicked;
    private bool canReturn;

    private Vector3 originalPosition;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        originalPosition = transform.position;
    }

    private void Update()
    {
        if (!isPicked && canBePicked && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CheckIfHasOtherToolPicked() != null)
            {
                CheckIfHasOtherToolPicked().SwitchTool();
            }

            isPicked = true;
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            sr.sortingOrder = 114;
        }
        else if (isPicked && canReturn && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isPicked = false;
            gameObject.layer = LayerMask.NameToLayer("Default");
            sr.sortingOrder = 113;
        }
    }

    private void FixedUpdate()
    {
        if (isPicked)
        {
            rb.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            rb.MovePosition(originalPosition);
        }
    }

    private void OnMouseOver()
    {
        canBePicked = true;
    }

    private void OnMouseExit()
    {
        canBePicked = false;
    }

    public bool IsPicked()
    {
        return isPicked;
    }

    public void SwitchTool()
    {
        isPicked = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
        sr.sortingOrder = 113;
    }

    private Tool CheckIfHasOtherToolPicked()
    {
        GameObject[] tools = GameObject.FindGameObjectsWithTag("Tool");
        foreach (var tool in tools)
        {
            if (tool != gameObject && tool.GetComponent<Tool>().IsPicked())
            {
                return tool.GetComponent<Tool>();
            }
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ToolSlot") && collision.transform == transform.parent)
        {
            canReturn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ToolSlot") && collision.transform == transform.parent)
        {
            canReturn = false;
        }
    }
}
