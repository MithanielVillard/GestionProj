using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Resource")]
[System.Serializable]
public class Resource : ScriptableObject
{
    public string resourceName;
    public string resourceDescription;
    public Sprite resourceSprite;
}
