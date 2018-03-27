using UnityEngine;

public class Mapper : MonoBehaviour
{
    [SerializeField]
    private MapSo map;
    [SerializeField]
    private InventoryManager invManager;

    void Start()
    {
        foreach (var record in map.Map)
        {
            var go = Instantiate(invManager.GetInvItem(record.InvIndex));
            var a = GameObject.Find("Element" + record.X + record.Y);
            go.transform.parent = a.transform;
            go.transform.localPosition = new Vector2(0f, 0f);
        }
    }
}
