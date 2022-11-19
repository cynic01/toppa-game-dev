using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillMsg : MonoBehaviour
{
    public Text hintText;
    private string hintmsg = "Slained: ";
    private float nextShowTime;
    
    void Start()
    {
        hintText.enabled = false;
        float nextShowTime = 0f;
    }

    // Update is called once per frame
    public void ShowMsg(string SlainedName) 
    {
        hintmsg += SlainedName;
        DisplayMsg();
    }

    private void DisplayMsg()
    {
        hintText.enabled = true;
        hintText.text = hintmsg;
        hintText.CrossFadeAlpha(1, 0.2f, false);
        
        Invoke("HideMsg", 3);
    }

    private void HideMsg()
    {
        hintText.CrossFadeAlpha(0, 0.2f, false);
        //hintText.enabled = false;
        hintmsg = "Slained: ";
    }

}
