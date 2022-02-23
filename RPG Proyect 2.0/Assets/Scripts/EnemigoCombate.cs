using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCombate : MonoBehaviour
{
    public int vidaEnemigo;
    public Animator anim;
    public int da�oRecibido = 25;
    public int da�oRecibidoPu�o = 10;
    //public bool invencible = false;


    //public HealthDamage healthDamage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

        private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Espada")
        {
            if (anim != null)
            {
                anim.Play("ZombieRecibeGolpe");             
                vidaEnemigo -= da�oRecibido;
                //StartCoroutine(healthDamage.Invulnerabilidad(0.3f));
                if (vidaEnemigo <= 0)
                {
                    Destroy(gameObject);
                    //A�adir linea para animaci�n del enemigo cuando la haya con un Coroutine para destruirse
                }
            }
        }

        if (other.gameObject.tag == "Pu�o")
        {
            if (anim != null)
            {
                anim.Play("ZombieRecibeGolpe");
                vidaEnemigo -= da�oRecibidoPu�o;
                //StartCoroutine(healthDamage.Invulnerabilidad(0.3f));
                if (vidaEnemigo <= 0)
                {
                    Destroy(gameObject);
                    //A�adir linea para animaci�n del enemigo cuando la haya con un Coroutine para destruirse
                }
            }
        }
    }
}
