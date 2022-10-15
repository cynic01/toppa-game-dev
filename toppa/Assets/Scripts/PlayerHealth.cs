using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    public float m_PlayerMaxHealth = 1000;

    // public Transform cam;
    #endregion

    public HealthBar healthBar;

    #region Private Variables
    // current player health
    public float p_CurHealth;
    #endregion

    #region Cached Components
    private Rigidbody rb;
    #endregion


    // The GameObject to be spawned
    public GameObject go;
    // Start is called before the first frame update
    void Start () {
        Debug.Log("Start Called"); 
        p_CurHealth = 1000 ; // Temporary Amount to edit later
        healthBar.setHealth(p_CurHealth);
        healthBar.setMaxHealth(m_PlayerMaxHealth);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.space)) {
        //     DecreaseHealth(50);
        // }
        DecreaseHealth(600);
    }


    // LateUpdate is called once per frame
    void LateUpdate()
    {   
        // Health Bar UI that always points toward the Camera and 
        // does NOT rotate along with the RigidBody (Player/Enemey)
        // transform.LookAt(transform.position + cam.forward);
    }


    #region Regeneration/Damage Response Methods

    public void DecreaseHealth(float amount) {
        p_CurHealth = Mathf.Max(0, m_PlayerMaxHealth - amount);
        healthBar.setHealth(p_CurHealth);
        //rb.UpdateHealth(1.0f * p_CurHealth / m_PlayerMaxHealth); // After incorpotating UpdateHealth method
        if (p_CurHealth == 0) {
            //Signals Death & goes back to main menu (UI?)
        }
    }

    public void IncreaseHealth(float amount) {
        p_CurHealth = Mathf.Min(m_PlayerMaxHealth, p_CurHealth + amount);
        //rb.UpdateHealth(1.0f * p_CurHealth / m_PlayerMaxHealth); // After incorpotating UpdateHealth method
    }
    #endregion
}
