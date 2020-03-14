using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSmithSmithyScript : MonoBehaviour {


    private Animator mAnimator;
    public GameObject returnSmith;
    private GameObject LengthenUI;
    private MainCharacterSmithyScript mainCharacterScript;

    // Use this for initialization
    void Start ()
    {
        mAnimator = gameObject.GetComponent<Animator>();
        LengthenUI = GameObject.FindGameObjectWithTag("LengthenUI");
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetAnimation(string animationToSet, bool state)
    {

        mAnimator.SetTrigger(animationToSet);

    }

    void OnMouseDown()
    {

        returnSmith.SetActive(true);
        LengthenUI.SetActive(false);
        GameObject bookShelf = GameObject.FindGameObjectWithTag("BookShelf");
        Collider2D toEnable = bookShelf.GetComponent<Collider2D>();
        toEnable.enabled = true;
        mainCharacterScript = (MainCharacterSmithyScript)returnSmith.GetComponent(typeof(MainCharacterSmithyScript));
        mainCharacterScript.setIsSmithing(false);
        gameObject.SetActive(false);


    }
}
