using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SF_Scroller : MonoBehaviour {

    ScrollRect myScrollRect;
	// Use this for initialization
	void Start () {
        myScrollRect = gameObject.GetComponent<ScrollRect>();

    }
	
	// Update is called once per frame
	void Update () {
		myScrollRect.verticalNormalizedPosition = 0;
    }
}
