using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSmithy : MonoBehaviour {


    MainCharacterSmithy mainCharacterScript;
    CameraScript cameraScript;
    // Use this for initialization
    void Start ()
    {

        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));

        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        if (mainCharacterScript != null && mainCharacterScript.GetControl())
        {

            //mainCharacterScript.SetTarget;
            mainCharacterScript.SetTarget(new Vector3(8.11f, 5.04f, 0));
            cameraScript.SetTarget(new Vector3(8.49f, 4.91f, -10f), 3.0f);

        }
    }
}
