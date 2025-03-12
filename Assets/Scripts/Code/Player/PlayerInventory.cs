using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Tool EquipedTool { get; set; }

    private const uint width = 3;
    private const uint height = 3;

    private InventorySlot[,] gridInventory;

    private void Awake()
    {
        // Initialisation de la grille
        gridInventory = new InventorySlot[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gridInventory[i, j] = new InventorySlot();
            }
        }
    }

    // Exemple de méthode pour ajouter un objet dans l'inventaire
    public bool AddItem(Tool newTool)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (gridInventory[i, j].IsEmpty())
                {
                    gridInventory[i, j].tool = newTool;
                    return true;
                }
            }
        }
        return false; // Inventaire plein
    }
}

// Classe représentant un emplacement de l'inventaire
public class InventorySlot
{
    public Tool tool;

    public bool IsEmpty()
    {
        return tool == null;
    }
}

