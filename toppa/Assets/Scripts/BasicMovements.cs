using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BasicMovements :  MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    
    #region Private Variables
    private Vector3 Velocity;
    #endregion
    
    #region Cached Components
    private Rigidbody Rb;
    #endregion
    

    void Awake () {
        Debug.Log("Awaked");
        Velocity = Vector3.zero;
        Rb = GetComponent<Rigidbody>(); 
    }

    void Start () {
        Debug.Log("Start Called"); 
        if (Rb != null) {
            Rb.useGravity = false;
        }
        Velocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {   
        float p_verticalSpeedController = Input.GetAxis("Vertical");
        float p_horizontalSpeedController = Input.GetAxis("Horizontal");
        Velocity.Set(p_horizontalSpeedController, 0f, p_verticalSpeedController);
    }

    void FixedUpdate () {
        // Debug.Log("m_speed is" + m_speed + " and DeltaTime is" + Time.fixedDeltaTime);
        // Debug.Log(Velocity.magnitude + " is the magnitude of velocity"); 
        
        Rb.velocity = Velocity * m_speed * Time.fixedDeltaTime * Velocity.magnitude;         
    }
}
