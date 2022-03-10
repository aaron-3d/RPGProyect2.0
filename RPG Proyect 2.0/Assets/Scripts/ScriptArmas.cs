using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArmas : MonoBehaviour
{
    public BoxCollider[] armasCollider;
    public BoxCollider puñoCollider;
    public BoxCollider zombieFootCollider;

    public GameObject[] armas;
    public HealthDamage healthDamage;
    public EnemigoCombate enemigoCombate;

    public void Update()
    {
        /*if(armasCollider[0])
        {
            EnemigoCombate.dañoRecibido = 10;
        }
        else if (armasCollider[1])
        {
            EnemigoCombate.dañoRecibido = 25;
        }
        else if (armasCollider[2])
        {
            EnemigoCombate.dañoRecibido = 50;
        }*/
    }
    public void Start()
    {
        DesactivarColliderArmas();
        DesactivarColliderArmasZombie();
        zombieFootCollider.enabled = false;
    }

    public void ActivarColliderArmas()
    {
        for (int i = 0; i < armasCollider.Length; i++)
        {
            if (healthDamage.conArma)
            {
                if (armasCollider[i] != null)
                {
                    armasCollider[i].enabled = true;
                }
            }
            else
            {
                puñoCollider.enabled = true;
                //zombieFootCollider.enabled = false;
            }
        }
    }

    public void DesactivarColliderArmas()
    {
        for (int i = 0; i < armasCollider.Length; i++)
        {
            if (armasCollider[i] != null)
            {
                armasCollider[i].enabled = false;
            }
        }
        puñoCollider.enabled = false;
        //zombieFootCollider.enabled = false;
    }
    public void ActivarColliderArmasZombie()
    {
        zombieFootCollider.enabled = true;
    }

    public void DesactivarColliderArmasZombie()
    {
        zombieFootCollider.enabled = false;
    }

}
