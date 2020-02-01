using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazza : MonoBehaviour
{

    public Player player;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Computer" && player.isAttacking){
            if (!collision.gameObject.GetComponent<Computer>().repaired)
            collision.gameObject.GetComponent<Computer>().setRepaired(true);
        }
    }
}
