using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topLeftButton : MonoBehaviour
{
    public GameObject infoPanel;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void showInfoPanel()
    {
        infoPanel.SetActive(true);
    }

    public void closeInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}
