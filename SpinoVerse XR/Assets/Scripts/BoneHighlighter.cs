using System.Collections.Generic;
using UnityEngine;

public class BoneHighlighterManager : MonoBehaviour
{
    [Header("Base Materials")]
    public Material normalMaterial;
    public Material dimMaterial;

    [Header("Region Highlight Materials")]
    public Material cervicalHighlight;
    public Material thoracicHighlight;
    public Material lumbarHighlight;
    public Material sacrumHighlight;

    [Header("Spine Regions")]
    public List<MeshRenderer> cervicalBones = new List<MeshRenderer>();
    public List<MeshRenderer> thoracicBones = new List<MeshRenderer>();
    public List<MeshRenderer> lumbarBones = new List<MeshRenderer>();
    public List<MeshRenderer> sacrumBones = new List<MeshRenderer>();

    private List<MeshRenderer> allBones = new List<MeshRenderer>();

    private void Awake()
    {
        allBones.Clear();
        allBones.AddRange(cervicalBones);
        allBones.AddRange(thoracicBones);
        allBones.AddRange(lumbarBones);
        allBones.AddRange(sacrumBones);
    }

    public void HighlightRegion(SpineRegion region)
    {
        // Step 1: Dim everything
        foreach (MeshRenderer bone in allBones)
        {
            if (bone != null)
                bone.material = dimMaterial;
        }

        // Step 2: Get region bones
        List<MeshRenderer> targetRegion = GetRegionList(region);
        Material regionMaterial = GetHighlightMaterial(region);

        // Step 3: Apply region-specific highlight
        foreach (MeshRenderer bone in targetRegion)
        {
            if (bone != null)
                bone.material = regionMaterial;
        }
    }

    public void ResetAll()
    {
        foreach (MeshRenderer bone in allBones)
        {
            if (bone != null)
                bone.material = normalMaterial;
        }
    }

    private List<MeshRenderer> GetRegionList(SpineRegion region)
    {
        switch (region)
        {
            case SpineRegion.Cervical: return cervicalBones;
            case SpineRegion.Thoracic: return thoracicBones;
            case SpineRegion.Lumbar: return lumbarBones;
            case SpineRegion.Sacrum: return sacrumBones;
            default: return cervicalBones;
        }
    }

    private Material GetHighlightMaterial(SpineRegion region)
    {
        switch (region)
        {
            case SpineRegion.Cervical: return cervicalHighlight;
            case SpineRegion.Thoracic: return thoracicHighlight;
            case SpineRegion.Lumbar: return lumbarHighlight;
            case SpineRegion.Sacrum: return sacrumHighlight;
            default: return cervicalHighlight;
        }
    }
}