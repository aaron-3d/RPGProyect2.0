using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemigoCombate : MonoBehaviour
{
    public int vidaEnemigo;
    public Animator anim;
    public static int da�oRecibido = 15;
    public static int da�oRecibidoPC = 25;
    public static int da�oRecibidoLeg = 50;
    public static int da�oRecibidoPu�o = 10;
    private LootableObject lootableObject;
    public TextMeshProUGUI damageText;
    public Animator animacionTexto;

    public GameObject deadEnemy;

    //public EnemySpawner enemySpawner;
    //public bool invencible = false;
    


    //public HealthDamage healthDamage;


    // Start is called before the first frame update
    void Start()
    {
        lootableObject = GetComponent<LootableObject>();
        //damageText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Espada")
        {
            damageText.text = da�oRecibido.ToString();
            animacionTexto.Play(0);
            if (anim != null)
            {
                //anim.Play("ZombieRecibeGolpe");             
                vidaEnemigo -= EnemigoCombate.da�oRecibido;
                //damageText.SetActive(true);
                StartCoroutine(HideText());
                //StartCoroutine(healthDamage.Invulnerabilidad(0.3f));
                if (vidaEnemigo <= 0)
                {
                    lootableObject.RealizarLoot();
                    Destroy(gameObject);
                    Instantiate(deadEnemy, transform.position, transform.rotation);
                    //enemySpawner.SpawnEnemy();
                    //A�adir linea para animaci�n del enemigo cuando la haya con un Coroutine para destruirse
                }
            }
        }
        else if (other.gameObject.tag == "EspadaPocoComun")
        {
            damageText.text = da�oRecibidoPC.ToString();
            animacionTexto.Play(0);
            vidaEnemigo -= EnemigoCombate.da�oRecibidoPC;
            //damageText.SetActive(true);
            StartCoroutine(HideText());
            if (vidaEnemigo <= 0)
            {
                lootableObject.RealizarLoot();
                Destroy(gameObject);
                Instantiate(deadEnemy, transform.position, transform.rotation);
                //enemySpawner.SpawnEnemy();
                //A�adir linea para animaci�n del enemigo cuando la haya con un Coroutine para destruirse
            }
        }
        else if (other.gameObject.tag == "EspadaLegendaria")
        {
            damageText.text = da�oRecibidoLeg.ToString();
            animacionTexto.Play(0);
            vidaEnemigo -= EnemigoCombate.da�oRecibidoPC;
            //damageText.SetActive(true);
            StartCoroutine(HideText());
            if (vidaEnemigo <= 0)
            {
                lootableObject.RealizarLoot();
                Destroy(gameObject);
                Instantiate(deadEnemy, transform.position, transform.rotation);
                //enemySpawner.SpawnEnemy();
                //A�adir linea para animaci�n del enemigo cuando la haya con un Coroutine para destruirse
            }
        }

        if (other.gameObject.tag == "Pu�o")
        {
            damageText.text = da�oRecibidoPu�o.ToString();
            if (anim != null)
            {
                damageText.text = da�oRecibidoPu�o.ToString();
                //anim.Play("ZombieRecibeGolpe");                
                animacionTexto.Play(0);                
                vidaEnemigo -= EnemigoCombate.da�oRecibidoPu�o;
                StartCoroutine(HideText());
                //StartCoroutine(healthDamage.Invulnerabilidad(0.3f));
                if (vidaEnemigo <= 0)
                {
                    lootableObject.RealizarLoot();
                    Destroy(gameObject);
                    Instantiate(deadEnemy, transform.position, transform.rotation);
                    //enemySpawner.SpawnEnemy();
                    //A�adir linea para animaci�n del enemigo cuando la haya con un Coroutine para destruirse
                }
            }
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(1.5f);
        //damageText.SetActive(false);
        damageText.text = " ";
    }
}
