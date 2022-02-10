using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int cantidad = 15;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player");
        {
            other.GetComponent<HealthDamage>().SumarVida(cantidad);
            Destroy(gameObject);
        }
    }
}
