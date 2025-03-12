using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InventorySlot inventorySlotPrefab;
    
    [Header("Inventory Properties")]
    [SerializeField] private uint width = 3;
    [SerializeField] private uint height = 3;
    
    [field: SerializeField]
    public Tool EquippedTool { get; set; }
    
    //--------------------
    private GridLayoutGroup gridLayoutGroup;
    private InventorySlot[,] gridInventory;

    private void Start()
    {
        gridLayoutGroup = GameObject.FindWithTag("InventoryLayoutGroup").GetComponent<GridLayoutGroup>();
        gridInventory = new InventorySlot[width, height];
        
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gridInventory[i, j] = Instantiate(inventorySlotPrefab, gridLayoutGroup.transform);
            }
        }
    }
    
    // Pour l'instant on ne peux stocker que des resources TODO a modifier pour ajouter les outils
    public bool AddItem(Resource stack, uint x, uint y)
    {
        if (gridInventory[x, y] == null) return false;
        return gridInventory[x, y].AddResource(stack);
    }
}

