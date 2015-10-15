using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {
    CharacterController player;
    public Light flashlight;
    public Camera fp, tp;
    Vector3 moveDirection;
    MouseLook mouseLook;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 10.0F;
    public float Sprint = 2;
    public float sensitivity;
    float rotateSpeedX;
    bool sprint;
	// Use this for initialization
	void Start () {
        //moveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (!sprint)
                moveDirection *= speed;
            else
                moveDirection *= speed*Sprint;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        rotateSpeedX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, rotateSpeedX, 0);
        keys();
    }
    void keys() {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = true;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.enabled)
                flashlight.enabled = false;
            else
                flashlight.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = false;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {

            if (fp.enabled)
            {
                fp.enabled = false;
                tp.enabled = true;
            }
            else if (tp.enabled)
            {
                fp.enabled = true;
                tp.enabled = false;
            }

        }
    }
}
