using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnvilSmithy : MonoBehaviour {

    Animator myAnimator;
    ElongateUI UI;
    ElongateBar bar;
    // Use this for initialization
    void Start ()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.ResetTrigger("Slam");
        UI = GetComponentInChildren<ElongateUI>();
        bar = GetComponentInChildren<ElongateBar>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        float elongationFactor = 0;      
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("AnvilIdle") && !UI.GetSlam())
        {
            myAnimator.SetTrigger("Slam");
            elongationFactor = UI.BeginSlam();
            elongationFactor = (1f / 1.9f) * elongationFactor;
            bar.Elongate(elongationFactor);
        }

  
    }
}
