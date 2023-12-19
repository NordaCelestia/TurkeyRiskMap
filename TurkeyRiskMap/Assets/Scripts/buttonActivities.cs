using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class buttonActivites : MonoBehaviour
{
    
    public GameObject canvas, inspector;
    public TMP_Text pName, pInfo, IText, IRain, IDisaster,ISoil;
    string[] controlArray = new string[81];

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;

        

        for (int i = 0; i < 81; i++)
        {
            controlArray[i] = (i + 1).ToString();
        }
        
        
    }

    

    //-------------------------------------------------------------------------------SWITCH CASE
    public void openCanvas()
    {

        
        
    }

    public void onMouseEnter()
    {
        StartCoroutine(mouseEnter());
        
    }

    public void onMouseExit()
    {
        inspector.SetActive(false);
        StopAllCoroutines();
    }

    public void closeCanvas()
    {
        canvas.SetActive(false);
    }

    IEnumerator mouseEnter()
    {

        for (int i = 0; i < controlArray.Length; i++)
        {
            if (this.gameObject.tag == controlArray[i])
            {
                pName.text = 
            }
        }
        yield return new WaitForSeconds(0.3f);
        
    }
}
