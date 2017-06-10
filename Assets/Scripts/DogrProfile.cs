using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogrProfile : MonoBehaviour {
	public Text Title;
	public Text Description;
	public Image MainImage;

	public Sprite[] Images;
	Tracery.Grammar grammar;

	public void GenerateNewProfile() {
		this.MainImage.sprite = this.Images[Random.Range(0, this.Images.Length)];
		this.Title.text = this.grammar.Flatten("#title#");
		this.Description.text = this.grammar.Flatten("#desc#");
	}

	// Use this for initialization
	void Start () {
		TextAsset jsonFile = (TextAsset) Resources.Load("profile"); // assuming the file is at Assets/Resources/grammar.json
		this.grammar = Tracery.Grammar.LoadFromJSON(jsonFile);
		// this.grammar = this.GetComponent<TraceryGrammar>().Grammar;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
