using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour{
    public bool repaired;
    public float explosionRadius = 5;
    private Rigidbody rb;

    public float explosionForce = 850;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetRepaired(bool repaired){
        this.repaired = repaired;
        TileManager.Instance.curRoom.CheckForDoor();
        rb.isKinematic =false;
        Vector3 rndForce = new Vector3(transform.localPosition.x + Random.Range(0, .3f), transform.localPosition.y + Random.Range(0, .3f), transform.localPosition.z + Random.Range(0, .3f));
        rb.AddExplosionForce(explosionForce, transform.position + new Vector3(+1f,0,0), explosionRadius, 3.0F);
        // Alert tile manager
    }

}
