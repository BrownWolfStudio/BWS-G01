using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastAddDelete : MonoBehaviour
{
    [SerializeField]
    private InventoryManager invManager;

    private void Update()
    {
        if (Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Pressed left click, casting ray.");
            AddComp();
        }
        if (Input.GetButton("Fire2") && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Pressed right click, casting ray.");
            RemoveComp();
        }
    }

    private void AddComp()
    {
        LayerMask layerMask = 1 << 8;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.transform.childCount == 0)
            {
                var initPrefab = Instantiate(invManager.GetInvItem(invManager.CurrentItemIndex));
                initPrefab.transform.position = hit.collider.gameObject.transform.position;
                initPrefab.transform.parent = hit.collider.gameObject.transform;
            }
        }
    }

    void RemoveComp()
    {
        LayerMask layerMask = 1 << 8;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.transform.childCount != 0)
            {
                for (var i = 0; i < hit.collider.gameObject.transform.childCount; i++)
                {
                    DestroyImmediate(hit.collider.gameObject.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
