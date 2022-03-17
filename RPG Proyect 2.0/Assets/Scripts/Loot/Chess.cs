using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    Animator anim;
    private LootableObject lb;
    bool looteable = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        lb = GetComponent<LootableObject>();
    }

    /*public IEnumerator Opening()
    {
        //anim.SetBool()
    }*/
}
