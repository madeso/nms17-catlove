using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogrProfile : MonoBehaviour {
	public Text[] Title;
	public Text[] Description;
	public Image[] MainImage;

	public Text MatchMessage;
	public Text UnmatchReason;

	public Sprite[] Images;
	Tracery.Grammar grammar;
	int lastindex = -1;

	public void GenerateNewProfile() {
		int index;
		do {
			index = Random.Range(0, this.Images.Length);
		} while(index == lastindex);
		lastindex = index;
		var sprite = this.Images[index];
		var title = this.grammar.Flatten("#title#");
		var desc = this.grammar.Flatten("#desc#");

		foreach(var s in this.MainImage) s.sprite = sprite;
		foreach(var t in this.Title) t.text = title;
		foreach(var d in this.Description) d.text = desc;

		GenerateMatchedData();
	}

	void GenerateMatchedData() {
		var okMessage = this.grammar.Flatten("#okmessage#");
		var okreason = "You were unmatched.";

		var badMessage = this.grammar.Flatten("#badmessage#");
		var badreason = "You blocked user.";

		if(Random.value > 0.5f ) {
			MatchMessage.text = okMessage;
			UnmatchReason.text = okreason;
		}
		else {
			MatchMessage.text = badMessage;
			UnmatchReason.text = badreason;
		}
	}

	// Use this for initialization
	void Start () {
		TextAsset jsonFile = (TextAsset) Resources.Load("profile");
		this.grammar = Tracery.Grammar.LoadFromJSON(jsonFile);
		GenerateNewProfile();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
