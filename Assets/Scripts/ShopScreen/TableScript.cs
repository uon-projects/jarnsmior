using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

    public GameObject mainCharacter;
    public MainCharacterScript mainCharacterScript;

    // Use this for initialization
    void Start ()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterShop");
        mainCharacterScript = (MainCharacterScript)mainCharacter.GetComponent(typeof(MainCharacterScript));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (mainCharacterScript != null)
        {
            mainCharacterScript.SetMove(2);
        }
    }

}
