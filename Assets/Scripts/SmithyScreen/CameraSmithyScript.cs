using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmithyScript : MonoBehaviour {

    bool cameraShouldZoomOut = false;
    bool cameraShouldZoomIn = false;
    bool cameraShouldMove = true;
    private float zoomScale;
    float camSpeed;

    Vector3 targetPositionDoor, camTarget, camStart;

    private Camera gameCamera;

    

    // Use this for initialization
    void Start ()
    {
        GameObject door = GameObject.FindGameObjectWithTag("DoorShop");
        targetPositionDoor.x = door.transform.position.x;
        targetPositionDoor.y = door.transform.position.y;
        targetPositionDoor.z = transform.position.z;

        gameCamera = gameObject.GetComponent<Camera>();
        gameObject.transform.position = new Vector3(targetPositionDoor.x, targetPositionDoor.y, -10);




        camStart = new Vector3(204.6f, 13.9f, gameObject.transform.position.z);
        camTarget = camStart;
        
        zoomScale = 20f;
        gameCamera.orthographicSize = zoomScale;


    }
	
	// Update is called once per frame
	void Update ()
    {
        print(camTarget);
        if (cameraShouldZoomOut)
        {
            
            //print("Working");
            if (gameCamera.orthographicSize <= 53)
            {

                ZoomOut();
                //print(camTarget);

            }
            else
            {
                cameraShouldZoomOut = false;
                //print(camTarget);
            }


        }
        else if (cameraShouldZoomIn)
        {
            
            if (gameCamera.orthographicSize >= 20f)
            {

                ZoomIn();


            }
            else
            {
                //camTarget = camStart;
                cameraShouldZoomIn = false;
            }

        }
        if (cameraShouldMove)
        {

            if (gameObject.transform.position != camTarget)
            {

                Move(camTarget);

            }
            else
            {

                cameraShouldMove = false;
                camTarget = camStart;

            }

        }

    }

    private void ZoomIn()
    {
        gameCamera.orthographicSize -= 0.2f;
        //Vector3 cameraPosition;
        //cameraPosition.x = gameObject.transform.position.x;
        //cameraPosition.y = gameObject.transform.position.y;
        //cameraPosition.z = gameObject.transform.position.z;
        //gameObject.transform.position = Vector3.Lerp(cameraPosition, camTarget, 0.02f);

    }

    private void ZoomOut()
    {
        gameObject.GetComponent<Camera>().orthographicSize += 0.2f;
        //Vector3 cameraPosition;
        //cameraPosition.x = gameObject.transform.position.x;
        //cameraPosition.y = gameObject.transform.position.y;
        //cameraPosition.z = gameObject.transform.position.z;
        //gameObject.transform.position = Vector3.Lerp(cameraPosition, camTarget, 0.02f);

    }

    public void setTarget(Vector3 target, bool outOrIn)
    {
        print(target);
        camTarget = target;
        camTarget.z = gameObject.transform.position.z;
        if (outOrIn)
        {

            cameraShouldZoomOut = false;
            cameraShouldZoomIn = true;

        }
        else
        {
            cameraShouldZoomOut = true;
            cameraShouldZoomIn = false;
        }

    }

    public void Move(Vector3 target)
    {
        camTarget = target;
        target.z = gameObject.transform.position.z;
        Vector3 cameraPosition;
        cameraPosition.x = gameObject.transform.position.x;
        cameraPosition.y = gameObject.transform.position.y;
        cameraPosition.z = gameObject.transform.position.z;
        gameObject.transform.position = Vector3.Lerp(cameraPosition, camTarget, 0.02f);
    }
}
