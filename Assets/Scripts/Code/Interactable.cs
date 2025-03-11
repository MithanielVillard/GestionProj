using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private string interactionName;

    private void OnHover()
    {
        
    }
    
    public abstract void OnInteract();
}
