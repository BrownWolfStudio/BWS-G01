using UnityEngine;

public class Grider : MonoBehaviour
{
    private GameObject emptGO;

    public int Rows = 32;

    public int Cols = 128;

    // Initialize Grid
    void Awake()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                emptGO = new GameObject("Element" + i.ToString() + j.ToString());
                emptGO.transform.parent = this.gameObject.transform;
                emptGO.transform.position = new Vector2(this.gameObject.transform.position.x + i, this.gameObject.transform.position.y + j);
                emptGO.AddComponent<BoxCollider2D>().isTrigger = true;
                emptGO.layer = 8;
                IconManager.SetIcon(emptGO, IconManager.Icon.DiamondBlue);
            }
        }
    }
}
