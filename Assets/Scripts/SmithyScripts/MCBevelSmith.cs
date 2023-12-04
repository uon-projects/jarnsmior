using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCBevelSmith : MonoBehaviour {

    Animator myAnimator;
    BevelUI myBevelScript;

	// Use this for initialization
	void Start ()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.ResetTrigger("Slam");
        GameObject bevelUI;
        bevelUI = GameObject.FindGameObjectWithTag("MCBevel");
        myBevelScript = (BevelUI)bevelUI.GetComponentInChildren(typeof(BevelUI));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("AnvilIdle") && !myBevelScript.GetSlam())
        {
            myAnimator.SetTrigger("Slam");
            myBevelScript.BeginSlam();
        }

    }
}
