using UnityEngine;

public class FactoryCanva : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;

        if (!pauseCanvas.enabled)
        {
            pauseCanvas.enabled = true;
        }
        else
        {
            pauseCanvas.enabled = false;
        }
    }
}
