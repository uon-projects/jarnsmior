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
                GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterShop");
                MainCharacterSmithyScript mainCharacterScript = (MainCharacterSmithyScript)mainCharacter.GetComponent(typeof(MainCharacterSmithyScript));
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
        while(mArray[i] != 0)
        {
            Debug.Log(mArray[i]);
            i++;
        }
    }

}
