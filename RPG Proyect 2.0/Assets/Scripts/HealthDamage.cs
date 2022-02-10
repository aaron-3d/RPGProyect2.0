using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamage : MonoBehaviour
{
    public int vidaP = 100;
    public bool invencible = false;

    public float tiempoInvencible = 1;
    public float tiempoFrenado = 0.2f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void QuitarVida(int cantidad)
    {
        if(!invencible && vidaP > 0)
        {
            vidaP -= cantidad;
            anim.Play("TakeDamage1");
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());

            if(vidaP == 0)
            {
                GameOver();
            }
        }
    }

    public void SumarVida(int cantidad)
    {
        if (vidaP > 0)
        {
            vidaP += cantidad;
            //anim.Play("TakeDamage1");
            //StartCoroutine(Invulnerabilidad());
            //StartCoroutine(FrenarVelocidad());
        }
    }

    void GameOver()
    {
        Debug.Log("Has muerto.");
    }

    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempoInvencible);
        invencible = false;
    }

    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<ThirdPersonMovement>().speed;
        GetComponent<ThirdPersonMovement>().speed = 0;
        yield return new WaitForSeconds(tiempoFrenado);
        GetComponent<ThirdPersonMovement>().speed = velocidadActual;
    }

}
