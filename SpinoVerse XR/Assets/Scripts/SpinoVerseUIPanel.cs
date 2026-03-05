using UnityEngine;
using TMPro;

public class SpinoVerseUIPanel : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Transform buttonParent;

    [Header("Button Prefabs")]
    public GameObject startButtonPrefab;
    public GameObject nextDefaultPrefab;
    public GameObject nextDefaultPrefab_1;
    public GameObject nextCervicalPrefab;
    public GameObject nextThoracicPrefab;
    public GameObject nextLumbarPrefab;

    private PanelDataList panelList;
    private int currentIndex = 0;
    private GameObject currentButton;

    void Start()
    {
        LoadJson();
        UpdateUI();
    }

    void LoadJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("SpinoVersePanels");
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
    var panel = panelList.panels[currentIndex];

    titleText.text = panel.title;
    descriptionText.text = panel.description;

    if (currentButton != null)
        Destroy(currentButton);

    switch (panel.buttonType)
    {
        case "Start":
            currentButton = Instantiate(startButtonPrefab, buttonParent);
            break;

        case "Next_Default":
            currentButton = Instantiate(nextDefaultPrefab, buttonParent);
            break;

        case "Next_Default_1":
            currentButton = Instantiate(nextDefaultPrefab, buttonParent);
            break;

        case "Next_Cervical":
            currentButton = Instantiate(nextCervicalPrefab, buttonParent);
            break;

        case "Next_Thoracic":
            currentButton = Instantiate(nextThoracicPrefab, buttonParent);
            break;

        case "Next_Lumbar":
            currentButton = Instantiate(nextLumbarPrefab, buttonParent);
            break;
    }
}
}