using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    public float mouseSens;
    public Transform playerBody;

    public float rotX;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        rotX -= MouseY;
        rotX = Mathf.Clamp(rotX, -60f, 60f);

        transform.localRotation = Quaternion.Euler(rotX,0f,0f); 
        playerBody.Rotate(Vector3.up * MouseX);


    }
}
