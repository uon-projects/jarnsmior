using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterScript : MonoBehaviour {

    private int isMoving = 0, isZooming = 0;
    private Vector3 targetPositionDoor, targetPositionTable;
    private int speed = 4;
    private float zoomScale;
    private GameObject cameraObj;

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

        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        transform.position = targetPositionDoor;
        isMoving = isZooming = 2;
        zoomScale = 3.04f;
        cameraObj.GetComponent<Camera>().orthographicSize = zoomScale;
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
            ZoomIn();
            transform.position = Vector3.MoveTowards(transform.position, targetPositionDoor, speed * Time.deltaTime);
            if (transform.position == targetPositionDoor)
            {
                isMoving = 0;
                isZooming = 1;
                print(cameraObj.GetComponent<Camera>().orthographicSize);
            }
        }
        else if (isMoving == 2)
        {
            ZoomOut();
            transform.position = Vector3.MoveTowards(transform.position, targetPositionTable, speed * Time.deltaTime);
            if (transform.position == targetPositionTable)
            {
                isMoving = 0;
            }
        }
    }

    private void ZoomIn()
    {
        cameraObj.GetComponent<Camera>().orthographicSize -= 0.02f;
        Vector3 cameraTarget;
        cameraTarget.x = transform.position.x;
        cameraTarget.y = transform.position.y;
        cameraTarget.z = cameraObj.transform.position.z;
        cameraObj.transform.position = Vector3.Lerp(cameraTarget, targetPositionTable, 0.02f);
    }

    private void ZoomOut()
    {
        cameraObj.GetComponent<Camera>().orthographicSize += 0.02f;
        Vector3 cameraTarget;
        cameraTarget.x = transform.position.x;
        cameraTarget.y = transform.position.y;
        cameraTarget.z = cameraObj.transform.position.z;
        cameraObj.transform.position = Vector3.Lerp(cameraTarget, targetPositionTable, 0.02f);
    }

}
