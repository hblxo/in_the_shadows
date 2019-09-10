using System.ComponentModel;

public static class GeneralData
{
    public enum Scenes
    {
        FirstMenu = 0, Menu = 1,
    }

    public enum MovieNames
    {
        [Description("Alice in Wonderland")]Alice,
        [Description("Dumbo")]Dumbo,
        [Description("Treasure Planet")]Planet,
        [Description("The Hitchhiker's Guide to the Galaxy")]H2G2,
        [Description("Hook")]Hook,
        [Description("")]ToDefine,
    }
    
    public static int LevelToUnlock { get; set; }
    public static bool OptionsPanelOpen { get; set; }
    public static bool EndPanelOpen { get; set; }
    public static bool DevMode { get; set; }
    public static int AvailableLevels { get; set; }
    
}