using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPmanager : MonoBehaviour
{
    public float enemyMaxHealth;
    public float enemyCurrentHealth;
    
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
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
