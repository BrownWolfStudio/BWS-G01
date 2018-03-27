using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCreateEnv : MonoBehaviour
{
    public float MovementSpeed = 0.1f;
    public float Smoothness = 50f;
    
    void FixedUpdate()
    {
        Vector3 targetPos;
        
        if (Input.GetAxis("Horizontal") < 0) // Left
        {
            targetPos = new Vector3(Camera.main.transform.position.x - MovementSpeed, Camera.main.transform.position.y, Camera.main.transform.position.z);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, Smoothness * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") > 0) // Right
        {
            targetPos = new Vector3(Camera.main.transform.position.x + MovementSpeed, Camera.main.transform.position.y, Camera.main.transform.position.z);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, Smoothness * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") < 0) // Down
        {
            targetPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - MovementSpeed, Camera.main.transform.position.z);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, Smoothness * Time.deltaTime);
        }
        
        if (Input.GetAxis("Vertical") > 0) // Up
        {
            targetPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + MovementSpeed, Camera.main.transform.position.z);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, Smoothness * Time.deltaTime);
        }
    }
}
