using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public class PlayerHealth : MonoBehaviour
    {
        #region Editor Variables
        [SerializeField]
        private int m_PlayerMaxHealth;

        public Transform cam;
        #endregion


        #region Private Variables
        // current player health
        private float p_CurHealth;
        #endregion

        #region Cached Components
        private Rigidbody rb;
        #endregion


        // The GameObject to be spawned
        public GameObject go;
        // Start is called before the first frame update
        void Start () {
            Debug.Log("Start Called"); 
            p_CurHealth = 0 ; // Temporary Amount to edit later
        }

        // Update is called once per frame
        void LateUpdate()
        {   
            // Health Bar UI that always points toward the Camera and 
            // does NOT rotate along with the RigidBody (Player/Enemey)
            transform.LookAt(transform.position + cam.forward);
        }


        #region Regeneration/Damage Response Methods

        public void DecreaseHealth(float amount) {
            p_CurHealth = Mathf.Max(0, m_PlayerMaxHealth - amount);
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

    public class EnemyHealth : MonoBehaviour
    {
        #region Editor Variables

        [SerializeField]
        [Tooltip("Amount of Health that the player starts with")]
        private int m_EnemeyMaxHealth;

        #endregion


        #region Private Variables

        // current player health
        private float p_CurHealth;

        #endregion


        // The GameObject to be spawned
        public GameObject go;
        // Start is called before the first frame update
        void Start()
        {
            //
        }

        // Update is called once per frame
        void Update()
        {
            //
        }


        #region Regeneration/Damage Response Methods

        public void DecreaseHealth(float amount) {
            p_CurHealth = Mathf.Max(0, p_CurHealth - amount);
            //rb.UpdateHealth(1.0f * p_CurHealth / m_MaxHealth); // After incorpotating UpdateHealth method
            if (p_CurHealth == 0) {
                //Enemy Death effects
            }
        }
        #endregion
    }

}

