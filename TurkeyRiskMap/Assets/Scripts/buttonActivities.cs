using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class buttonActivites : MonoBehaviour
{
    
    public GameObject canvas, inspector;
    public TMP_Text pName, pInfo, IText, IRain, IDisaster,ISoil;
    string tagControl;

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }



    //-------------------------------------------------------------------------------SWITCH CASE
    public void openCanvas()
    {

        tagControl = this.gameObject.tag;

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

        yield return new WaitForSeconds(0.3f);
        switch (this.gameObject.tag)
        {
            case "Ankara":


                IText.text = "Ankara";
                IRain.text = "%38";
                ISoil.text = "Kuru toprak";
                IDisaster.text = "Deprem";

                inspector.SetActive(true);

                break;

            case "Adana":

                IText.text = "Adana";
                IRain.text = "%21";
                ISoil.text = "Kuru toprak";
                IDisaster.text = "Yang�n";

                inspector.SetActive(true);

                break;

                

            case "Ad�yaman":

                IText.text = "Ad�yaman";
                IRain.text = "%37";
                ISoil.text = "Bol mineralli toprak";
                IDisaster.text = "Deprem";

                inspector.SetActive(true);

                break;

                
            default:
                Debug.Log("Nothing");
                break;


        }
    }
}
