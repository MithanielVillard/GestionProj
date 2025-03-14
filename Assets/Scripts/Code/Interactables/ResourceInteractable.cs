using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceInteractable : Interactable
{
    [Header("Properties")]
    [SerializeField] private Resource[] resultResources;
    [SerializeField] private string treeType; 

    public override void OnInteract(GameObject player)
    {
        Debug.Log("Arbre coup� !");
        player.GetComponent<PlayerInventory>().AddItem(resultResources[0], 1);
        Destroy(gameObject);
    }

    protected override void OnNoteTaken(GameObject player)
    {
        Debug.Log($"Note ajoutée : {treeType}");
        UIManager.Instance.ShowNotebookPage(treeType);
    }
}

