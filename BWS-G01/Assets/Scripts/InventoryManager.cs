using UnityEngine;

[CreateAssetMenu(fileName = "NewInvManager", menuName = "SOs/New Inventory Manager")]
public class InventoryManager : ScriptableObject
{
    [SerializeField]
    private GameObject[] inventoryItems;

    public int CurrentItemIndex = 0;

    public GameObject GetInvItem(int index = 0)
    {
        return inventoryItems[index];
    }

    public GameObject[] GetInvItems(int startIndex, int endIndex)
    {
        var invItems = new GameObject[endIndex - startIndex];
        
        for (var i = startIndex; i < endIndex; i++)
        {
            invItems[i] = inventoryItems[i];
        }
        
        return invItems;
    }

    public GameObject[] GetAllInvItems()
    {
        return inventoryItems;
    }
}