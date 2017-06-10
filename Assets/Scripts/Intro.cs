using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {
	public Text[] TextFades;
	public Image Background;
	public float FadeTime;
	public GameObject Root;

	float timer = 0;
	int index = 0;
	bool done = false;

	// Use this for initialization
	void Start () {
		Root.SetActive(true);
		foreach(var t in TextFades) {
			t.color = SetAlpha(0, t.color);
		}
	}

	static Color SetAlpha(float alpha, Color c) {
		return new Color(c.r, c.g, c.b, alpha);
	}
	
	// Update is called once per frame
	void Update () {
		if(done) return;

		timer += Time.deltaTime;
		var alpha = timer / FadeTime;
		if(alpha > 1.0f) alpha = 1.0f;

		if(TextFades.Length<=index) {
			foreach(var t in TextFades) {
				t.color = SetAlpha(1-alpha, t.color);
			}
			Background.color = SetAlpha(1-alpha, Background.color);
		}
		else {
			var t = TextFades[index];
			t.color = SetAlpha(alpha, t.color);
		}

		if(timer > FadeTime) {
			if(index >= TextFades.Length) {
				done = true;
				Root.SetActive(false);
			}
			timer -= FadeTime;
			index += 1;
		}
	}
}
