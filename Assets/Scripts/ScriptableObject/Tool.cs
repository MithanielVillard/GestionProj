using UnityEngine;

public enum ToolCategory
{
    Axe,
    Pickaxe,
    Other,
}

[CreateAssetMenu(menuName = "ScriptableObject/Tool")]
public class Tool : ScriptableObject
{
    public string toolName;
    public string toolDescription;
    public ToolCategory toolCategory;
    public Sprite toolSprite;
}
