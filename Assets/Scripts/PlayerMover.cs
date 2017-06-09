using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float speed = 10.0f;

	private Rigidbody rb;

	public Transform RotationRoot = null;
	public Wiggle wiggle;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		wiggle = GetComponentInChildren<Wiggle>();
	}

	void FixedUpdate ()
	{
		var theCamera = Camera.main;
		Vector3 movement = Input.GetAxis("Vertical") * theCamera.transform.forward + Input.GetAxis("Horizontal") * theCamera.transform.right;

		movement.y = 0.0f;

		bool move = false;

		if(movement.sqrMagnitude > 0.1f ) {
			move = true;
			movement.Normalize();
			rb.AddForce (movement * speed);

			Quaternion newRotation = Quaternion.LookRotation(movement);
			// this.rb.MoveRotation(newRotation);
			if(this.RotationRoot != null) {
				this.RotationRoot.rotation = newRotation;
			}
		}

		if(wiggle != null) {
			wiggle.IsWiggle = move;
		}

		var v = rb.velocity;
		if(v.sqrMagnitude > speed * speed ) {
			rb.velocity = v.normalized * speed;
		}
	}
}
