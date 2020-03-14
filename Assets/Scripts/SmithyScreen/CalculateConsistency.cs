using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateConsistency : MonoBehaviour
{

    List<float> mList = new List<float>();
    float[] mArray = {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
    };
    int counter = 0;
    public void Add(float n)
    {
        mList.Add(n);
        mArray[counter] = n;
        counter++;
        //calulateConsistecy();
    }
    public float[] GetList()
    {
        return mArray;
    }

    void calulateConsistecy()
    {
        
        for (int i=0; i<mList.Capacity-1; i++)
        {
            Debug.Log(mList[i]);
        }
    }

}
