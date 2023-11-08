using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeline : MonoBehaviour
{
    public GameObject canvas;
    public PlayableDirector director;
   
    void Start()
    {
        canvas.SetActive(true);
        StartCoroutine(CanvasDisable());
        
    }

   IEnumerator CanvasDisable()
    {
        director.Play();

        yield return new WaitForSeconds(4.9f);
        canvas.SetActive(false);
    }
}
