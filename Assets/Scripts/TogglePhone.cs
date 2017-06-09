using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePhone : MonoBehaviour {
	GameObject dogr;
	bool status = false;

	// Use this for initialization
	void Start () {
		this.dogr = GameObject.Find("DogR");
		this.dogr.SetActive(status);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			status = !status;
			this.dogr.SetActive(status);
		}
	}
}
