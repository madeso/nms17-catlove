using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPedestrian : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var rb = this.GetComponent<Rigidbody>();
		rb.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
