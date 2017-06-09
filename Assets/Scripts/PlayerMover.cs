using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float speed = 10.0f;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		var theCamera = Camera.main;
		Vector3 movement = Input.GetAxis("Vertical") * theCamera.transform.forward + Input.GetAxis("Horizontal") * theCamera.transform.right;

		if(movement.sqrMagnitude > 0.1f ) {
			movement.Normalize();
			rb.AddForce (movement * speed);
		}

		var v = rb.velocity;
		if(v.sqrMagnitude > speed * speed ) {
			rb.velocity = v.normalized * speed;
		}
	}
}
