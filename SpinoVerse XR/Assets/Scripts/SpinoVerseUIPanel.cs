using UnityEngine;
using TMPro;

public class SpinoVerseUIPanel : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI buttonText;

    private PanelDataList panelList;
    private int currentIndex = 0;

    void Start()
    {
        LoadJson();
        UpdateUI();
    }

    void LoadJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("SpinoVersePanels");

        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found in Resources folder.");
            return;
        }

        panelList = JsonUtility.FromJson<PanelDataList>(jsonFile.text);
    }

    public void NextState()
    {
        currentIndex++;

        if (currentIndex >= panelList.panels.Length)
            currentIndex = 0;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (panelList == null || panelList.panels.Length == 0)
            return;

        var panel = panelList.panels[currentIndex];

        titleText.text = panel.title;
        descriptionText.text = panel.description;
        buttonText.text = panel.buttonText;
    }
}