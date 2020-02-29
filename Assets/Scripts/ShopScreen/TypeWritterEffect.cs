﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWritterEffect : MonoBehaviour {

    public float delay = 10f;
    public string fullText;
    private string currentText = "";
    public bool startEffect = false;
    private bool effectStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(startEffect && !effectStarted)
        {
            //StartCoroutine(ShowText());
            ShowText();
            effectStarted = true;
        }
	}

    private float delayText = 0.05f;
    void ShowText()
    {
        if (fullText.Length >= 1)
        {
            this.GetComponent<Text>().text += fullText.Substring(0, 1);
        }
        if (fullText.Length >= 1)
        {
            fullText = fullText.Substring(1, fullText.Length - 1);
        }
        if (fullText.Length >= 1)
        {
            Invoke("ShowText", delayText);
        }
    }

}
