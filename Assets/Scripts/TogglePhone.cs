﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePhone : MonoBehaviour {
	public RectTransform phone;
	enum State {
		Down, GoingUp, GoingDown, Up
	}

	public float Distance = 100;
	public float TotalTime = 0.5f;

	public float timer = 0.0f;
	State state = State.Down;
	public float from = 0.0f;

	public float y = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			state = GetNextState();
			timer = 0.0f;
			from = phone.localPosition.y;
		}

		y = 0.0f;
		switch(state) {
		case State.Down:
			y = Distance;
			break;
		case State.GoingDown:
			y = InterpolateFromTarget(Distance);
			if(timer > 1 ) state = State.Down;
			break;
		case State.GoingUp:
			y = InterpolateFromTarget(0);
			if(timer > 1 ) state = State.Up;
			break;
		case State.Up:
			y = 0;
			break;
		}
		var p = phone.localPosition;
		p.y = y;
		phone.localPosition = p;
	}

	float InterpolateFromTarget(float t) {
		timer += Time.deltaTime / TotalTime;
		return Mathf.Lerp(from, t, timer);
	}

	private State GetNextState() {
		switch(state) {
		case State.Down:
			return State.GoingUp;
		case State.GoingDown:
			return State.GoingUp;
		case State.GoingUp:
			return State.GoingDown;
		case State.Up:
			return State.GoingDown;
		default:
			return State.Down;
		}
	}
}
