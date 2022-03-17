using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : Singleton<InstanceManager>
{
    [SerializeField]
    private Inventario Inv;

    public Inventario Inv1 { get => Inv; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
