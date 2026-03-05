using System;

[System.Serializable]
public class PanelData
{
    public int id;
    public string title;
    public string description;
    public string buttonType;
}

[System.Serializable]
public class PanelDataList
{
    public PanelData[] panels;
}