using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceInteractable : Interactable
{
    [Header("Properties")]
    [SerializeField] private Tool requiredTool;
    [SerializeField] private Resource[] resultResources;

    public override void OnInteract()
    {
        Debug.Log("Arbre coupé !");
        Destroy(gameObject);
    }

}
