using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BasicMovements :  MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    [SerializeField]
    private float MouseSensitivity;

    [SerializeField]
    private GameObject Camera;

    #region Private Variables
    private Vector2 flatVelocity;
    #endregion
    
    #region Cached Components
    private Rigidbody Rb;
    private Animator anim;
    #endregion

    CharacterController controller;
    Vector3 threeDimDirection;
    public bool jumped = false;
    float cur = 0f;
    bool jumping = false;

    void Awake () {
        Debug.Log("Awaked");
        flatVelocity = Vector3.zero;
        Rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Start () {
        flatVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //nothing need to be updated based on frame.
    }

    void Update () {
        
        //read the keyboard input of movement direction
        float p_verticalSpeedController = Input.GetAxis("Vertical");
        float p_horizontalSpeedController = Input.GetAxis("Horizontal");

        //change the animation
        flatVelocity.Set(p_horizontalSpeedController, p_verticalSpeedController);
        flatVelocity = Vector2.ClampMagnitude(flatVelocity, 1);
        if (flatVelocity.magnitude >= 0.1) {
            anim.SetBool("running", true);
        } else {
            anim.SetBool("running", false);
        }
        
        //read the camera direction
        Vector3 camF = Camera.transform.forward;
        Vector3 camR = Camera.transform.right;

        Vector3 height = new Vector3(0, 0, 0);
        
        //move the player on a flat surface based on camera direction
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        threeDimDirection = (camF * p_verticalSpeedController + camR * p_horizontalSpeedController) * m_speed * Time.deltaTime;
        float jumpLimit = 5f;
        
        

        
        if (controller.isGrounded && !Input.GetKeyDown(KeyCode.Space)) { //running on the ground
            threeDimDirection.y = Physics.gravity.y;
            jumped = false;
        } 
        if(Input.GetKeyDown(KeyCode.Space) && !jumped) { //jumping from the ground
            jumped = true;
            threeDimDirection.y += 0.1f;
            cur += 0.1f;
            //threeDimDirection.y = 1.2f;
            jumping = true;
            Debug.Log("state 2");
        } 
        if(jumping && cur <= jumpLimit) { //jumping but in the air
            threeDimDirection.y += 0.2f;
            cur += 0.2f;
            jumping = true;
            Debug.Log("state 3");
        }
        if (cur > jumpLimit) { //reached the highest point
            jumping = false;
            cur = 0;
            Debug.Log("state 4");
        }
        if (!controller.isGrounded && !jumping) { //falling
            threeDimDirection.y += Physics.gravity.y * Time.deltaTime*1.5f;
            jumped = true;
            Debug.Log("state 5");
        } 
        
        

        controller.Move(threeDimDirection);
        //transform.position += m_speed * Time.deltaTime * (camF * p_verticalSpeedController + camR * p_horizontalSpeedController);
        

        //rotate the player so that it always look forward.
        Vector3 MovementDirection = camF;
        MovementDirection = MovementDirection.normalized;
        //Debug.Log("vertical speed is " + p_verticalSpeedController + " and horizontal speed is " + p_horizontalSpeedController);
        if (MovementDirection != Vector3.zero) {
            transform.forward = MovementDirection;
        }
    }
}
