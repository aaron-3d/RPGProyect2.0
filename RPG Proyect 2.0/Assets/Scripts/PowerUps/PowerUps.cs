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
                Debug.Log("Vida aumentada (+15)");
            }
        }
        else if (gameObject.tag == "PowerUpSpeed")
        {
            if (other.tag == "Player") ;
            {
                other.GetComponent<CamaraTercera>().AddExtraSpeed(0.1f);
                Destroy(gameObject);
                Debug.Log("Velocidad aumentada");
            }
        }
        else if (gameObject.tag == "PowerUpDamage")
        {
            if (other.tag == "Player") ;
            {
                //other.GetComponent<HealthDamage>().SumarSpeed(cantidadSpeed);
                Destroy(gameObject);
                Debug.Log("Daño aumentado(+x)");
            }

        }
        else if (gameObject.tag == "PowerUpJump")
        {
            if (other.tag == "Player");
            {
                other.GetComponent<MovimientoPersonajeTercero>().AddExtraJump(1);
                Destroy(gameObject);
                Debug.Log("Ahora puedes dar otro salto en el aire");
            }
        }
    }
}
