using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed; 
    public GameObject panel;
    public Vector2 lastMove;
    public float attackingTime;
    public string startPoint;

    private Animator anim;
    private Rigidbody2D myBody;
    private bool playerMoving;
    private static bool playerExists; //if the player is in the scene
    private bool attacking;
    private float attackTimeCounter; //counter of attacking time


    
    void Start()
    {

        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        /*Connected to the game manager*/

        if (!playerExists)
        {
            playerExists = true; //if player doesn't exist, make him exist.
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }

    
    void Update()
    {
        //Use the variable pos to store the player's position and set the z axis value to auto-update to 0
        
        /* THIS CODE DOES NOT SEEM NECESSARY
        Vector3 pos = transform.position; 
        pos.z = 0;
        transform.position = pos;
        */



        playerMoving = false;

        /*If you're not attacking but you receive input along the horizontal or vertical axis, move accordingly*/
        if (!attacking)
        {
            if ((Input.GetAxisRaw("Horizontal") > 0.5f ||
                Input.GetAxisRaw("Horizontal") < -0.5f))
            {
                myBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myBody.velocity.y); //adjust only x axis
                playerMoving = true;

                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }



            if ((Input.GetAxisRaw("Vertical") > 0.5f ||
                Input.GetAxisRaw("Vertical") < -0.5f))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed); //adjust only y axis
                playerMoving = true;

                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

        }

        // Very small inputs do not count as movements for X - to prevent sliding away?
        // range that does not allow movement: -0.5f to 0.5f
        if ((Input.GetAxisRaw("Horizontal") < 0.5f &&
                Input.GetAxisRaw("Horizontal") > -0.5f))
        {
            myBody.velocity = new Vector2(0, myBody.velocity.y);
        }

        // Very small inputs do not count as movements for Y
        if ((Input.GetAxisRaw("Vertical") < 0.5f &&
                Input.GetAxisRaw("Vertical") > -0.5f))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }



        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool(TagManager.PLAYER_ATTACKING_PARAMETER,false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            attackTimeCounter = attackingTime;
            attacking = true;
            myBody.velocity = Vector3.zero; //this is done to prevent the player from moving while attacking
            
            anim.SetBool(TagManager.PLAYER_ATTACKING_PARAMETER, true);


        }

        anim.SetFloat(TagManager.PLAYER_X_MOVEMENT, Input.GetAxisRaw("Horizontal"));
        anim.SetFloat(TagManager.PLAYER_Y_MOVEMENT, Input.GetAxisRaw("Vertical"));

        anim.SetBool(TagManager.PLAYER_MOVING_PARAMETER,playerMoving); //transfer the bool value of playerMoving to player moving parameter

        anim.SetFloat(TagManager.LAST_MOVE_X, lastMove.x);
        anim.SetFloat(TagManager.LAST_MOVE_Y, lastMove.y);

    }









}  //class
