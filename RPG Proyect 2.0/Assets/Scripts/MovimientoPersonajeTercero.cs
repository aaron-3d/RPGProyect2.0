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



    private Vector2 smoothDeltaPosition = Vector2.zero;
    public Vector2 velocity = Vector2.zero;
    public float magnitude = 0.25f;

    public void Start()
    {
        jump = new Vector3(0.0f, 3.2f, 0.0f);
    }

    private void OnEnable()
    {
        _movement = GetComponent<CamaraTercera>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
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

        if(Input.GetKeyDown(KeyCode.Space))
        {                  
            if(availableJumps > usedJumps)
            {
                rb.AddForce(jump * jumpForce, 0);
                usedJumps += 1;
            }
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
}