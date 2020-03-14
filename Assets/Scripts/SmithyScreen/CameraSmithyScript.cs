using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmithyScript : MonoBehaviour {

    bool cameraShouldZoomOut = false;
    bool cameraShouldZoomIn = false;
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

        
        
        

        camTarget = camStart;
        zoomScale = 3.04f;
        gameCamera.orthographicSize = zoomScale;


    }
	
	// Update is called once per frame
	void Update ()
    {

        if (cameraShouldZoomOut)
        {
            //print("Working");
            if (gameCamera.orthographicSize <= 6)
            {

                ZoomOut(camTarget);
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
            print(gameCamera.orthographicSize);
            if (gameCamera.orthographicSize >= 2.5f)
            {

                ZoomIn(camTarget);


            }
            else
            {
                camTarget = camStart;
                cameraShouldZoomIn = false;
            }

        }

    }

    private void ZoomIn(Vector3 target)
    {
        gameCamera.orthographicSize -= 0.02f;
        Vector3 cameraPosition;
        cameraPosition.x = gameObject.transform.position.x;
        cameraPosition.y = gameObject.transform.position.y;
        cameraPosition.z = -10;
        gameObject.transform.position = Vector3.Lerp(cameraPosition, target, 0.01f);
    }

    private void ZoomOut(Vector3 target)
    {
        gameObject.GetComponent<Camera>().orthographicSize += 0.02f;
        Vector3 cameraPosition;
        cameraPosition.x = gameObject.transform.position.x;
        cameraPosition.y = gameObject.transform.position.y;
        cameraPosition.z = gameObject.transform.position.z;
        gameObject.transform.position = Vector3.Lerp(cameraPosition, camTarget, 0.01f);
    }

    public void setTarget(Vector3 target, bool outOrIn)
    {

        camTarget = target;
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
}
