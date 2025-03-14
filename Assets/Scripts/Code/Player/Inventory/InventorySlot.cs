using UnityEngine;

public class InventorySlot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject itemStackPrefab;
    
    //-----------------------
    
    public bool IsOccupied {get; set;} //equivalent getter / setter en c++
    public uint StackSize { get; private set; }
    public ItemStack ItemStack {get; private set;}
    
    //-----------------------
    
    public void SetStack(ItemStack stack)
    {
        this.ItemStack = stack;
        stack.transform.SetParent(this.transform, false);
        stack.transform.localPosition = Vector3.zero;
        StackSize = stack.Resource.stackSize;
        IsOccupied = true;
    }
}
