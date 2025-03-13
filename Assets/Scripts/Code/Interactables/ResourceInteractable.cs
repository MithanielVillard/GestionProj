using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceInteractable : Interactable
{
    [Header("Properties")]
    [SerializeField] private Tool requiredTool;
    [SerializeField] private Resource[] resultResources;

    public override void OnInteractStart(GameObject player)
    {
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
        if (playerInventory.EquippedTool != null && playerInventory.EquippedTool.toolCategory == requiredTool.toolCategory)
        {
            player.GetComponent<PlayerMovement>().Move(transform.position, () =>
            {
                base.OnInteractStart(player);
            });
        }
    }

    public override void OnInteract(GameObject player)
    {
        Debug.Log("Arbre coup� !");
        player.GetComponent<PlayerInventory>().AddItem(resultResources[0], 1);
        Destroy(gameObject);
    }

}
