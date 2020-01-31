using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int timesJumped;
    public float jumpSpeed;
    public bool isGrounded;
    public float deadZone;
    private float distToGround;
    private Vector3 movementDirection;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        distToGround = transform.GetChild(0).GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update(){
        PlayerJump();
        float horizontal = Input.GetAxis("Horizontal");

        if(Mathf.Abs(Input.GetAxis("Horizontal")) > deadZone){
            Vector3 movement  = new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
            rigidBody.MovePosition(transform.position+movement);
        }
    }

    void PlayerJump(){
        if(Input.GetKeyDown("space") && timesJumped < 1){  
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            timesJumped++;
        }
        isGrounded = IsGrounded();
        if(isGrounded){
            timesJumped = 0;
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
        

}
