using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;


    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Animator animator;
    public Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = false;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Debug.Log("Speed " + direction.magnitude);
        animator.SetFloat("Speed", direction.magnitude);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetTrigger("Punch");
           // animator.ResetTrigger("Punch");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            // animator.ResetTrigger("Punch");
        }




    }
    public void SumarSpeed(int cantidadSpeed)
    {
            speed += cantidadSpeed;
    }
}
