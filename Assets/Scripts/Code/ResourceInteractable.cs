using UnityEngine;

public class ResourceInteractable : Interactable
{

    [Header("Properties")]
    [SerializeField] private Tool requiredTool;
    [Tooltip("Listes des resources recus lors de l'intereraction")]
    [SerializeField] private Resource[] resultResources;

    public override void OnInteract()
    {
        
    }
}
