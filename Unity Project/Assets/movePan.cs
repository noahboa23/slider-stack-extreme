/***************************************************************************************
This Object is applied to the camera to move it and pan it based on the mouse movement
To pan, right click and move the mouse
To move, left click and move the mouse
****************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePan : MonoBehaviour
{

    public Transform orientation;

    Vector3 velocity;

    public float moveSpeed = 0.1f;
    public float panSpeed = 500;

    float xRotation;
    float yRotation;

    float directionX;
    float directionY;

    // Lock the mouse movement and make the mouse invisible.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get the mouse x and y values and multiply it by delta time.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;

        // If the right click is pressed pan.
        // if (Input.GetKey(KeyCode.Mouse1) == true)
        // {
        //     mouseX = mouseX * panSpeed;
        //     mouseY = mouseY * panSpeed;

        //     yRotation += mouseX;
        //     xRotation -= mouseY;

        //     transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //     orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        // }
        // If the left click is pressed set movement velocity.
        float YIntensity = 0.3F;
        // if (Input.GetKey(KeyCode.UpArrow) == true)
        // {
        //     // directionX += YIntensity;
        //     directionY += YIntensity;
        //     // velocity = (orientation.forward * directionY * moveSpeed) + (orientation.right * directionX * moveSpeed);
        // }
        directionY = YIntensity;
        // if (Input.GetKey(KeyCode.DownArrow) == true)
        // {
        //     // directionX += YIntensity;
        //     directionY -= YIntensity;
        //     // velocity = (orientation.forward * directionY * moveSpeed) + (orientation.right * directionX * moveSpeed);
        // }

        float YRotIntensity = 1F;
        float XRotIntensity = 1F;
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            yRotation += YRotIntensity;
            xRotation -= XRotIntensity;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            yRotation -= YRotIntensity;
            xRotation += XRotIntensity;
        }
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        velocity = (orientation.forward * directionY * moveSpeed) + (orientation.right * directionX * moveSpeed);
        // Move
        transform.localPosition += velocity;
    }
}
