using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SF_SmithyDoor : MonoBehaviour {

    GameObject mainCharacter;
    SF_MainCharacterSmithy mainCharacterScript;

    private GameManager mGameManager;

    // Use this for initialization
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (SF_MainCharacterSmithy)mainCharacter.GetComponent(typeof(SF_MainCharacterSmithy));
        mGameManager = (GameManager)GameObject.FindGameObjectWithTag("SF_GameManager").GetComponent(typeof(GameManager));
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnMouseDown()
    {
        if (mainCharacterScript != null && mainCharacterScript.GetControl())
        {
            mainCharacterScript.TableToDoor();
        }
    }
}
