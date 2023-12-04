using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindstoneSmithy : MonoBehaviour {

    MainCharacterSmithy mainCharacterScript;
    CameraScript cameraScript;

    // Use this for initialization
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

            //mainCharacterScript.SetTarget;
            mainCharacterScript.SetTarget(new Vector3(15.5f, 5.04f, 0));
            cameraScript.SetTarget(new Vector3(13.5f, 5.5f, -10f), 3.0f);

        }
    }
}
