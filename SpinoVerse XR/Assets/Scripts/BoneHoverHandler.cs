using UnityEngine;

public class BoneHoverHandler : MonoBehaviour
{
    [Header("Spine Region")]
    public SpineRegion region;

    [Header("Managers")]
    public BoneHighlighterManager highlightManager;
    public SpineRegionJsonLoader regionLoader;
    public SpineLabelManager labelManager;

    private bool isLocked = false;

    public void OnHoverEnter()
    {
        if (highlightManager != null)
            highlightManager.HighlightRegion(region);

        if (regionLoader != null)
            regionLoader.LoadRegion(region);

        if (labelManager != null)
            labelManager.ShowLabel(region);
    }

    public void OnHoverExit()
    {
        if (isLocked) return; // If clicked, keep label visible

        if (highlightManager != null)
            highlightManager.ResetAll();

        if (regionLoader != null)
            regionLoader.HidePanel();

        if (labelManager != null)
            labelManager.HideAll();
    }

    public void OnPanelClick()
    {
        isLocked = true;

        if (labelManager != null)
            labelManager.ShowLabel(region);
    }

    public void ResetSelection()
    {
        isLocked = false;

        if (labelManager != null)
            labelManager.HideAll();

        if (regionLoader != null)
            regionLoader.HidePanel();

        if (highlightManager != null)
            highlightManager.ResetAll();
    }
}

public enum SpineRegion
{
    Cervical,
    Thoracic,
    Lumbar,
    Sacrum,
    Coccyx
}