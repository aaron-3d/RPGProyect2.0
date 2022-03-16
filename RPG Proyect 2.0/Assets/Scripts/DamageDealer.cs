using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageDealer : MonoBehaviour
{
    public int cantidad = 10;
    public TextMeshProUGUI damageTextEnemyToPlayer;
    public Animator animacionTextoTwo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HealthDamage>().QuitarVida(cantidad);
        }

        if (gameObject.tag == "Espada")
        {
            Debug.Log("Daño de Espada");
            other.GetComponent<HealthDamage>().QuitarVidaEnemigo(cantidad);
            Debug.Log("Enemigo ha perdido vida");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.GetComponent<HealthDamage>().QuitarVida(cantidad);
            animacionTextoTwo.Play(0);
            damageTextEnemyToPlayer.text = "-" + cantidad.ToString();
            StartCoroutine(HideTextTwo());
        }
    }

    IEnumerator HideTextTwo()
    {
        yield return new WaitForSeconds(1.5f);
        //damageText.SetActive(false);
        damageTextEnemyToPlayer.text = " ";
    }
}
