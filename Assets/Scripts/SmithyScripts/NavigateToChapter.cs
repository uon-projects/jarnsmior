using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateToChapter : MonoBehaviour {

    Book bookScript;
	// Use this for initialization

    public int goToChapter;

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

        bookScript.GoToChapter(goToChapter);

    }
}
