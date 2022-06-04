using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    public Slider healthBar;
    public PlayerHPmanager playerHealth;
    public static bool UIexists;

    void Start()
    {
        if (!UIexists)
        {
            UIexists = true;
            DontDestroyOnLoad(transform.gameObject); // Don't destroy our UI on load?
        }

        else
        {
            Destroy(gameObject); //If UI exists, destroy it
        }
        
    }

   
    void Update()
    {

        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth; //set the player's current health in the UI bar 
        
    }
}
