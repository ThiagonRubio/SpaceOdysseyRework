using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject currentCanvas;
    public GameObject newCanvas;

    public void SwitchCanvas()
    {
        currentCanvas.SetActive(false);
        newCanvas.SetActive(true);
    }
}
