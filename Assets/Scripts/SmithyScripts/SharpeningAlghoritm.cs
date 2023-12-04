using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAlghoritm : MonoBehaviour {


	// private int rangeImproverD = 15;
	// private int rangeImproverR = 5;
	// private float speed = 1.0f; //how fast it shakes
	private float degress = 0.1f;
	private int rangeImproverD = 30;
	private int rangeImproverR = 10;
	private float speed = 0.5f; //how fast it shakes
	private float amount = 1.0f; //how much it shakes
    private float consistency = 0f;
	private float nextActionTime = 0.0f;
	private float period = 0.1f;
    private float rotationGravityLerp = 0.0f;
	private float rotationGravity = 0.0f;

    private float adjustTimer = 0f;

	private float startTime;
	private float elapsedTime = 0f;

    GameObject Sword;
    SwordMovement mSwordMovement;
    GameObject mainCharacter;
    MainCharacterSmithy mainCharacterScript;
    CameraScript cameraScript;

    private List<float> hitStore = new List<float>();

    // Use this for initialization
    void Start ()
	{	
        Sword = GameObject.FindGameObjectWithTag("Sword");
        mSwordMovement = (SwordMovement)Sword.GetComponent(typeof(SwordMovement));
		mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (mSwordMovement.GetMouseDown())
        {
            elapsedTime += Time.deltaTime;
            if(!mSwordMovement.IsActionDone())
            {
                if (MouseToLeft())
                {
                    if (transform.rotation.z < degress)
                    {
                        transform.Rotate(new Vector3(0, 0, rangePointer()) * Time.deltaTime);
                    }
                }
                else
                {
                    if (transform.rotation.z > -degress)
                    {
                        transform.Rotate(new Vector3(0, 0, (-1) * rangePointer()) * Time.deltaTime);
                    }
                }
                if (rotationGravity < rotationGravityLerp)
                {
                    if (adjustTimer > 0.03f)
                    {
                        adjustTimer = 0;
                        rotationGravity += 0.01f;
                    }
                    else
                    {
                        adjustTimer += Time.deltaTime;
                    }
                }
                else if (rotationGravity > rotationGravityLerp)
                {
                    if (adjustTimer > 0.03f)
                    {
                        adjustTimer = 0;
                        rotationGravity -= 0.01f;
                    }
                    else
                    {
                        adjustTimer += Time.deltaTime;
                    }
                }
                RotateAction();
            }
        }
        
        if(mSwordMovement.IsActionDone())
        {
            if(Mathf.Abs(transform.rotation.z) > 0.001)
            {
                transform.localRotation = Quaternion.Euler(0, 0, -transform.rotation.z);
                mSwordMovement.ResetAxisX();
            }
            else if(mSwordMovement.IsItemInPos())
            {
                mainCharacter.SetActive(true);
                mainCharacterScript.SetControl(true);
                mainCharacterScript.StopAction();
                cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6.31f);
                CalculateScore();
            }
        }

	}

	void RotateAction()
	{
		
		if (elapsedTime < nextActionTime)
		{
			if (transform.rotation.z > -degress && rotationGravity < 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
			else if (transform.rotation.z < degress && rotationGravity >= 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
		}
		else
		{
            elapsedTime = 0f;
			nextActionTime = Random.Range(2.0f, 3.0f);
			rotationGravityLerp = Random.Range(-degress, degress) * rangeImproverR;
            hitStore.Add(transform.rotation.z);
		}

	}

	bool MouseToLeft()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return transform.position.x > mousePosition.x;

	}

	float rangePointer()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return rangeImproverD * Mathf.Abs(transform.position.x - mousePosition.x);

	}

	public void SetItemLength(float length)
	{
		mSwordMovement.SetLength(length);
	}

	public void StartSharpening()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

	public void Stop()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

    void CalculateScore()
    {
        
        float totalVal;
        float consistencyVal = 0;
        float totalScore = 0;
        float calculator = 0;
        float angleCalculator = 0;
        float maxVal = 0;
        float minVal = 10000;
        for (int i = 0; i < hitStore.Count; i++)
        {
            if (hitStore[i] > maxVal)
            {

                maxVal = hitStore[i];

            }
            if (hitStore[i] < minVal)
            {
                minVal = hitStore[i];
            }

            calculator += hitStore[i];
            angleCalculator += Mathf.Abs(hitStore[i]);

        }

        totalVal = calculator*10;
        calculator = totalVal / hitStore.Count;
        //Debug.Log(angleCalculator);
        angleCalculator = (angleCalculator * 100) / hitStore.Count;
        //Debug.Log(angleCalculator);
        consistencyVal += Mathf.Abs(calculator - minVal);
        consistencyVal += Mathf.Abs(calculator - maxVal);
        totalScore += 50 - (angleCalculator*3);
        //print(consistencyVal);
        //print(calculator);
        //print(totalScore);
        S_GameManager mGameManager = S_GameManager.GetGameManagerScript();
        mGameManager.SetGameState(S_GameManager.GameState.BarSharpened);
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        QuenchUI myQuenchUI = (QuenchUI)scoreManager.GetComponent(typeof(QuenchUI));
        myQuenchUI.AdjustValues(1, totalScore, 50);

    }

}
