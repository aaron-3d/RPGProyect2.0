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

    public IEnumerator Opening()
    {
        anim.SetBool("Abierto", true);
        yield return new WaitForSeconds(1.5f);
        lb.RealizarLoot();
        looteable = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && looteable == true)
        {
            looteable = false;
            StartCoroutine(Opening());
        }
    }
}
