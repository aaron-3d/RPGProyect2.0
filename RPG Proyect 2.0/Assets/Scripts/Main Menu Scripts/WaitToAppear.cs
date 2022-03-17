using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToAppear : MonoBehaviour
{

    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject gameTitle;

    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        StartCoroutine(ShowTitle());
        StartCoroutine(ShowElements());        
    }

    IEnumerator ShowElements()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        playButton.SetActive(true);
        optionsButton.SetActive(true);
    }

    IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(4);
        gameTitle.SetActive(true);
    }
}
