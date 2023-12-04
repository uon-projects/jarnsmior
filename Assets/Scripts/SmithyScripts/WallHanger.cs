using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHanger : MonoBehaviour {

    GameObject mainCharacter;
    GameObject anvil;

    CameraScript cameraScript;
    MainCharacterSmithy mainCharacterScript;
    MCFurnace myHeat;

    GameObject heatUI;
    GameObject quenchingUI;

    S_GameManager myGameManager;
    Animator myAnimator;

    // Use this for initialization
    void Start ()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        myGameManager = S_GameManager.GetGameManagerScript();
        quenchingUI = GameObject.FindGameObjectWithTag("QuenchingUI");
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
        anvil = GameObject.FindGameObjectWithTag("Anvil");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        Exit();

    }
    public void TriggerExit()
    {
        Exit();

    }

    void Exit()
    {
        mainCharacter.GetComponent<Animator>().SetBool("Cloth", true);
        myAnimator.SetInteger("HangerState", 0);
        myGameManager.SetTutorialState(S_GameManager.TutorialState.None);
        PlayerPrefs.SetFloat("Fade", 0f);
        GameObject anvilSmith = GameObject.FindGameObjectWithTag("MCAnvil");
        GameObject furnaceSmith = GameObject.FindGameObjectWithTag("MCFurnace");
        GameObject bevelSmith = GameObject.FindGameObjectWithTag("MCBevel");
        mainCharacter.SetActive(true);
        mainCharacterScript.SetControl(true);
        if (mainCharacterScript.GetTask() == 8.11f)
        {

            anvil.GetComponent<BoxCollider2D>().enabled = true;
            if (bevelSmith != null)
            {
                bevelSmith.SetActive(false);

            }
            else if (anvilSmith != null)
            {
                anvilSmith.SetActive(false);
                ElongateUI myElongateUI = (ElongateUI)anvilSmith.GetComponentInChildren(typeof(ElongateUI));
                if (myElongateUI.GetCounter() == 10)
                {

                    mainCharacterScript.SetAnvilType(true);

                }
            }
        }
        else if (furnaceSmith != null)
        {
            heatUI = GameObject.FindGameObjectWithTag("HeatUI");
            myHeat = (MCFurnace)heatUI.GetComponentInChildren(typeof(MCFurnace));

            myHeat.setHeat(-0.01f);
            furnaceSmith.SetActive(false);
        }
        mainCharacterScript.StopAction();

        if (quenchingUI != null)
        {

            quenchingUI.SetActive(false);

        }
        if (!mainCharacterScript.GetMove())
        {
            cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6.31f);
        }


    }

    public void SetHangerState(int state)
    {

        mainCharacter.GetComponent<Animator>().SetBool("Cloth", true);
        myAnimator.SetInteger("HangerState", state);

    }
}
