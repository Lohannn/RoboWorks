using UnityEngine;
using UnityEngine.UI;

public class MainTitleButton : MonoBehaviour
{
    private Animator anim;
    private Sprite defaultImage;

    private void Start()
    {
        anim = GetComponent<Animator>();
        defaultImage = GetComponent<Image>().sprite;
    }

    public void Press()
    {
        if (GetComponent<Image>().sprite == defaultImage)
        {
            anim.SetTrigger("pPressed");
        }
    }
}
