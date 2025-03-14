using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InventorySlot inventorySlotPrefab;
    [SerializeField] private ItemStack itemStackPrefab;
    
    [Header("Inventory Properties")]
    [SerializeField] private uint width = 3;
    [SerializeField] private uint height = 3;
    
    [field: SerializeField]
    public Tool EquippedTool { get; set; }
    
    //--------------------
    private GridLayoutGroup _gridLayoutGroup;
    private InventorySlot[,] _gridInventory;

    private void Start()
    {
        _gridLayoutGroup = GameObject.FindWithTag("InventoryLayoutGroup").GetComponent<GridLayoutGroup>();
        _gridInventory = new InventorySlot[width, height];
        
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                _gridInventory[i, j] = Instantiate(inventorySlotPrefab, _gridLayoutGroup.transform);
            }
        }
    }

    public void SetItem(Resource resource, uint amount, uint x, uint y)
    {
        ItemStack stack = Instantiate(itemStackPrefab);
        stack.Resource = resource;
        stack.Amount = amount;
        _gridInventory[x, y].SetStack(stack);
    }
    
    public void AddItem(Resource r, uint amount)
    {
        InventorySlot emptySlot = null;
        
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (_gridInventory[x, y].ItemStack != null && _gridInventory[x, y].ItemStack.Resource == r)
                {
                    _gridInventory[x, y].ItemStack.Amount++;
                    return;
                }
                
                if (_gridInventory[x, y].IsOccupied == false) emptySlot = _gridInventory[x, y];
            }
        }

        if (emptySlot != null)
        {
            ItemStack stack = Instantiate(itemStackPrefab);
            stack.Resource = r;
            stack.Amount = amount;
            emptySlot.SetStack(stack);
        }
    }
}

