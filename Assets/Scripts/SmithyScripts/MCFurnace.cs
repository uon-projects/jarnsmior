using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCFurnace : MonoBehaviour {

    float hotOrCold = 0;
    float currentHeat = 0;

    float currentScore = 0.5f;
    int counter = 0;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hotOrCold != 0)
        {
            currentHeat += hotOrCold*Time.deltaTime;
        }
        if (currentHeat > 1f)
        {

            currentHeat = 1;

        }
        else if (currentHeat < 0f)
        {

            currentHeat = 0;

        }

        transform.localScale = new Vector3(currentHeat, 1f, 1f);
    }

    public void setHeat(float heatToSet)
    {

        hotOrCold = heatToSet;

    }

    public void CheckTemp()
    {

        if (currentHeat < 0.7f)
        {

            currentScore -= 0.7f - currentHeat;

        }

        counter++;
        if (counter == 20)
        {
            if(currentScore < 0)
            {

                currentScore = 0;

            }

        }
    }
    public void CheckQuench()
    {

        if (currentHeat < 0.95f)
        {
            currentScore += currentHeat/2;
            

        }
        else
        {
            currentScore += 0.5f;
        }
        Debug.Log(currentScore);
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        QuenchUI myQuenchUI = (QuenchUI)scoreManager.GetComponent(typeof(QuenchUI));
        myQuenchUI.SetValues(2, currentScore, 1);

    }
}
