using System.Collections.Generic;
using UnityEngine;

public class SpineHighlighter : MonoBehaviour
{
    public Material normalMat;
    public Material dimMat;
    public Material highlightMat;

    public List<MeshRenderer> cervicalBones;
    public List<MeshRenderer> thoracicBones;
    public List<MeshRenderer> lumbarBones;
    public List<MeshRenderer> sacrumBones;

    private List<MeshRenderer> allBones = new List<MeshRenderer>();

    void Awake()
    {
        allBones.AddRange(cervicalBones);
        allBones.AddRange(thoracicBones);
        allBones.AddRange(lumbarBones);
        allBones.AddRange(sacrumBones);
    }

    public void HighlightRegion(SpineRegion region)
    {
        foreach (var bone in allBones)
            bone.material = dimMat;

        List<MeshRenderer> targetRegion = GetRegion(region);

        foreach (var bone in targetRegion)
            bone.material = highlightMat;
    }

    public void ResetAll()
    {
        foreach (var bone in allBones)
            bone.material = normalMat;
    }

    private List<MeshRenderer> GetRegion(SpineRegion region)
    {
        switch (region)
        {
            case SpineRegion.Cervical: return cervicalBones;
            case SpineRegion.Thoracic: return thoracicBones;
            case SpineRegion.Lumbar: return lumbarBones;
            case SpineRegion.Sacrum: return sacrumBones;
        }

        return cervicalBones;
    }
}