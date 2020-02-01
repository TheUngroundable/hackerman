using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour{
     public bool repaired;                      //se il monitor è stato fixado
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetRepaired(bool repaired){
        rb.isKinematic =false;
        this.repaired = repaired;
        TileManager.Instance.curRoom.CheckForDoor();
        Vector3 rndForce = new Vector3(transform.localPosition.x + Random.Range(0, .3f), transform.localPosition.y + Random.Range(0, .3f), transform.localPosition.z + Random.Range(0, .3f));
         rb.AddExplosionForce(850,transform.position + new Vector3(+1f,0,0), 3, 3.0F);
        // Alert tile manager
    }


}
