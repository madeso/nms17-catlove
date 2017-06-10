using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupRandomFur : MonoBehaviour {
	MeshRenderer rend;

	public Material[] CatMaterials;

	static void ReplaceMaterial(MonoBehaviour go, string matname, Material newmat) {
		var r = go.GetComponentsInChildren<MeshRenderer>();
		foreach(var rend in r) {
			if (true) {
				// var m = rend.materials[i];
				var m = rend.material;
				var n = m.name.Trim().ToLower();
				var mn = matname.Trim().ToLower();
				// print(n);
				// print(mn);
				if( n.StartsWith(mn) ) {
					print("changing mat");
					// rend.materials[i] = newmat;
					rend.material = newmat;
				}
			}
		}
	}

	void Start () {
		// print("hello");
		var newmat = this.CatMaterials[ Random.Range(0, this.CatMaterials.Length) ];
		ReplaceMaterial(this, "CatMat", newmat);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
