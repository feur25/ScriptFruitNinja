using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController
{
    private Animation _animation;

    public float walkSpeed = 1;
    public float runSpeed = 6;
    public float turnSpeed = 200;

    public string inputForward;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpUp;
    CapsuleCollider playerCollider;
    Rigidbody rigidbody;

    float PlayerPositionZ;


    void Awake() {
        _animation = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Start(){
        rigidbody.freezeRotation = true;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    bool IsGrounded() {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.09f);
    }

    void FixedUpdate() {

        bool forward = Input.GetKey(inputForward);
        bool back = Input.GetKey(inputBack);
        bool right = Input.GetKey(inputRight);
        bool left = Input.GetKey(inputLeft);
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        bool jumping = Input.GetKeyDown(KeyCode.Space);

        float movement = forward ? 1f : back ? -1f : 0f;
        float rotation = right ? 1f : left ? -1f : 0f;

        float finalSpeed = sprint ? runSpeed : walkSpeed;

        transform.Rotate(0, rotation * turnSpeed * Time.deltaTime, 0);


        bool newSprinting = sprint && movement != 0f;

        if(forward){
            Vector3 movementVector = transform.forward * movement * finalSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(rigidbody.position + movementVector);
        }
        

        if (jumping && IsGrounded()) {
            rigidbody.AddForce(jumpUp, ForceMode.VelocityChange);
        }

    }
}