using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool IsOccupied {get; set;} //equivalent getter / setter en c++
    public uint Quantity { get; private set; }
    public uint StackSize { get; private set; }
    public Resource Resource {get; private set;}

    public bool AddResource(Resource resource, uint count = 1)
    {
        if (this.Resource != null) return false;
        if (this.Quantity + count > StackSize) return false;
        
        this.Resource = resource;
        StackSize = resource.stackSize;
        Quantity = count;
        return true;
    }
}
