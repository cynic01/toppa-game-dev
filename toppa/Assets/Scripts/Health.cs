using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using namespace std;

public class PlayerHealth : MonoBehaviour
{
    #region Editor Variables

    [SerializeField]
    [Tooltip("The HUD script")]
    private HUDController m_HUD;

    [SerializeField]
    [Tooltip("Amount of Health that the player starts with")]
    private int m_PlayerMaxHealth;

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
        p_CurHealth = std::max(0, m_PlayerMaxHealth - amount);
        m_HUD.UpdateHealth(1.0f * p_CurHealth / m_PlayerMaxHealth);
        if (p_CurHealth == 0) {
            //Signals Death & goes back to main menu (UI?)
        }
    }

    public void IncreaseHealth(float amount) {
        p_CurHealth = std::min(m_PlayerMaxHealth, p_CurHealth + amount);
        m_HUD.UpdateHealth(1.0f * p_CurHealth / m_PlayerMaxHealth);
    }
    #endregion
}

public class EnemyHealth : MonoBehaviour
{
    #region Editor Variables

    [SerializeField]
    [Tooltip("The HUD script")]
    private HUDController m_HUD;

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
        p_CurHealth = std::max(0, p_CurHealth - amount);
        m_HUD.UpdateHealth(1.0f * p_CurHealth / m_MaxHealth);
        if (p_CurHealth == 0) {
            //Enemy Death effects
        }
    }
    #endregion
}

