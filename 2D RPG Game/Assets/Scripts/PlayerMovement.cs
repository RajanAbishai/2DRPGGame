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


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true; //if player doesn't exist, make him exist.
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
