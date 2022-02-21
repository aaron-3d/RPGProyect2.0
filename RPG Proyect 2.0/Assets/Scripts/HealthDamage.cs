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

    public CamaraTercera camaraTercera;

    private Animator anim;

    public HealthBarSlider healthBarSlider;

    public GameObject deathOverlay;
    
    [SerializeField]
    public bool isPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        healthBarSlider.SetMaxHealth(vidaP);
        deathOverlay.SetActive(false);
        Time.timeScale = 1;
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
        Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            GameOver();
        }
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
        var velocidadActual = GetComponent<CamaraTercera>().speed;
        GetComponent<CamaraTercera>().speed = 0.02f;
        yield return new WaitForSeconds(tiempoFrenado);
        GetComponent<CamaraTercera>().speed = velocidadActual;
    }
}
