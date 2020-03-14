using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateConsistency
{

    List<float> mList = new List<float>();
    public void Add(float n)
    {
        mList.Add(n);
    }
    public List<float> GetList()
    {
        return mList;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
