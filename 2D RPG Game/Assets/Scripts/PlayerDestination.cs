using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestination : MonoBehaviour
{
    /*We are gonna attach the Player Destination script to the Spawn point of the player (Game Object)*/


    private PlayerMovement thePlayer;
    private CameraFollow theCamera;
    public Vector2 startDirection;

    public string point;

    
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();

        if (thePlayer.startPoint == point)
        {
            thePlayer.transform.position = transform.position;  //This is the current position of our player on the left, On the right.. the spawn point?    //this will be positioned in the other scene
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraFollow>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);

        }

        
    }

}
