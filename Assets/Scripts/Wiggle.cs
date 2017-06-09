using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {
	public bool IsWiggle = false;
	public float WiggleTime = 0.1f;
	public float WiggleRange = 20.0f;

	public int state = 0;
	public float time = 0.0f;
	private bool lastwiggle = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(IsWiggle != lastwiggle) {
			if(IsWiggle) {
				state = Random.Range(0,2);
				if(state == 0) state = -1;
			}
			else {
				state = 0;
			}
			lastwiggle = IsWiggle;
		}

		if(state != 0 ) {
			time -= Time.deltaTime;
		}
		switch(state) {
		case 0:
			break;
		case -1:
		case 1:
			if(time < 0 ) {
				state = -state;
				time += WiggleTime;
			}
			break;
		}

		var w = state * WiggleRange;
		transform.localRotation = Quaternion.Euler(new Vector3(0, 0, w));
	}
}
