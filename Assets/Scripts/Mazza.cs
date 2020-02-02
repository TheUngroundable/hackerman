﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazza : MonoBehaviour
{

    public Player player;
    
    public float explosionForce = 850;
    public float explosionRadius = 5;
    public int computersFixed = 0;
    void OnCollisionEnter(Collision collision) {
        if(player.isAttacking){
            MazzaAudioManager.Instance.PlayHit();
            if(collision.gameObject.GetComponent<Rigidbody>() != null){
                Rigidbody collisionRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 rndForce = new Vector3(collision.transform.localPosition.x + Random.Range(0, .3f), collision.transform.localPosition.y + Random.Range(0, .3f), collision.transform.localPosition.z + Random.Range(0, .3f));
                collisionRigidbody.AddExplosionForce(explosionForce, rndForce, explosionRadius, 3.0F);
                computersFixed++;
                TimeManager.Instance.UpdateCounter(computersFixed);
            }
        
            if (collision.gameObject.tag == "Computer" && !collision.gameObject.GetComponent<Computer>().repaired){
                Computer computer = collision.gameObject.GetComponent<Computer>();
                computer.SetRepaired(true);
            }
        }
    }
}
