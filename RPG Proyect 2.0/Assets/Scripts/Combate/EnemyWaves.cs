using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject enemyList;
    public GameObject enemyListTwo;
    public GameObject enemyListThree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.transform.childCount == 0)
        {
            enemyListTwo.SetActive(true);
        }
        if (enemyListTwo.transform.childCount == 0)
        {
            enemyListThree.SetActive(true);
        }
    }
}
