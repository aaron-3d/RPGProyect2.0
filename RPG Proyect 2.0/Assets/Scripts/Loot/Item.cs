using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int cantidad = 1; //cantidad de cada objeto (20 pociones)
    public Text textoCantidad;
    public int ID;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoCantidad.text = cantidad.ToString();
    }
}
