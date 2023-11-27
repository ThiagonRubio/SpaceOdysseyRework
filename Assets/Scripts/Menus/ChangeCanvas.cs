
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    [SerializeField] private CanvasSwitch canvas1;
    [SerializeField] private CanvasSwitch canvas2;

    public void ChangeActiveCanvas()
    {
        canvas1.IsHidden = true;

        canvas2.IsHidden = false;
    }
}