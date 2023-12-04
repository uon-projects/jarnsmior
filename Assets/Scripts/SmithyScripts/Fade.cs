using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    float currentAlpha = 0;
    SpriteRenderer myRenderer;

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetFloat("Fade", 0);
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (PlayerPrefs.GetFloat("Fade") > currentAlpha)
        {
            currentAlpha += 0.5f * Time.deltaTime;
            if(currentAlpha > 1)
            {

                currentAlpha = 1;

            }
            myRenderer.color = new Color(myRenderer.color.r, myRenderer.color.g, myRenderer.color.b, currentAlpha);

        }
        else if(PlayerPrefs.GetFloat("Fade") < currentAlpha)
        {
            currentAlpha -= 0.5f * Time.deltaTime;
            if (currentAlpha < 0)
            {

                currentAlpha = 0;

            }
            myRenderer.color = new Color(myRenderer.color.r, myRenderer.color.g, myRenderer.color.b, currentAlpha);

        }
	}
}
