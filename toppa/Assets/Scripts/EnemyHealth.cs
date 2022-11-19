using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private KillMsg msg;

        // // The GameObject to be spawned
        // public GameObject go;
        // Start is called before the first frame update
        void Start()
        {
            msg = GameObject.Find("Msg Manager").GetComponent<KillMsg>();
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
                Destroy(gameObject);
                msg.ShowMsg("Enemy");
                
            }
        }
        #endregion
    }