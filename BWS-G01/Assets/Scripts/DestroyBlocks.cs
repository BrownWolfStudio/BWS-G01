using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{
    public GameObject[] ObjectsToDestroy;
    public GameObject DestroySprite;

    public void Start()
    {
        StartCoroutine("Destroyed");
    }

    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(10f);
        foreach (var go in ObjectsToDestroy)
        {
            Destroy(go);
        }
    }
}
