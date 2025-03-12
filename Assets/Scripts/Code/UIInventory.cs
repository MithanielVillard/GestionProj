using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory; // référence à ton script d'inventaire
    [SerializeField] private Transform inventoryGridParent;   // le panel avec le Grid Layout Group
    [SerializeField] private GameObject slotPrefab;           // le prefab du slot

    private const int width = 3;
    private const int height = 3;

    private UIInventorySlot[,] uiSlots;

    private void Start()
    {
        uiSlots = new UIInventorySlot[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject slotObj = Instantiate(slotPrefab, inventoryGridParent);
                UIInventorySlot uiSlot = slotObj.GetComponent<UIInventorySlot>();

                uiSlots[x, y] = uiSlot;

                uiSlot.xIndex = x;
                uiSlot.yIndex = y;
            }
        }
    }

}