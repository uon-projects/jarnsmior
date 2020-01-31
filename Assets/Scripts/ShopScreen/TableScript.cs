using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

    public GameObject mainCharacter;
    public MainCharacterScript mainCharacterScript;
    public TextScript textScript;

    // Use this for initialization
    void Start ()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterShop");
        mainCharacterScript = (MainCharacterScript)mainCharacter.GetComponent(typeof(MainCharacterScript));

        GameObject textHolder = GameObject.FindGameObjectWithTag("TextHolderShop");
        textScript = (TextScript)textHolder.GetComponent(typeof(TextScript));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (mainCharacterScript != null && textScript != null)
        {
            if (!textScript.isVisible)
            {
                mainCharacterScript.SetMove(2);
            }
        }
    }

}
