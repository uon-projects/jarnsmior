using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftBook : MonoBehaviour {


    Book bookScript;
	// Use this for initialization
	void Start ()
    {
        GameObject book = GameObject.FindGameObjectWithTag("Book");
        bookScript = (Book)book.GetComponent(typeof(Book));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {

        bookScript.ModifyPage(false);

    }
}
