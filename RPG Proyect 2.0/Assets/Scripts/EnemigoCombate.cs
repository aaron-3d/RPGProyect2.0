using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCombate : MonoBehaviour
{
    public int vidaEnemigo;
    public Animator anim;
    public int dañoRecibido = 10;



   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Consola");
    }

    // Update is called once per frame
    void Update()
    {

    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Espada")
        {
            Debug.Log("Se produce un choque entre el enemigo y la espada.");
            if (anim != null)
            {
                anim.Play("EsqueletoRecibeGolpe");             
                Debug.Log("Se produce la animación.");
                vidaEnemigo -= dañoRecibido;
                if(vidaEnemigo <= 0)
                {
                    Destroy(gameObject);
                    //Añadir linea para animación del enemigo cuando la haya con un Coroutine para destruirse
                }
            }
        }
    }
}
