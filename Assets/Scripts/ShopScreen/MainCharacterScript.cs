using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterScript : MonoBehaviour {

    private int isMoving = 0;
    private Vector3 targetPositionDoor, targetPositionTable;
    private int speed = 4;
    private float zoomScale;
    private GameObject cameraObj;
    private bool enableMultiplePress = false;
    private bool interactedWithCustomer = false;
    private bool cutomerComing = false;
    private float rangeWaiting;

    public NPCharacterScript npCharacterScript;

    // Use this for initialization
    void Start ()
    {
        GameObject npCharacter = GameObject.FindGameObjectWithTag("NPCharacterShop");
        npCharacterScript = (NPCharacterScript)npCharacter.GetComponent(typeof(NPCharacterScript));

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
        isMoving = 2;
        zoomScale = 3.04f;
        cameraObj.GetComponent<Camera>().orthographicSize = zoomScale;
    }

    // Update is called once per frame
    void Update () {
		if(isMoving != 0)
        {
            Move();
        }
        if(interactedWithCustomer && !cutomerComing)
        {
            rangeWaiting -= Time.deltaTime;
            if (rangeWaiting < 0)
            {
                cutomerComing = true;
                npCharacterScript.MoveToTableNPC();
            }
        }
    }

    public void SetMove(int move)
    {
        if (enableMultiplePress)
        {
            isMoving = move;
        }
        else if (isMoving == 0)
        {
            isMoving = move;
        }
    }

    public void Move()
    {
        if (isMoving == 1)
        {
            if (transform.position == targetPositionDoor)
            {
                isMoving = 0;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPositionDoor, speed * Time.deltaTime);
                ZoomIn();
            }
        }
        else if (isMoving == 2)
        {
            if (transform.position == targetPositionTable)
            {
                isMoving = 0;
                if (!interactedWithCustomer)
                {
                    interactedWithCustomer = true;
                    rangeWaiting = Random.Range(3, 6);
                }
            }
            else
            {
                ZoomOut();
                transform.position = Vector3.MoveTowards(transform.position, targetPositionTable, speed * Time.deltaTime);
            }
        }
    }

    private void ZoomIn()
    {
        cameraObj.GetComponent<Camera>().orthographicSize -= 0.02f;
        Vector3 cameraTarget;
        cameraTarget.x = transform.position.x;
        cameraTarget.y = transform.position.y;
        cameraTarget.z = -20;
        cameraObj.transform.position = Vector3.Lerp(cameraTarget, targetPositionTable, 0.02f);
    }

    private void ZoomOut()
    {
        cameraObj.GetComponent<Camera>().orthographicSize += 0.02f;
        Vector3 cameraTarget;
        cameraTarget.x = transform.position.x;
        cameraTarget.y = transform.position.y;
        cameraTarget.z = -20;
        cameraObj.transform.position = Vector3.Lerp(cameraTarget, targetPositionTable, 0.02f);
    }

}
