using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoPersonajeTercero : MonoBehaviour
{
    private Animator _animator;
    private CamaraTercera _movement;
    
    public Rigidbody rb;

    public float jumpForce = 3.2f;
    public Vector3 jump;
    public float availableJumps = 1;
    public float usedJumps = 0;

    public int cantidadSaltos = 1;

    public HealthDamage healthDamage;


    private Vector2 smoothDeltaPosition = Vector2.zero;
    public Vector2 velocity = Vector2.zero;
    public float magnitude = 0.25f;
    public float currentSpeed;


    public void Start()
    {
        jump = new Vector3(0.0f, 3.2f, 0.0f);
    }

    private void OnEnable()
    {
        _movement = GetComponent<CamaraTercera>();
        _animator = GetComponent<Animator>();
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Vector3 worldDeltaPosition = _movement.nextPosition- transform.position;
        

        //Map to local space
        float dX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dX, dY);

        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        if (Time.deltaTime > 1e-5f)
        {
            velocity = smoothDeltaPosition / Time.deltaTime;
            
        }
        
        //Debug.Log("Speed " + direction.magnitude);
        _animator.SetFloat("Speed", _movement._move.magnitude);

        if(_movement._move.magnitude >= 0.01f)
        {
            _animator.SetBool("Semueve", true);
        }
        else
        {
            _animator.SetBool("Semueve", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(WaitForJump(1));
            if (usedJumps == 0)
            {
                rb.AddForce(jump * jumpForce, 0);
                _animator.SetBool("Salta", true);
                print("Se pone true");
                usedJumps += 1;
            }

            else if (availableJumps > usedJumps)
            {
                rb.AddForce(jump * jumpForce, 0);
                //_animator.SetBool("Salta", true);
                print("Se pone true");
                usedJumps += 1;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("Salta", false);
            print("Se pone false");
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(healthDamage.conArma == true)
            {
                _animator.SetBool("conArma", true);
                // animator.ResetTrigger("Punch");
            }
            else
            {
                _animator.SetBool("Pu�etazo", true);
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var velocidadActual = GetComponent<CamaraTercera>().speed;
            currentSpeed = velocidadActual;
            _movement.speed = velocidadActual/2;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            print("se suelta la s");
            _movement.speed = currentSpeed;
        }

        if (Input.GetMouseButtonUp(0))
            if (healthDamage.conArma == true)
            {
                _animator.SetBool("conArma", false);
                // animator.ResetTrigger("Punch");
            }
            else
            {
                _animator.SetBool("Pu�etazo", false);
            }
    }

    public void AddExtraJump(int cantidadSaltos)
    {
        availableJumps += cantidadSaltos;
    }


    public void OnCollisionEnter(Collision col)
    {
        {
            usedJumps = 0;
        }
    }
    private void OnAnimatorMove()
    {
        //Update the position based on the next position;
        transform.position = _movement.nextPosition;
    }
    IEnumerator WaitForJump(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}