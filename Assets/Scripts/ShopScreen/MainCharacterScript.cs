using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterScript : MonoBehaviour {

    private bool isMoving = false;
    private Vector3 targetPositionDoor, targetPositionTable;
    private int speed = 4;

	// Use this for initialization
	void Start ()
    {
        GameObject door = GameObject.FindGameObjectWithTag("DoorShop");
        targetPositionDoor.x = door.transform.position.x;
        targetPositionDoor.y = door.transform.position.y - door.GetComponent<SpriteRenderer>().bounds.size.y / 2 + GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.2f;
        targetPositionDoor.z = transform.position.z;

        GameObject table = GameObject.FindGameObjectWithTag("TableShop");
        targetPositionTable.x = table.transform.position.x + door.GetComponent<SpriteRenderer>().bounds.size.x / 2 - GetComponent<SpriteRenderer>().bounds.size.x / 2 + 0.2f;
        targetPositionTable.y = table.transform.position.y;
        targetPositionTable.z = transform.position.z;
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
        transform.position = Vector3.MoveTowards(transform.position, targetPositionTable, speed * Time.deltaTime);
        if(transform.position == targetPositionTable)
        {
            isMoving = false;
            SceneManager.LoadScene("SmithyScene");
        }
    }

}
