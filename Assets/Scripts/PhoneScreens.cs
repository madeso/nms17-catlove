using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScreens : MonoBehaviour {
	public GameObject LikeDislike;
	public GameObject Messages;

	DogrProfile profile;

	// Use this for initialization
	void Start () {
		this.profile = this.GetComponent<DogrProfile>();
		this.SelectScreen(this.LikeDislike);
	}

	public void GoBack() {
		if(isActive(this.LikeDislike) ) {
			// go to main app
		}
		else if(isActive(this.Messages) ) {
			profile.GenerateNewProfile();
			SelectScreen(this.LikeDislike);
		}
		else {
			print("fail");
		}
	}

	private static bool isActive(GameObject go) {
		return go.activeSelf;
	}

	public void SelectScreen(GameObject screen) {
		this.LikeDislike.SetActive(false);
		this.Messages.SetActive(false);

		screen.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
