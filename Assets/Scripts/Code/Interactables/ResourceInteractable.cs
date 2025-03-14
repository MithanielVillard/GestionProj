using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceInteractable : Interactable
{
    [Header("Properties")]
    [SerializeField] private Tool requiredTool;
    [SerializeField] private Resource[] resultResources;
    [SerializeField] private string treeType; 

    public override void OnInteractStart(GameObject player)
    {
        Debug.Log("Arbre coupé !");
        Destroy(gameObject);
    }

    protected override void OnNoteTaken()
    {
        Debug.Log($"Note ajoutée : {treeType}");
        UIManager.Instance.ShowNotebookPage(treeType);
    }
}

