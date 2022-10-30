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
    private Vector2 Velocity;
    #endregion
    
    #region Cached Components
    private Rigidbody Rb;
    private Animator anim;
    #endregion
    private float heading = 0f;

    void Awake () {
        Debug.Log("Awaked");
        Velocity = Vector3.zero;
        Rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start () {
        Debug.Log("Start Called"); 
        if (Rb != null) {
            Rb.useGravity = false;
        }
        Velocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update() {
        // heading += Input.GetAxis("Mouse X") * Time.fixedDeltaTime;
        // transform.rotation = Quaternion.Euler(0, heading, 0);
        
        float p_verticalSpeedController = Input.GetAxis("Vertical");
        float p_horizontalSpeedController = Input.GetAxis("Horizontal");
        Velocity.Set(p_horizontalSpeedController, p_verticalSpeedController);
        Velocity = Vector2.ClampMagnitude(Velocity, 1);
        if (Velocity.magnitude >= 0.1) {
            anim.SetBool("running", true);
        } else {
            anim.SetBool("running", false);
        }
        
        Vector3 camF = Camera.transform.forward;
        Vector3 camR = Camera.transform.right;
        
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
        transform.position += camF * p_verticalSpeedController / 10 + camR * p_horizontalSpeedController / 10;
        
        Vector3 MovementDirection = camF;
        
        MovementDirection = MovementDirection.normalized;
        if (MovementDirection != Vector3.zero) {
            transform.forward = MovementDirection;
        }
        //transform.position += new Vector3(Velocity.x, 0, Velocity.y) * Time.fixedDeltaTime*5;
        
    }

    void FixedUpdate () {
        // Debug.Log("m_speed is" + m_speed + " and DeltaTime is" + Time.fixedDeltaTime);
        // Debug.Log(Velocity.magnitude + " is the magnitude of velocity");
        //Rb.velocity = Velocity * m_speed * Time.fixedDeltaTime * Velocity.magnitude;     
        
    }
}
