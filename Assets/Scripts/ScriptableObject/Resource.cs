using Unity.Mathematics;
using UnityEngine;

public enum ResourceRarity
{
    Common,
    Rare
};

[CreateAssetMenu(menuName = "ScriptableObject/Resource")]
[System.Serializable]
public class Resource : ScriptableObject
{
    public string resourceName;
    public string resourceDescription;
    public Sprite resourceSprite;

    [Header("Inventory settings")]
    public ResourceRarity resourceRarity;
    public uint stackSize;
    public bool3x3 inventoryGrid;
    
}
