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
        if(counter < 9)
        {
            mArray[counter] = n;
            counter++;
            if(counter == 9)
            {

            }
        }
        calulateConsistecy();
    }
    public float[] GetList()
    {
        return mArray;
    }
    public bool canAdd()
    {
        if (counter < 9)
        {
            return true;
        }
        return false;
    }

    void calulateConsistecy()
    {
        int i = 0;
        float sum = 0;
        float low = 10;
        float high = 0;
        while(mArray[i] != 0 && i<10)
        {
            sum+=mArray[i];
            if (mArray[i] < low)
            {
                low = mArray[i];
            }
            if (mArray[i] > high)
            {
                high = mArray[i];
            }
            i++;
        }
        float avg = sum / 10;
        if(avg - low < avg - high)
        {
            Debug.Log("l");
        }
        else
        {
            Debug.Log("h");
        }
    }

}
