using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArmas : MonoBehaviour
{
    public BoxCollider[] armasCollider;
    public BoxCollider puņoCollider;

    public GameObject[] armas;
    public HealthDamage healthDamage;

    public void Start()
    {
        DesactivarColliderArmas();
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
    }

}
