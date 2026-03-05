using UnityEngine;
using TMPro;

public class SpineRegionJsonLoader : MonoBehaviour
{
    [Header("UI References (Same Text Used by SpinoVerseUIPanel)")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public GameObject panelRoot;

    private PanelDataList panelList;

    void Awake()
    {
        LoadJson();
    }

    void LoadJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("SpinoVersePanels");

        if (jsonFile == null)
        {
            Debug.LogError("SpinoVersePanels.json not found in Resources.");
            return;
        }

        panelList = JsonUtility.FromJson<PanelDataList>(jsonFile.text);
    }

    public void LoadRegion(SpineRegion region)
    {
        int id = GetPanelId(region);

        foreach (PanelData panel in panelList.panels)
        {
            if (panel.id == id)
            {
                titleText.text = panel.title;
                descriptionText.text = panel.description;

                panelRoot.SetActive(true);
                return;
            }
        }

        Debug.LogWarning("Panel ID not found for region: " + region);
    }

    public void HidePanel()
    {
        panelRoot.SetActive(false);
    }

    int GetPanelId(SpineRegion region)
    {
        switch (region)
        {
            case SpineRegion.Cervical:
                return 3;

            case SpineRegion.Thoracic:
                return 4;

            case SpineRegion.Lumbar:
                return 5;

            case SpineRegion.Sacrum:
                return 2; // change if needed

            default:
                return 1;
        }
    }
}