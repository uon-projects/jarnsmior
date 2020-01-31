using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCharacterScript : MonoBehaviour {

    private Vector3 targetPositionTable;
    private int speed = 4;
    private int isMoving = 0;

    // Use this for initialization
    void Start () {
        Vector3 mPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        mPos.z = transform.position.z;
        mPos.x -= gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        mPos.y = transform.position.y;
        transform.position = mPos;

        GameObject table = GameObject.FindGameObjectWithTag("TableShop");
        targetPositionTable.x = table.transform.position.x - table.GetComponent<SpriteRenderer>().bounds.size.x / 2 - GetComponent<SpriteRenderer>().bounds.size.x / 2 - 0.2f;
        targetPositionTable.y = table.transform.position.y + table.GetComponent<SpriteRenderer>().bounds.size.y / 5;
        targetPositionTable.z = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
		if(isMoving == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositionTable, speed * Time.deltaTime);
        }
	}

    public void MoveToTableNPC()
    {
        isMoving = 1;
    }
}
