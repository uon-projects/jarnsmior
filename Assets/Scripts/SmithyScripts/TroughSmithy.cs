using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroughSmithy : MonoBehaviour {

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
            mainCharacterScript.SetTarget(new Vector3(14.58f, 5.04f, 0));
            cameraScript.SetTarget(new Vector3(14.99f, 4.77f, -10f), 3.0f);

        }
    }
}
