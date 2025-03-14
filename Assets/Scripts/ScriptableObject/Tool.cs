using Unity.Mathematics;
using UnityEngine;

public enum ToolCategory
{
    Axe,
    Pickaxe,
    Notebook,
    Other
}

[CreateAssetMenu(menuName = "ScriptableObject/Tool")]
public class Tool : ScriptableObject
{
    public string toolName;
    public string toolDescription;
    public ToolCategory toolCategory;
    public Sprite toolSprite;

    [Header("Inventory settings")]
    public bool3x3 inventoryGrid;
}
