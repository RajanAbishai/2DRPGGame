using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPmanager : MonoBehaviour
{
    public float enemyMaxHealth;
    public float enemyCurrentHealth;
    
    /*seemed to work even without it or no compiler error*/
    public static EnemyHPmanager instance; 
    
    void Start()
    {
        makeInstance();
        enemyCurrentHealth = enemyMaxHealth;
    }

    
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void DmgEnemy(float DmgToGive)
    {
        enemyCurrentHealth -= DmgToGive;
    }

    public void sexMaxHealth()
    {
        enemyCurrentHealth -= enemyMaxHealth;
    }

}
