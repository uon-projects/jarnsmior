using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour {

    private bool isMoving = false;
    private Vector3 targetPosition;
    private int speed = 4;

	// Use this for initialization
	void Start ()
    {
        GameObject door = GameObject.FindGameObjectWithTag("DoorShop");
        targetPosition.x = door.transform.position.x;
        targetPosition.y = door.transform.position.y - door.GetComponent<SpriteRenderer>().bounds.size.y / 2 + GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.2f;
        targetPosition.z = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
		if(isMoving)
        {
            Move();
        }
    }

    public void SetMove(bool move)
    {
        isMoving = move;

    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

}
