using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SF_MessageItemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver() {
		GetComponent<Transform>().localScale = new Vector3(1.2f, 1.2f, 1.0f);
		GetComponent<TextMesh>().color = new Color(254.0f/255.0f, 152.0f/255.0f, 203.0f/255.0f);
	}

	void OnMouseExit() {
		GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
		GetComponent<TextMesh>().color = new Color(255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
	}

	void OnMouseDown() {
		GetComponent<TextMesh>().text = "tgsbshs";
	}

}
