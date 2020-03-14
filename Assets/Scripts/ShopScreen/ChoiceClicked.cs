using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceClicked : MonoBehaviour
{

    public int choice = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log(choice);
    }

}
