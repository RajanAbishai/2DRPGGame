using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPmanager : MonoBehaviour
{

    public static PlayerHPmanager instance;
    public float playerMaxHealth;
    public float playerCurrentHealth;
    public float healthBarLength; // from the UI (slider)

    public GameObject theDeathScreen;

    void Start()
    {
        MakeInstance();
        playerCurrentHealth = playerMaxHealth; //start off with Max health  
    }

    
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            theDeathScreen.SetActive(true);
            gameObject.SetActive(false);

            //activate DEATH MENU
        }
        
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DmgPlayer(float damageToGive) //damage to player
    {
        playerCurrentHealth -= damageToGive;

    }

    public void SetMaxHealth()
    {
        playerCurrentHealth -= playerMaxHealth;
    }



}
