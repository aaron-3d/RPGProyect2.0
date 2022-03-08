using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObject : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private int factorAdicional = 1;
    [SerializeField]
    private int cantDropMax = 1;
    [Range(0,100)]
    [SerializeField]
    private int posibilidadDeDrop;
    void Start()
    {
        if(spawnPoint == null)
        {
            spawnPoint = transform;
        }
        
    }

    public void RealizarLoot()
    {
        LootSystem.Instance.SpawnLoot(spawnPoint, factorAdicional, cantDropMax, posibilidadDeDrop);
    }

}
