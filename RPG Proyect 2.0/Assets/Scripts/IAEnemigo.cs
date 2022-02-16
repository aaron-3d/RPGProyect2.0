using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{
    public GameObject Target;
    public NavMeshAgent agent;
    public HealthDamage healthDamage;
    public int cantidad = 1;
    public float distance;
    public void Update()
    {
        if (Vector3.Distance(Target.transform.position, transform.position)< distance)
        {
            agent.SetDestination(Target.transform.position);
            agent.speed = 10;

        }
        else
        {
            agent.speed = 0;
        }

        if (Vector3.Distance(Target.transform.position, transform.position) <= 10)
        {
           Target.GetComponent<HealthDamage>().QuitarVida(canti dad);
        }
    }
}
