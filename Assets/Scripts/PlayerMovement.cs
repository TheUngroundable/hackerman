using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int maxJumps;
    public float jumpSpeed;
    private Vector3 movementDirection;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        PlayerJump();
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement  = new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        rigidBody.MovePosition(transform.position+movement);
    }

    void PlayerJump(){
        if(Input.GetKeyDown("space") && maxJumps < 2){  
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            maxJumps++;
        }
    }

}
