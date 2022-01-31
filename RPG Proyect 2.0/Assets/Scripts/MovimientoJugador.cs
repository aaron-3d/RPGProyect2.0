using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

	private Rigidbody rb;

	[Range(1, 10)]
	public float velocidad = 5;

	[Range(1, 10)]
	public float salto = 7;

	public float rotationSpeed;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{

		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");

		//Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
		Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);

		//Aplico ese movimiento al RigidBody del jugador
		rb.AddForce(movimiento);
		if(movimiento != Vector3.zero)
        {
			Quaternion toRotation = Quaternion.LookRotation(movimiento, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
			
			//transform.forward = movimiento;
        }

		if (Input.GetButton("Jump") && isGrounded())
		{
			//Aplico el movimiento vertical con la potencia de salto
			rb.velocity += Vector3.up * salto;
		}

	}
	private bool isGrounded()
	{

		//Genero el array de colisiones de la esfera/jugador pasando su centro y su radio
		Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
		//Recorro ese array y si está colisionando con el suelo devuelvo true
		foreach (Collider colision in colisiones)
		{
			if (colision.tag == "Ground")
			{
				return true;
			}
		}
		return false;

	}
}