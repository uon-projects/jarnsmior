using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSmithyScript : MonoBehaviour
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

            mainCharacterScript.SetMove(3);
            mainCharacterScript.SetTarget(new Vector3(-6.2f, -3.8f, 0));

        }
    }

}
