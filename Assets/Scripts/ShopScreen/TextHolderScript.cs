using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextHolderScript : MonoBehaviour {
   

    // Use this for initialization
    void Start ()
    {
        float camHalfHeight = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        Vector3 mPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        mPos.z = transform.position.z;
        mPos.y = -camHalfWidth/2;
        mPos.x = 0;
        transform.position = mPos;
    }
	
	// Update is called once per frame
	void Update () {

	}
    
}
