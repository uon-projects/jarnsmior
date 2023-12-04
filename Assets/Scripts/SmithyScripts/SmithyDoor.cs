using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithyDoor : MonoBehaviour {

    GameObject mainCharacter;
    MainCharacterSmithy mainCharacterScript;

    // Use this for initialization
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));

        

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnMouseDown()
    {

        if (mainCharacterScript != null && mainCharacterScript.GetControl())
        {

            mainCharacterScript.SetTarget(new Vector3(19.68f, 5.04f, 0f), new Vector3(17.18f, 5.04f, 0f), new Vector3(12.98f, 10.02f, 0f), new Vector3(2.65f, 10.04f, 0f));
        }
    }
}
