using UnityEngine;

public class PanelOpenTrigger : MonoBehaviour
{
    public UILineAnimator line;

    void OnEnable()
    {
        line.AnimateLine();
    }
}