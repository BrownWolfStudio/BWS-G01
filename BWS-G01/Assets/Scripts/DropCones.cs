using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCones : MonoBehaviour
{
    public GameObject[] Cones;
    public float Speed = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var cone in Cones)
            {
                cone.GetComponent<Rigidbody2D>().gravityScale = Speed;
            }
        }
    }
}
