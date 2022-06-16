using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForPlayer : MonoBehaviour
{

    public float damageToGivePlayer;

    /*there's a variable in the parameter for the DmgPlayer function in the PlayerHP manager script*/
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == TagManager.PLAYER_TAG)
        {
            collision.gameObject.GetComponent<PlayerHPmanager>().DmgPlayer(damageToGivePlayer);
        }

    }
}
