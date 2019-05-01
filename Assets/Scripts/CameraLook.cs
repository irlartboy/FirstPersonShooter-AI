using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool isCursorHidden = true;
    public float minPitch = -60f, maxPitch = 80f;
    public Vector2 speed = new Vector2(120f, 120f);


    private Vector2 euler; // current rotation of camera

    void Start()
    {
        if (isCursorHidden)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        euler = transform.eulerAngles;
    }

    void Update()
    {
        euler.y += Input.GetAxis("Mouse X") * speed.x * Time.deltaTime;
        euler.x -= Input.GetAxis("Mouse Y") * speed.y * Time.deltaTime;

        // Clamp 
        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);
        // rotate player and camera seperate
        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);
    }
}
