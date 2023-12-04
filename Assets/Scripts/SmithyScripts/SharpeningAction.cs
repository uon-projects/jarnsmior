using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAction : MonoBehaviour {

    GameObject swordHolder;
    GameObject grindStone;
    GameObject mainCharacter;
    SharpeningAlghoritm mSharpeningAlghoritm;
    Animator grindStoneAnimator;

    S_GameManager gameManager;
    GameObject theWallHanger;
    WallHanger myWallHanger;

    // Use this for initialization
    void Start()
    {
        theWallHanger = GameObject.FindGameObjectWithTag("WallHanger");
        myWallHanger = (WallHanger)theWallHanger.GetComponent(typeof(WallHanger));
        gameManager = S_GameManager.GetGameManagerScript();
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        swordHolder = GameObject.FindGameObjectWithTag("SwordHolder");
        mSharpeningAlghoritm = (SharpeningAlghoritm)swordHolder.GetComponent(typeof(SharpeningAlghoritm));
        grindStone = GameObject.FindGameObjectWithTag("Grindstone");
        grindStoneAnimator = grindStone.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Stop()
	{
        GameObject.FindGameObjectWithTag("MCGrindstone").SetActive(false);
        myWallHanger.SetHangerState(0);
        gameManager.SetTutorialState(S_GameManager.TutorialState.None);
        PlayerPrefs.SetFloat("Fade", 0f);
        grindStone.GetComponent<SpriteRenderer>().sortingOrder = 3;
        grindStone.GetComponent<BoxCollider2D>().enabled = true;
        mainCharacter.SetActive(true);
        grindStoneAnimator.SetBool("IsSharpening", false);
        mSharpeningAlghoritm.Stop();
	}

	public SharpeningAction SetItemLength(float length)
	{
		mSharpeningAlghoritm.SetItemLength(length);
		return this;
	}

	public void StartSharpeningAction()
	{
        gameManager.SetTutorialState(S_GameManager.TutorialState.Sharpening);
        PlayerPrefs.SetFloat("Fade", 0.7f);
        grindStone.GetComponent<SpriteRenderer>().sortingOrder = 5;
        grindStone.GetComponent<BoxCollider2D>().enabled = false;
        mainCharacter.SetActive(false);
        grindStoneAnimator.SetBool("IsSharpening", true);
        SetItemLength(PlayerPrefs.GetFloat("SwordLength"));
		mSharpeningAlghoritm.StartSharpening();		
	}



}
