using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceSmithy : MonoBehaviour {

    MainCharacterSmithy mainCharacterScript;
    CameraScript cameraScript;

    GameObject furnaceSmithy;
    Animator myAnimator;
    bool checkFurnace = false;
    GameObject mainCharacter;
    // Use this for initialization
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        furnaceSmithy = GameObject.FindGameObjectWithTag("MCFurnace");
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));

        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
    }

    // Update is called once per frame
    void Update()
    {
        if(checkFurnace)
        {
            if(furnaceSmithy.activeSelf == true)
            {

                myAnimator.SetBool("OnOrOff", true);

            }
            else if(mainCharacter.transform.position.x <= 7f)
            {

                myAnimator.SetBool("OnOrOff", false);

            }


        }
    }

    void OnMouseDown()
    {
        if (mainCharacterScript != null && mainCharacterScript.GetControl())
        {
            checkFurnace = true;
            //mainCharacterScript.SetTarget;
            mainCharacterScript.SetTarget(new Vector3(7f, 5.04f, 0));
            cameraScript.SetTarget(new Vector3(6.65f, 4.91f, -10f), 3.0f);

        }
    }
}
