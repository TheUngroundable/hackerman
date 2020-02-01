using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazza : MonoBehaviour
{

    public Player player;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Computer" && player.isAttacking){
            Debug.Log("With a bat!");
            collision.gameObject.GetComponent<Computer>().setRepaired(true);
        }
    }
}
