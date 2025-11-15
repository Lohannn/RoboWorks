using UnityEngine;
using UnityEngine.UI;

public class MainTitleTreadmill : MonoBehaviour
{
    
    private RectTransform rectTransform;
    private RectTransform siblingTreadmill;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        siblingTreadmill = transform.CompareTag("ImageTreadmillBot") ?
            GameObject.FindGameObjectWithTag("ImageTreadmillTop").GetComponent<RectTransform>() :
            GameObject.FindGameObjectWithTag("ImageTreadmillBot").GetComponent<RectTransform>();
    }

    
    void Update()
    {
        rectTransform.Translate(200 * Time.deltaTime * Vector2.down);

        if (rectTransform.anchoredPosition.y <= -1460)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, siblingTreadmill.anchoredPosition.y + 2195);
        }
    }
}
