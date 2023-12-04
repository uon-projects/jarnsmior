using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElongateBar : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.localScale = new Vector3(0f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Elongate(float elongationFactor)
    {

        transform.localScale += new Vector3(elongationFactor/10, 0f);

    }
}
