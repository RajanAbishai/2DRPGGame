using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    /*This script lets the camera follow the player but the player has to be assigned manually in the Unity Editor*/

    public GameObject followTarget;
    private Vector3 targetPos; 
    public float moveSpeed;
    private static bool cameraExists;


    void Start()
    {
        // we are transferring the camera onto the next scene

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }


        /* if camera already exists, we will destroy the camera because we don't want 2 cameras in the scene. Cameras were deleted anyway.
         So, if we disable Destroy(gameObject), the DontDestroyOnLoad becomes irrelevant? 
         */
        else
        {
            Destroy(gameObject); 
        }
        
    }

    
    void Update()
    {
       /*"we do not want to adjust z axis." ... Placing -10 because normally, the camera is at -10 when the game is being run.
        When the -10 isn't there, the camera isn't able to display the player and the map*/


       targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, followTarget.transform.position.z-10);
       transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed *Time.deltaTime );

    }
}
