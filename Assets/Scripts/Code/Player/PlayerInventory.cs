using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Tool EquipedTool { get; set; }

    private uint x;
    private uint y;

    public GameObject slot;
    public Transform inventoryPannel;

}
