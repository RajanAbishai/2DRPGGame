using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string LevelToLoad; 
    public string ExitPoint;
    private PlayerMovement thePlayer;

    /*If this code is used, the level that must be loaded is to be specified in every case */

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == TagManager.PLAYER_TAG)
        {
            SceneManager.LoadScene(LevelToLoad);
            thePlayer.startPoint = ExitPoint;

        }


    }




}
