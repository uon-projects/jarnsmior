using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour {

    float currentTime = 0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
		if(currentTime > 2.5f)
        {

            Destroy(gameObject);

        }
	}
}
