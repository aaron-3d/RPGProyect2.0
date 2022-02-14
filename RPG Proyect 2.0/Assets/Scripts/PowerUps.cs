using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int cantidad = 15;
    public int cantidadSpeed = 6;

    public void OnTriggerEnter(Collider other)
    {
        if (this.tag == "PowerUpVida")
        {
            if (other.tag == "Player") ;
            {
                other.GetComponent<HealthDamage>().SumarVida(cantidad);
                Destroy(gameObject);
                Debug.Log("+15 vida");
            }
        }
        else if(gameObject.tag == "PowerUpSpeed")
        {
            if (other.tag == "Player") ;
            {
                other.GetComponent<ThirdPersonMovement>().SumarSpeed(cantidadSpeed);
                Destroy(gameObject);
                Debug.Log("Velocidad aumentada(+6)");
            }
        }
    }
}
