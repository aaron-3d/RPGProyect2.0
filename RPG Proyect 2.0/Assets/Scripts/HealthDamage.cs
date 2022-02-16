using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthDamage : MonoBehaviour
{
    public int vidaP = 100;
    public bool invencible = false;

    public float tiempoInvencible = 1;
    public float tiempoFrenado = 0.2f;

    private Animator anim;

    public HealthBarSlider healthBarSlider;

    public GameObject deathOverlay;

    private void Start()
    {
        anim = GetComponent<Animator>();
        healthBarSlider.SetMaxHealth(vidaP);
        deathOverlay.SetActive(false);
    }

    public void QuitarVida(int cantidad)
    {
        if(!invencible && vidaP > 0)
        {
            vidaP -= cantidad;
            anim.Play("TakeDamage1");
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            healthBarSlider.SetHealth(vidaP);

            if (vidaP <= 0)
            {
                vidaP = 0;
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
            healthBarSlider.SetHealth(vidaP);
            if(vidaP > 100)
            {
                vidaP = 100;
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Has muerto.");
        deathOverlay.SetActive(true);
        //Freezear el juego
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        deathOverlay.SetActive(false);
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
        GetComponent<ThirdPersonMovement>().speed = 4;
        yield return new WaitForSeconds(tiempoFrenado);
        GetComponent<ThirdPersonMovement>().speed = velocidadActual;
    }

}
