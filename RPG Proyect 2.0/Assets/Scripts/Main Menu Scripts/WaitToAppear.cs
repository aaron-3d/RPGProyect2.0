using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToAppear : MonoBehaviour
{

    public GameObject playButton;
    public GameObject optionsButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        StartCoroutine(ShowElements());
    }

    IEnumerator ShowElements()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        playButton.SetActive(true);
        optionsButton.SetActive(true);
    }
}
