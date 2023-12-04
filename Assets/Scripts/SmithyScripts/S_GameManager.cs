using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour {

	// S_GameManager mGameManager = S_GameManager.GetGameManagerScript();

	public static S_GameManager GetGameManagerScript()
	{
		return (S_GameManager)GameObject.FindGameObjectWithTag("S_GameManager").GetComponent(typeof(S_GameManager));
	}

    public enum GameState : ushort
    {
        JustStarted = 0,
        IngotObtained = 1,
        IngotHeated = 2,
        BarElongated = 3,
        BarBevelled = 4,
        BarSharpened = 5,
        SwordQuenched = 6
    }
	private GameState mGameState;

	private bool tutorialEnded = false;
    public enum TutorialState : ushort
    {
        None = 0,
        Elongation = 1,
        Bevelling = 2,
        Heating = 3,
        Sharpening = 4
    }
	private TutorialState mTutorialState;
	// Use this for initialization
	void Start ()
	{
		mGameState = GameState.JustStarted;
		mTutorialState = TutorialState.None;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void SetGameState(GameState mGameState)
	{
        Debug.Log(mGameState);
		this.mGameState = mGameState;
	}

	public GameState GetGameState()
	{
		return this.mGameState;
	}

	public void NextGameState()
	{
		if(mGameState != GameState.SwordQuenched)
		{
			mGameState++;
		}
	}

	public void SetTutorialState(TutorialState mTutorialState)
	{
		if(!tutorialEnded)
		{
			this.mTutorialState = mTutorialState;
		}
		if(mTutorialState == TutorialState.None)
		{
			// tutorialEnded = true;
		}
	}

	public TutorialState GetTutorialState()
	{
		return this.mTutorialState;
	}


}
