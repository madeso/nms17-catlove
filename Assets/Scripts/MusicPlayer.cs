using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	public AudioClip MusicLoop;
	public AudioSource Source;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Source.isPlaying == false ) {
			Source.clip = MusicLoop;
			Source.loop = true;
			Source.Play();
		}
	}
}
