using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCBookSmithy : MonoBehaviour {

    Animator myAnimator;
    CameraScript cameraScript;
    AudioSource myAudioSource;
    bool playFlag = false;
    // Use this for initialization
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!playFlag)
        {

            playFlag = true;
            myAudioSource.PlayDelayed(0.4f);

        }
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("BookIdle"))
        {
            playFlag = false;
            cameraScript.SetTarget(new Vector3(52f, 18.39f, -10f), 6.07f);
            cameraScript.SetPosition(new Vector3(52f, 18.39f, -10f), 6.07f);
            gameObject.SetActive(false);
        }
    }
}
