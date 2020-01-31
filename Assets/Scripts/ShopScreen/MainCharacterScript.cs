using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterScript : MonoBehaviour {

    private int isMoving = 0, isZooming = 0;
    private Vector3 targetPositionDoor, targetPositionTable;
    private int speed = 4;
    private Camera camera;

    // Use this for initialization
    void Start ()
    {
        GameObject door = GameObject.FindGameObjectWithTag("DoorShop");
        targetPositionDoor.x = door.transform.position.x;
        targetPositionDoor.y = door.transform.position.y - door.GetComponent<SpriteRenderer>().bounds.size.y / 2 + GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.2f;
        targetPositionDoor.z = transform.position.z;

        GameObject table = GameObject.FindGameObjectWithTag("TableShop");
        targetPositionTable.x = table.transform.position.x + table.GetComponent<SpriteRenderer>().bounds.size.x / 2 + GetComponent<SpriteRenderer>().bounds.size.x / 2 + 0.2f;
        targetPositionTable.y = table.transform.position.y + table.GetComponent<SpriteRenderer>().bounds.size.y / 5;
        targetPositionTable.z = transform.position.z;

    }
	
	// Update is called once per frame
	void Update () {
		if(isMoving != 0)
        {
            Move();
        }
        if(isZooming != 0)
        {
            Zoom();
        }
    }

    public void SetMove(int move)
    {
        isMoving = move;

    }

    public void Move()
    {
        if (isMoving == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositionDoor, speed * Time.deltaTime);
            if (transform.position == targetPositionDoor)
            {
                isMoving = 0;
                isZooming = 1;
            }
        }
        else if (isMoving == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositionTable, speed * Time.deltaTime);
            if (transform.position == targetPositionTable)
            {
                isMoving = 0;
            }
        }
    }

    private void Zoom()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 60, Time.deltaTime * 5);
        //SceneManager.LoadScene("SmithyScene");
    }

}
