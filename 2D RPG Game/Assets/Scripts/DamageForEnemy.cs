using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    public float damageToGiveEnemy;
    public GameObject damageBurst; // particle effect when hit the enemy with our sword
    public Transform hitPoint; //edge of the sword.. to detect collision between enemy and this hit point

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagManager.ENEMY_TAG)
        {
            collision.gameObject.GetComponent<EnemyHPmanager>().DmgEnemy(damageToGiveEnemy);
            Instantiate(damageBurst, hitPoint.position, Quaternion.identity); 
            
            /*Instantiate the particle effect at the place where hit.
             You can also pass hitpoint.rotation instead of quaternion.identity because we don't have any rotation in that hit point
            anyway*/


        } 
    }



}
