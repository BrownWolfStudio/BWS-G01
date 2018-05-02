using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSequence : MonoBehaviour
{
    public GameObject camera;

    Camera cam;

    void Start()
    {
        cam = camera.GetComponent<Camera>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.backgroundColor = Color.white;
        }
    }
}
