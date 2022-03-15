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

    public GameObject espadaComun;
    public GameObject espadaPocoComun;
    public GameObject espadaLegendaria;

    public EnemigoCombate enemigoCombate;
    public MovimientoPersonajeTercero movimientoPersonajeTercero;

    //public GameObject player;
    

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
                    other.GetComponent<CamaraTercera>().AddExtraSpeed(0.06f);
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
                EnemigoCombate.dañoRecibidoPuño += 3;
                EnemigoCombate.dañoRecibido += 5;
                EnemigoCombate.dañoRecibidoPC += 7;
                EnemigoCombate.dañoRecibidoLeg += 10;
                //enemigoCombate.dañoRecibido += 10;
                //enemigoCombate.dañoRecibidoPuño += 5;
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
            else if (gameObject.tag == "PiedraPowerUp")
            {
                other.GetComponent<CamaraTercera>().ReduceSpeed(0.25f);
                EnemigoCombate.dañoRecibidoPuño += 150;
                EnemigoCombate.dañoRecibido += 15;
                EnemigoCombate.dañoRecibidoPC += 17;
                EnemigoCombate.dañoRecibidoLeg += 25;

                StartCoroutine(ShowMessage("¿?", 2));
                StartCoroutine(Destroy(2));
                gameObject.GetComponent<BoxCollider>().enabled = false;
                anim.Play("PowerUpShrink5");
                audio.PlayOneShot(powerUpPopSound, volume);
                StartCoroutine(PlaySound(1));
                
            }
            else if (gameObject.tag == "EspadaComunPowerUp" && (movimientoPersonajeTercero.arma == null))
            {
                movimientoPersonajeTercero.arma = espadaComun;
                StartCoroutine(Destroy(0));
            }
            else if (gameObject.tag == "EspadaPocoComunPowerUp" && (movimientoPersonajeTercero.arma == espadaComun || movimientoPersonajeTercero.arma == null))
            {
                movimientoPersonajeTercero.arma = espadaPocoComun;
                StartCoroutine(Destroy(0));
            }
            else if (gameObject.tag == "EspadaLegendariaPowerUp" && (movimientoPersonajeTercero.arma == espadaComun || movimientoPersonajeTercero.arma == espadaPocoComun || movimientoPersonajeTercero.arma == null))
            {
                movimientoPersonajeTercero.arma = espadaLegendaria;
                StartCoroutine(Destroy(0));
            }
        }
    }
}
