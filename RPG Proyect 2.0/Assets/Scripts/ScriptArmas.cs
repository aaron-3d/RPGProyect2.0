using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArmas : MonoBehaviour
{
    public BoxCollider[] armasCollider;
    public BoxCollider puņoCollider;
    public BoxCollider zombieFootCollider;

    public GameObject[] armas;
    public HealthDamage healthDamage;
    public EnemigoCombate enemigoCombate;

    public void Update()
    {
        /*if(armasCollider[0])
        {
            EnemigoCombate.daņoRecibido = 10;
        }
        else if (armasCollider[1])
        {
            EnemigoCombate.daņoRecibido = 25;
        }
        else if (armasCollider[2])
        {
            EnemigoCombate.daņoRecibido = 50;
        }*/
    }
    public void Start()
    {
        DesactivarColliderArmas();
        DesactivarColliderArmasZombie();
        zombieFootCollider.enabled = false;
        puņoCollider.enabled = false;
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
                puņoCollider.enabled = true;
                //zombieFootCollider.enabled = false;
            }
        }
    }

    public void DesactivarColliderArmas()
    {
        puņoCollider.enabled = false;

        for (int i = 0; i < armasCollider.Length; i++)
        {
            if (armasCollider[i] != null)
            {
                armasCollider[i].enabled = false;
            }
        }
        
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
