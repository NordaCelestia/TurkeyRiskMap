using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topLeftButton : MonoBehaviour
{
    
    public Animator aniTop, aniBot;
    AudioSource ass;

    public void showInfoPanel()
    {
        aniBot.SetBool("highlight",true);
    }
    public void showInfoPanelTop()
    {
        aniTop.SetBool("highlight", true);
    }

    public void closeInfoPanel()
    {
        aniBot.SetBool("highlight", false);
    }
    public void closeInfoPanelTop()
    {
        aniTop.SetBool("highlight", false);
    }
}
