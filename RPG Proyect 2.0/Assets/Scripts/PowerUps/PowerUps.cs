using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUps : MonoBehaviour
{
    public int cantidad = 15;
    public int cantidadSpeed = 6;

    private Animator anim;
    public AudioClip powerUpPopSound;
    public float volume;
    private AudioSource audio;
    public TextMeshProUGUI textoPowerUpVida;
    public static GameObject textoPowerUpVidaGO;

    public EnemigoCombate enemigoCombate;
    

    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }



    IEnumerator ShowMessage(string message, float delay)
    {
        textoPowerUpVida.text = message;
        textoPowerUpVida.enabled = true;
        yield return new WaitForSeconds(delay);
        textoPowerUpVida.enabled = false;        
    }

    IEnumerator Destroy(float delay)
    {       
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator PlaySound(float delay)
    {
        audio.PlayOneShot(powerUpPopSound, volume);
        yield return new WaitForSeconds(1);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.tag == "PowerUpVida")
            {
                //other.GetComponent<HealthDamage>().SumarVida(cantidad);
                other.GetComponent<HealthDamage>().vidaP += 15;

                StartCoroutine(ShowMessage("+15 HP", 2));
                gameObject.GetComponent<BoxCollider>().enabled = false;
                anim.Play("PowerUpShrink");
                audio.PlayOneShot(powerUpPopSound, volume);
                StartCoroutine(PlaySound(1));
                StartCoroutine(Destroy(2));
            }
            else if (gameObject.tag == "PowerUpSpeed")
            {            
                    other.GetComponent<CamaraTercera>().AddExtraSpeed(0.6f);
                    Debug.Log("Velocidad aumentada");
                    StartCoroutine(ShowMessage("¡Velocidad aumentada!", 2));
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    anim.Play("PowerUpShrink2");
                    audio.PlayOneShot(powerUpPopSound, volume);
                    StartCoroutine(PlaySound(1));
                    StartCoroutine(Destroy(2));             
            }
            else if (gameObject.tag == "PowerUpDamage")
            {
                enemigoCombate.dañoRecibido += 10;
                enemigoCombate.dañoRecibidoPuño += 5;
                Debug.Log("Daño aumentado(+x)");
                    StartCoroutine(ShowMessage("Daño aumentado", 2));
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    anim.Play("PowerUpShrink3");
                    audio.PlayOneShot(powerUpPopSound, volume);
                    StartCoroutine(PlaySound(1));
                    StartCoroutine(Destroy(2));            
            }
            else if (gameObject.tag == "PowerUpJump")
            {                
                    other.GetComponent<MovimientoPersonajeTercero>().AddExtraJump(1);
                    Debug.Log("Ahora puedes dar otro salto en el aire");
                    StartCoroutine(ShowMessage("Ahora puedes dar otro salto en el aire", 2));
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    anim.Play("PowerUpShrink4");
                    audio.PlayOneShot(powerUpPopSound, volume);
                    StartCoroutine(PlaySound(1));
                    StartCoroutine(Destroy(2));              
            }
        }
    }
}
