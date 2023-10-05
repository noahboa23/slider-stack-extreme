/***************************************************************************************
This Object is applied to the camera to move it and pan it based on the keys W,S,A,D and the right and leftarrows.
To pan: use the left and right arrows
To move: Use the W,S,A,D keys.
****************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePan : MonoBehaviour
{

    public Transform orientation;
    public float acceleration = 0.0002F;
    public float maxSpeed = 0.007F;

    Vector3 velocity;

    float xRotation;
    float yRotation;

    Vector3 velocityX;
    Vector3 velocityY;

    // Lock the mouse movement and make the mouse invisible.
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    private void Update()
    {
        // For each user movement command the program first calculates the next potential movement and stores it to test.
        // If the magnitude of the next potential speed change is less than the maxSpeed the speed will be stored to either velocityY or velocityX and then later updated.

        //If the W key is pressed increase the Y velocity relative to the orientation. This will move forwards relative to the camera.
        Vector3 test = velocityY + (orientation.forward * acceleration);
        if (Input.GetKey(KeyCode.W) == true && test.sqrMagnitude < maxSpeed)
        {
            velocityY = test;
        }
        //If the S key is pressed decrease the Y velocity relative to the orientation. This will move backwards relative to the camera.
        test = velocityY - (orientation.forward * acceleration);
        if (Input.GetKey(KeyCode.S) == true && test.sqrMagnitude < maxSpeed)
        {
            velocityY = test;
        }
        //If the D key is pressed increase the Y velocity relative to the orientation. This will move to the right relative to the camera.
        test = velocityX + (orientation.right * acceleration);
        if (Input.GetKey(KeyCode.D) == true && test.sqrMagnitude < maxSpeed)
        {
            velocityX = test;
        }
        //If the A key is pressed decrease the Y velocity relative to the orientation. This will move to the left relative to the camera.
        test = velocityX - (orientation.right * acceleration);
        if (Input.GetKey(KeyCode.A) == true && test.sqrMagnitude < maxSpeed)
        {
            velocityX = test;
        }

        float YRotIntensity = 1F;
        float XRotIntensity = 1F;
        //If the right arrow is pressed rotate right.
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            yRotation += YRotIntensity;
            xRotation -= XRotIntensity;
        }
        //If the left arrow is pressed rotate left.
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            yRotation -= YRotIntensity;
            xRotation += XRotIntensity;
        }
        //Make the rotation.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        velocity = velocityY + velocityX;
        //Update the velocity.
        transform.localPosition += velocity;
    }
}
