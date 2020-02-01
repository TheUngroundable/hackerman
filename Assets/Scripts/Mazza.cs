using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazza : MonoBehaviour
{

    public Player player;
    void OnCollisionEnter(Collision collision) {
        if(player.isAttacking){
            MazzaAudioManager.Instance.PlayHit();
            if (collision.gameObject.tag == "Computer"){
                collision.gameObject.GetComponent<Computer>().setRepaired(true);
            }
        }
    }
}
