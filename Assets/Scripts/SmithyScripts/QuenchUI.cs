using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchUI : MonoBehaviour {

    Transform[] barTransforms = new Transform[4];
    float[] barLengths = new float[4];
    bool shouldShowScore = false;
    float totalScore = 0;
    float averageScore = 0;

    public GameObject steam;


	// Use this for initialization
	void Start ()
    {
        steam.SetActive(false);
        Transform[] temp = gameObject.GetComponentsInChildren<Transform>();
        int i = 0;
        foreach (Transform bar in temp)
        {
            if (bar.gameObject.transform.localPosition.x == 0.753f)
            {
                barTransforms[i] = bar;
                i++;
            }
            else if(bar.gameObject.transform.localPosition.x == -5.187f)
            {
                barTransforms[3] = bar;
            }
        }
        GameObject quenchUI = GameObject.FindGameObjectWithTag("QuenchingUI");
        quenchUI.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (shouldShowScore)
        {
            DisplayScore();
        }
	}

    public void showState(bool state)
    {
        steam.SetActive(true);
        shouldShowScore = state;

    }

    public void DisplayScore()
    {


        if(barLengths[0] > barTransforms[0].localScale.x)
        {

            barTransforms[0].localScale += new Vector3(0.005f, 0f, 0f);

        }
        else if (barLengths[1] > barTransforms[1].localScale.x)
        {

            barTransforms[1].localScale += new Vector3(0.005f, 0f, 0f);

        }
        else if (barLengths[2] > barTransforms[2].localScale.x)
        {

            barTransforms[2].localScale += new Vector3(0.005f, 0f, 0f);

        }
        else if(averageScore == 0)
        {

            averageScore = barTransforms[0].localScale.x + barTransforms[1].localScale.x + barTransforms[2].localScale.x;
            averageScore = averageScore / 3;
            barLengths[3] = averageScore;

        }
        else if(barLengths[3] > barTransforms[3].localScale.x)
        {

            barTransforms[3].localScale += new Vector3(0.005f, 0f, 0f);

        }


    }

    public void SetValues(int bar, float value, float maxValue)
    {
        float score = value / maxValue;
        Debug.Log(value);
        barLengths[bar] = score;
    }

    public void AdjustValues(int bar, float value, float maxValue)
    {

        float score = value/maxValue;
        barLengths[bar] = barLengths[bar] * score;

    }
}
