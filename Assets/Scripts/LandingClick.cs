using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingClick : MonoBehaviour {

    GameObject camera;
    LandingCamera cameraScript;
    AudioSource myAudioSource;
	// Use this for initialization
	void Start ()
    {
        myAudioSource = gameObject.GetComponent<AudioSource>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        cameraScript = (LandingCamera)camera.GetComponent(typeof(LandingCamera));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        myAudioSource.Play();
        cameraScript.SetTarget(new Vector3(3.7f, -0.53f, -10f), 0.89f);

    }
}
