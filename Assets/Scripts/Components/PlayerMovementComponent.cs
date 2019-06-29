using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovementComponent : MonoBehaviour {

    private MoveDirection moveDirection;

    public float forwardSpeed;
    public float sideSpeed;
    public float ForwardSpeedModifier;
    public float SideSpeedModifier;
    public float JumpForce;

    private bool MoveSpeedModifierActivated;

    class MoveDirection
    {
        public int forwardAxis;
        public int sideAxis;

        public MoveDirection()
        {
            forwardAxis = 0;
            sideAxis = 0;
        }

        public void UpdateForwardAxis(int value)
        {
            forwardAxis += value;
        }
        public void UpdateSideAxis(int value)
        {
            sideAxis += value;
        }

    }

    void Start () {
        moveDirection = new MoveDirection();
        MoveSpeedModifierActivated = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	
	void Update () {

        Vector3 jumpVec = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection.UpdateForwardAxis(1);       
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection.UpdateSideAxis(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection.UpdateSideAxis(-1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection.UpdateForwardAxis(-1);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveDirection.UpdateForwardAxis(-1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveDirection.UpdateSideAxis(-1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveDirection.UpdateSideAxis(1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveDirection.UpdateForwardAxis(1);
        }
        // SHIFT
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeedModifierActivated = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeedModifierActivated = false;
        }
        // SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpVec.y = JumpForce;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<MouseLook>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<MouseLook>().enabled = true;
        }

        if (GetComponent<Rigidbody>())
        {
            Vector3 forwardVelocity = transform.forward * moveDirection.forwardAxis * forwardSpeed * (MoveSpeedModifierActivated ? ForwardSpeedModifier : 1.0f);
            forwardVelocity.y = 0;
            Vector3 sideVelocity = (Quaternion.Euler(0, -90, 0) * transform.forward) * moveDirection.sideAxis * sideSpeed * (MoveSpeedModifierActivated ? SideSpeedModifier : 1.0f);
            sideVelocity.y = 0;
            jumpVec.y += GetComponent<Rigidbody>().velocity.y;
            GetComponent<Rigidbody>().velocity = forwardVelocity + sideVelocity + jumpVec; 
        }
        
    }

}
