using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthDamage : MonoBehaviour
{
    public int vidaP = 100;
    public int maxHealth;
    public bool invencible = false;

    public float tiempoInvencible = 1;
    //public float tiempoFrenado = 0.2f;

    public CamaraTercera camaraTercera;

    private Animator anim;

    public HealthBarSlider healthBarSlider;
    public EnemigoCombate enemigoCombate;

    public GameObject deathOverlay;
    
    [SerializeField]
    public bool isPlayer;
    [SerializeField]
    public bool conArma = false;

    public float velocidadMaxima = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        healthBarSlider.SetMaxHealth(vidaP);
        deathOverlay.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update()
    {

        if(vidaP > maxHealth)
        {
            healthBarSlider.SetMaxHealth(vidaP);
            maxHealth = vidaP;
        }
    }

    public void QuitarVida(int cantidad)
    {
        if(!invencible && vidaP > 0)
        {
            vidaP -= cantidad;
            anim.Play("TakeDamage1");
            StartCoroutine(Invulnerabilidad(1f));
            StartCoroutine(FrenarVelocidad(0.2f));
            healthBarSlider.SetHealth(vidaP);

            if (vidaP <= 0)
            {
                vidaP = 0;
                GameOver();
            }
        }
    }

    public void QuitarVidaEnemigo(int cantidad)
    {
        enemigoCombate.vidaEnemigo -= cantidad;
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
            /*if(vidaP > 100)
            {
                vidaP = 100;
            }*/
        }
    }

    public void GameOver()
    {
        Debug.Log("Has muerto.");
        deathOverlay.SetActive(true);
        //anim.SetBool("Estamuerto", true);
        //anim.SetTrigger("Estamuerto");
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
        Debug.Log("Deberia recargarse la escena");
        SceneManager.LoadScene("CopiaEscenaPrincipal");
        EnemigoCombate.dañoRecibido = 15;
        EnemigoCombate.dañoRecibidoPC = 25;
        EnemigoCombate.dañoRecibidoLeg = 50;
        EnemigoCombate.dañoRecibidoPuño = 10;
        //Debug.Log("Deberia recargarse el juego");
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
        //anim.SetBool("Estamuerto", false);
        deathOverlay.SetActive(false);
    }

    public IEnumerator Invulnerabilidad(float tiempoInvencible)
    {
        invencible = true;
        yield return new WaitForSeconds(tiempoInvencible);
        invencible = false;
    }

    public IEnumerator FrenarVelocidad(float tiempoFrenado)
    {
        var velocidadActual = GetComponent<CamaraTercera>().speed;
        if (velocidadActual > velocidadMaxima)
        {
            velocidadMaxima = velocidadActual;
        }
        GetComponent<CamaraTercera>().speed = 0.02f;
        yield return new WaitForSeconds(tiempoFrenado);
        GetComponent<CamaraTercera>().speed = velocidadMaxima;
    }
}
