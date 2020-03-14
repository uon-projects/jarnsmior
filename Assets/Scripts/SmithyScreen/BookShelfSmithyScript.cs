using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfSmithyScript : MonoBehaviour {

    MainCharacterSmithyScript mainCharacterScript;

	// Use this for initialization
	void Start ()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterShop");
        mainCharacterScript = (MainCharacterSmithyScript)mainCharacter.GetComponent(typeof(MainCharacterSmithyScript));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        mainCharacterScript.SetMove(4);
    }
}
