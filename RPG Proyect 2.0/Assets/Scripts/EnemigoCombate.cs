using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemigoCombate : MonoBehaviour
{
    public int vidaEnemigo;
    public Animator anim;
    public static int dañoRecibido = 15;
    public static int dañoRecibidoPC = 25;
    public static int dañoRecibidoLeg = 50;
    public static int dañoRecibidoPuño = 10;
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
            damageText.text = dañoRecibido.ToString();
            animacionTexto.Play(0);
            if (anim != null)
            {
                //anim.Play("ZombieRecibeGolpe");             
                vidaEnemigo -= EnemigoCombate.dañoRecibido;
                //damageText.SetActive(true);
                StartCoroutine(HideText());
                //StartCoroutine(healthDamage.Invulnerabilidad(0.3f));
                if (vidaEnemigo <= 0)
                {
                    lootableObject.RealizarLoot();
                    Destroy(gameObject);
                    Instantiate(deadEnemy, transform.position, transform.rotation);
                    //enemySpawner.SpawnEnemy();
                    //Añadir linea para animación del enemigo cuando la haya con un Coroutine para destruirse
                }
            }
        }
        else if (other.gameObject.tag == "EspadaPocoComun")
        {
            damageText.text = dañoRecibidoPC.ToString();
            animacionTexto.Play(0);
            vidaEnemigo -= EnemigoCombate.dañoRecibidoPC;
            //damageText.SetActive(true);
            StartCoroutine(HideText());
            if (vidaEnemigo <= 0)
            {
                lootableObject.RealizarLoot();
                Destroy(gameObject);
                Instantiate(deadEnemy, transform.position, transform.rotation);
                //enemySpawner.SpawnEnemy();
                //Añadir linea para animación del enemigo cuando la haya con un Coroutine para destruirse
            }
        }
        else if (other.gameObject.tag == "EspadaLegendaria")
        {
            damageText.text = dañoRecibidoLeg.ToString();
            animacionTexto.Play(0);
            vidaEnemigo -= EnemigoCombate.dañoRecibidoPC;
            //damageText.SetActive(true);
            StartCoroutine(HideText());
            if (vidaEnemigo <= 0)
            {
                lootableObject.RealizarLoot();
                Destroy(gameObject);
                Instantiate(deadEnemy, transform.position, transform.rotation);
                //enemySpawner.SpawnEnemy();
                //Añadir linea para animación del enemigo cuando la haya con un Coroutine para destruirse
            }
        }

        if (other.gameObject.tag == "Puño")
        {
            damageText.text = dañoRecibidoPuño.ToString();
            if (anim != null)
            {
                damageText.text = dañoRecibidoPuño.ToString();
                //anim.Play("ZombieRecibeGolpe");                
                animacionTexto.Play(0);                
                vidaEnemigo -= EnemigoCombate.dañoRecibidoPuño;
                StartCoroutine(HideText());
                //StartCoroutine(healthDamage.Invulnerabilidad(0.3f));
                if (vidaEnemigo <= 0)
                {
                    lootableObject.RealizarLoot();
                    Destroy(gameObject);
                    Instantiate(deadEnemy, transform.position, transform.rotation);
                    //enemySpawner.SpawnEnemy();
                    //Añadir linea para animación del enemigo cuando la haya con un Coroutine para destruirse
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
