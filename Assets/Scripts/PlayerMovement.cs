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
    private Animator meshAnimator;
    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        meshAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        PlayerJump();
        MovePlayer();
        PlayerAttack();
    }

    void PlayerAttack(){
        if(Input.GetButtonDown("Fire1")){
            meshAnimator.SetTrigger("attack");
        }
    }

    void MovePlayer(){
        float horizontal = Input.GetAxis("Horizontal");

        if(Mathf.Abs(Input.GetAxis("Horizontal")) > deadZone){
            if(Input.GetAxis("Horizontal")>0){
                transform.localEulerAngles = new Vector3(0, 90, 0);
            } else {
                transform.localEulerAngles = new Vector3(0, -90, 0);
            }
            Vector3 movement  = new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
            rigidBody.MovePosition(transform.position+movement);
            meshAnimator.SetBool("isRunning", true);
        } else {
            meshAnimator.SetBool("isRunning", false);
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
            meshAnimator.SetBool("isFalling", false);
        } else {
            meshAnimator.SetBool("isFalling", true);
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
        

}
