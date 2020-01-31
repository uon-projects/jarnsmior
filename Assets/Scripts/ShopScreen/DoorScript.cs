using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

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
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        if (mainCharacterScript != null)
        {
            mainCharacterScript.SetMove(true);
        }
    }

}
