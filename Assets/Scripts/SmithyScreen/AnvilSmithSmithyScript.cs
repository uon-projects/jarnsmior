using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSmithSmithyScript : MonoBehaviour {


    private Animator mAnimator;

    // Use this for initialization
    void Start ()
    {
        mAnimator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetAnimation(string animationToSet, bool state)
    {

        mAnimator.SetTrigger(animationToSet);

    }
}
