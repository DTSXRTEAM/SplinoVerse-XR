using UnityEngine;

public class BoneHoverHandler : MonoBehaviour
{
    public SpineRegion region;
    public BoneHighlighterManager highlightManager;
    public SpineRegionJsonLoader regionLoader;

    public void OnHoverEnter()
    {
        highlightManager.HighlightRegion(region);
        regionLoader.LoadRegion(region);
    }

    public void OnHoverExit()
    {
        highlightManager.ResetAll();
        regionLoader.HidePanel();
    }
}

public enum SpineRegion
{
    Cervical,
    Thoracic,
    Lumbar,
    Sacrum
}