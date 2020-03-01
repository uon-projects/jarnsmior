using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSmithyScript : MonoBehaviour
{
    public MainCharacterSmithyScript mainCharacterScript;

    // Use this for initialization
    void Start()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterShop");
        mainCharacterScript = (MainCharacterSmithyScript)mainCharacter.GetComponent(typeof(MainCharacterSmithyScript));

        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (mainCharacterScript != null && mainCharacterScript.isMoving == 0)
        {
            
                mainCharacterScript.SetMove(1);
                mainCharacterScript.SetTarget(new Vector3(55f, 29.8f, 0));
        }
    }

}
