using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; //If you need this, use it
    private Vector3 _randomPosition;
    public bool _canInstantiate;
    public GameObject player;


    private void Awake()
    {
        SetRanges();
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);

    }
    private void Start()
    {      
        player.transform.position = _randomPosition;
    }
    private void Update()
    {

    }

    //Here put the ranges where your object will appear, or put it in the inspector.
    private void SetRanges()
    {
        Min = new Vector3(30, 35, 498); //Random value.
        Max = new Vector3(346, 35, 739); //Another ramdon value, just for the example.          
        
    }

    private void InstantiateRandomObjects()
    {
        if (_canInstantiate)
        {
            Instantiate(gameObject, _randomPosition, Quaternion.identity);
        }

    }
}
