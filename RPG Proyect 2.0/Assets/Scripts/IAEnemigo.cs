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
    public float distanciaAtaque;
    public float distance;

    public bool hasAttacked = false;
    public float timer;
    public Animator _animator;
    


    public void Update()
    {
        if (Vector3.Distance(Target.transform.position, transform.position) < distance)
        {
            agent.SetDestination(Target.transform.position);
            agent.speed = 10;
            _animator.SetBool("isChasing", true);
            _animator.SetBool("isAlone", false);
        }
        else
        {
            agent.speed = 0;
            _animator.SetBool("isChasing", false);
            _animator.SetBool("isAlone", true);
            //_animator.SetBool("isClose", false); // Esto hay que encajarlo en otra parte o el mob solo pega una vez cuando te empieza a perseguir
        }

        if (Vector3.Distance(Target.transform.position, transform.position) <= distanciaAtaque)
        {           
            _animator.SetBool("isClose", true);
            _animator.SetBool("isChasing", false);
            hasAttacked = true;
            agent.speed = 2;
            //Target.GetComponent<HealthDamage>().QuitarVida(cantidad);
            //

        }
        else
        {
            _animator.SetBool("isClose", false);
            agent.speed = 10;
        }
    }
}
