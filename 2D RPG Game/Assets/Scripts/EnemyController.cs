using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myBody;

    private bool isMoving;
    private float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;

    public float waitToReload;
    private bool reload;
    
    private GameObject thePlayer;

    private int currentScene;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        myBody = GetComponent<Rigidbody2D>();
        /*//random.range does NOT include the second parameter (number) in the sample of numbers to pick from*/
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); 
        timeToMove= Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); 

    }


    void Update()
    {
        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myBody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                /*Essentially, if you happen to randomly generate a value less than 0, you need to generate another value*/
                isMoving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

                
            }
        }

        else {

            timeBetweenMoveCounter -= Time.deltaTime;
            myBody.velocity = Vector2.zero; //short from of writing vector 2 and entering 0, 0 in the coordinates

            if (timeBetweenMoveCounter < 0f)
            {
                isMoving = true;
                //timeToMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f)*moveSpeed,Random.Range(-1f,1f) * moveSpeed );
            }

        
        }

        if (reload)
        {
            waitToReload -= Time.deltaTime;

            if (waitToReload < 0f)
            {
                SceneManager.LoadScene(currentScene); //reloads current scene
                thePlayer.SetActive(true); 
                //The above needs to be activated again because we normally transfer our player but here, we're reloading the scene
            }
        }



    }



} //class
