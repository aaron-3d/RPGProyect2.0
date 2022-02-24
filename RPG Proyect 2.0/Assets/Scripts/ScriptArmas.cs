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
                puņoCollider.enabled = true;
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
        puņoCollider.enabled = false;
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
