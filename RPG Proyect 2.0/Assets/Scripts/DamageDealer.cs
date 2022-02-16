using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int cantidad = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HealthDamage>().QuitarVida(cantidad);
        }

        if (gameObject.tag == "Espada")
        {
            Debug.Log("Espada daño");
            other.GetComponent<HealthDamage>().QuitarVida(cantidad);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HealthDamage>().QuitarVida(cantidad);
        }
    }
}
