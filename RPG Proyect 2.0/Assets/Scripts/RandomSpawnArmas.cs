using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnArmas : MonoBehaviour
{
    public GameObject[] spawnPoints;
    




    // Start is called before the first frame update
    void Start()
    {
        int roll = Random.Range(1, 4);
        Debug.Log(roll);

        if(roll == 1)
        {
            gameObject.transform.position = spawnPoints[0].transform.position;
        }
        if (roll == 2)
        {
            gameObject.transform.position = spawnPoints[1].transform.position;
        }
        if (roll == 3)
        {
            gameObject.transform.position = spawnPoints[2].transform.position;
        }



        //spawnPoints[].index = roll;
        //gameObject.transform.position = spawnPoints[roll].transform.position;
        //transform.location = spawnPoints[];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
