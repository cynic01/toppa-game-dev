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


    // // The GameObject to be spawned
    // public GameObject go;
    // Start is called before the first frame update
    void Start () {
        Debug.Log("Start Called"); 
        p_CurHealth = m_PlayerMaxHealth;
        healthBar.setMaxHealth(m_PlayerMaxHealth);
        healthBar.setHealth(p_CurHealth);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.space)) {
        //     DecreaseHealth(50);
        // }
<<<<<<< HEAD
        DecreaseHealth(800);
=======
        // DecreaseHealth(600);
>>>>>>> 5d512037d0f85a4c206827c43a6cde66a14bf34b
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
        p_CurHealth = Mathf.Max(0, p_CurHealth - amount);
        healthBar.setHealth(p_CurHealth);
        Debug.Log(p_CurHealth);
        //rb.UpdateHealth(1.0f * p_CurHealth / m_PlayerMaxHealth); // After incorpotating UpdateHealth method
        if (p_CurHealth == 0) {
            //Signals Death & goes back to main menu (UI?)
            Debug.Log("Player died");
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void IncreaseHealth(float amount) {
        p_CurHealth = Mathf.Min(m_PlayerMaxHealth, p_CurHealth + amount);
        //rb.UpdateHealth(1.0f * p_CurHealth / m_PlayerMaxHealth); // After incorpotating UpdateHealth method
    }
    #endregion
}
