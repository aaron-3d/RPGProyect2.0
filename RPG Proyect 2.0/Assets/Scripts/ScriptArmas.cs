using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArmas : MonoBehaviour
{
    public BoxCollider[] armasCollider;
    public BoxCollider puñoCollider;


    public void Start()
    {
        DesactivarColliderArmas();
    }

    public void ActivarColliderArmas()
    {
        armasCollider[0].enabled = true;
    }

    public void DesactivarColliderArmas()
    {
        armasCollider[0].enabled = false;
    }
}
