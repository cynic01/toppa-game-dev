using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Gun thisgun;
    public Text AmmoUI;
    string ammotodis;
    string leftammotodis;
    int ammo;
    int leftammo;
    
    // Start is called before the first frame update
    void Start()
    {
        ammotodis = thisgun.ammo.ToString();
        ammo=thisgun.ammo;
        leftammotodis = thisgun.leftammo.ToString();
        leftammo=thisgun.leftammo;
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        ammotodis = thisgun.ammo.ToString();
        leftammotodis = thisgun.leftammo.ToString();
        ammo=thisgun.ammo;
        AmmoUI.text = ammotodis+ " / "+ leftammotodis;
        if (ammo<10) {
            AmmoUI.color=Color.red;
        } else {
            AmmoUI.color=Color.black;
        }
    }
}

    

