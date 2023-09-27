using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

    public Transform orientation;

    float movesSpeed = 3;
    float panSpeed = 20;
    Vector3 remove = new Vector3(500, 250, 0);
    Vector3 position = new Vector3(0, 0, 0);
    
    private void Update()
    {
        //creates vector where when the mouse is at the center of the screen the vector will be 0, 0, 0
        Vector3 mouse = Input.mousePosition-remove;
        //if the mouse is close to the center nothing will change
        if(mouse.y < 30 && mouse.y > -30){
            mouse.y = 0;
        }
        if(mouse.x < 30 && mouse.x > -30){
            mouse.x = 0;
        }
        //if(mouse.y > 30 || mouse.y < -30 || mouse.x > 30 || mouse.x < -30){
            //while the right mouse button is pressed, pan based on the mouse movement
            if(Input.GetKey(KeyCode.Mouse1)== true){
                //get the position of the mouse
                Vector3 panPosition = new Vector3(-mouse.y, mouse.x, 0);
                //convert the mouse position to a velocity
                Vector3 panVelocity = panPosition.normalized*panSpeed;
                //convert the velocity to a distance based on the time that has passed
                Vector3 panMoveAmount = panVelocity*Time.deltaTime;
                //pan
                transform.Rotate(panMoveAmount);
            }
            //if the right mouse button is not being pressed move the camera based on the mouse movement
            else{
                Vector3 position = new Vector3(mouse.x, 0, mouse.y);
                //convert the mouse position to a velocity
                Vector3 velocity = position.normalized*movesSpeed;
                //convert the velocity to a distance based on the time that has passed
                Vector3 moveAmount = velocity*Time.deltaTime;
                //move
                transform.localPosition += moveAmount;
            }
        //}
    }
}
