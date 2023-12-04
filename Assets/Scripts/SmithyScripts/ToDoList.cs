using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ToDoList : MonoBehaviour {

	// ToDoList mToDoList = ToDoList.GetScript();
	public static ToDoList GetScript()
	{
		return (ToDoList)GameObject.FindGameObjectWithTag("ToDoList").GetComponent(typeof(ToDoList));
	}

	private S_GameManager mGameManager;
	public Sprite toDoList1;
	public Sprite toDoList2;
	public Sprite toDoList3;
	public Sprite toDoList4;
	public Sprite toDoList5;
	public Sprite toDoList6;
	public Sprite toDoList7;

    public GameObject up;
    public GameObject down;
    public GameObject rest;

    RectTransform myTransform;
    public Vector3[] targets = { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    int numberOfTargets;
    bool isMoving = false;
    float speed = 12.5f;
    bool upOrDown = true;

    AudioSource myAudioSource;

    // Use this for initialization
    void Start ()
	{
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myTransform = gameObject.GetComponent<RectTransform>();
        mGameManager = S_GameManager.GetGameManagerScript();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(mGameManager.GetGameState() == S_GameManager.GameState.JustStarted)
		{
			gameObject.GetComponent<Image>().sprite = toDoList1;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.IngotObtained)
		{
			gameObject.GetComponent<Image>().sprite = toDoList2;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.IngotHeated)
		{
			gameObject.GetComponent<Image>().sprite = toDoList3;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.BarElongated)
		{
			gameObject.GetComponent<Image>().sprite = toDoList4;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.BarBevelled)
		{
			gameObject.GetComponent<Image>().sprite = toDoList5;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.BarSharpened)
		{
			gameObject.GetComponent<Image>().sprite = toDoList6;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.SwordQuenched)
		{
			gameObject.GetComponent<Image>().sprite = toDoList7;
		}
        if (isMoving)
        {
            if (MoveTowards(targets[numberOfTargets]))
            {
                speed = 12.5f;
                numberOfTargets -= 1;
                if (numberOfTargets == 0)
                {
                    speed = 12.5f;
                    upOrDown = !upOrDown;
                    isMoving = false;

                }
            }

        }
    }

    bool MoveTowards(Vector3 target)
    {

        myTransform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        speed = speed * 1.2f;
        Debug.Log(target);

        if (myTransform.position.y == target.y) //&& target.y < rest.transform.position.y+1)
        {
            return true;

        }
        else if (myTransform.position.y == target.y)// && target.y < rest.transform.position.y +1)
        {

            return true;

        }
        else if (myTransform.position.y >= target.y-1 && target == rest.transform.position)
        {

            return true;

        }
        else
        {

            return false;

        }

        
    }

    public void SetTarget(Vector3 target1, Vector3 target2)
    {
        targets[1] = target2;
        targets[2] = target1;
        isMoving = true;
        numberOfTargets = 2;
    }

    public void Click()
    {
        myAudioSource.Play();
        if (upOrDown)
        {
            SetTarget(down.transform.position, up.transform.position);
        }
        else
        {
            SetTarget(down.transform.position, rest.transform.position);
        }

    }
}
