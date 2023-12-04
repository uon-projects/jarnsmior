using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseSmithy : MonoBehaviour {

    MainCharacterSmithy mainCharacterScript;
    CameraScript cameraScript;

    void Start()
    {

        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));

        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (mainCharacterScript != null && mainCharacterScript.GetControl())
        {
            mainCharacterScript.SetTarget(new Vector3(3.34f, 5.04f, 0));
            cameraScript.SetTarget(new Vector3(2.45f, 5.78f, -10f), 1f);
        }
    }
}
