using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SF_SmithyTable : MonoBehaviour {

    GameObject mainCharacter;
    SF_MainCharacterSmithy mainCharacterScript;

    // Use this for initialization
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (SF_MainCharacterSmithy)mainCharacter.GetComponent(typeof(SF_MainCharacterSmithy));

        

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnMouseDown()
    {

        if (mainCharacterScript != null && mainCharacterScript.GetControl())
        {

            mainCharacterScript.DoorToTable();
        }
    }
}
