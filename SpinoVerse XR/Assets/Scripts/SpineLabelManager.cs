using UnityEngine;

public class SpineLabelManager : MonoBehaviour
{
    public GameObject cervicalLabel;
    public GameObject thoracicLabel;
    public GameObject lumbarLabel;
    public GameObject sacrumLabel;
    public GameObject coccyxLabel;

    public void ShowLabel(SpineRegion region)
    {
        HideAll();

        switch (region)
        {
            case SpineRegion.Cervical:
                cervicalLabel.SetActive(true);
                break;

            case SpineRegion.Thoracic:
                thoracicLabel.SetActive(true);
                break;

            case SpineRegion.Lumbar:
                lumbarLabel.SetActive(true);
                break;

            case SpineRegion.Sacrum:
                sacrumLabel.SetActive(true);
                break;

            case SpineRegion.Coccyx:
                coccyxLabel.SetActive(true);
                break;
        }
    }

    public void HideAll()
    {
        cervicalLabel.SetActive(false);
        thoracicLabel.SetActive(false);
        lumbarLabel.SetActive(false);
        sacrumLabel.SetActive(false);
        coccyxLabel.SetActive(false);
    }
}