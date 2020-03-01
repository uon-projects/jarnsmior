using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterSmithyScript : MonoBehaviour
{
    public int isMoving = 0;
    public Vector3 charTarget;
    private Vector3 camTarget, camStart,  targetPositionDoor, targetPositionStairs, targetPositionLanding, targetPositionAnvil;
    private int speed = 5;
    private float zoomScale;
    private GameObject cameraObj;
    private GameObject smithAnvil;
    private GameObject lengthenUI;
    private Camera gameCamera;
    private bool enableMultiplePress = false;
    private float rangeWaiting;
    private Animator mAnimator;
    bool cameraShouldZoomOut = false;
    bool cameraShouldZoomIn = false;
    bool isSmithing = false;

    float camSpeed;

    // Use this for initialization
    void Start()
    {
        smithAnvil = GameObject.FindGameObjectWithTag("MainCharacterAnvil");
        smithAnvil.SetActive(false);

        lengthenUI = GameObject.FindGameObjectWithTag("LengthenUI");
        lengthenUI.SetActive(false);

        mAnimator = gameObject.GetComponent<Animator>();

        GameObject door = GameObject.FindGameObjectWithTag("DoorShop");
        targetPositionDoor.x = door.transform.position.x;
        targetPositionDoor.y = door.transform.position.y;// - door.GetComponent<SpriteRenderer>().bounds.size.y / 2 + GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.2f;
        //targetPositionDoor.z = transform.position.z;
        targetPositionDoor.z = transform.position.z;

        GameObject anvil = GameObject.FindGameObjectWithTag("Anvil");
        targetPositionAnvil.x = anvil.transform.position.x;
        targetPositionAnvil.y = 29.44f;
        targetPositionAnvil.z = transform.position.z;

        GameObject topStairs = GameObject.FindGameObjectWithTag("CameraMarker1");
        targetPositionStairs.x = topStairs.transform.position.x;
        targetPositionStairs.y = topStairs.transform.position.y;
        //targetPositionStairs.z = topStairs.transform.position.z;
        targetPositionStairs.z = transform.position.z;

        GameObject bottomStairs = GameObject.FindGameObjectWithTag("CameraMarker2");
        targetPositionLanding.x = bottomStairs.transform.position.x;
        targetPositionLanding.y = bottomStairs.transform.position.y;
        //targetPositionStairs.z = topStairs.transform.position.z;
        targetPositionLanding.z = transform.position.z;

        GameObject screenCenter = GameObject.FindGameObjectWithTag("ScreenCenter");
        camStart.x = screenCenter.transform.position.x;
        camStart.y = screenCenter.transform.position.y;
        camStart.z = -10;

        camTarget = camStart;


        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        gameCamera = cameraObj.GetComponent<Camera>();

        cameraObj.transform.position = new Vector3(targetPositionDoor.x, targetPositionDoor.y, camTarget.z);

        transform.position = targetPositionDoor;
        isMoving = 2;
        charTarget = targetPositionStairs;
        zoomScale = 3.04f;
        gameCamera.orthographicSize = zoomScale;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (isMoving != 0)
        {
            mAnimator.SetBool("Walking", true);
            Move();
            
        }
        else if (isSmithing)
        {          
            smithAnvil.SetActive(true);
            lengthenUI.SetActive(true);
            gameObject.SetActive(false);

        }
        else
        {
            mAnimator.SetBool("Walking", false);
        }
        if(cameraShouldZoomOut)
        {

            if(gameCamera.orthographicSize <= 6)
            {

                ZoomOut(camTarget);
                cameraShouldZoomOut = false;

            }

        }
        if (cameraShouldZoomIn)
        {

            if (gameCamera.orthographicSize >= 2.5f)
            {

                ZoomIn(camTarget);
                cameraShouldZoomIn = false;

            }
            else
            {
                camTarget = camStart;
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

    public void SetTarget(Vector3 target)
    {

        charTarget = target;

    }

    public void Move()
    {
        
        if (isMoving == 1)
        {
            
            if (transform.position == charTarget)
            {

                if (transform.position == targetPositionDoor)
                {

                    isMoving = 0;

                }
                else if (charTarget != targetPositionLanding)
                {
                    charTarget = targetPositionDoor;
                }
                else if(charTarget != targetPositionDoor)
                {
                    charTarget = targetPositionStairs;
                }
                

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);
                camTarget = targetPositionDoor;
                cameraShouldZoomIn = true;
                camSpeed = 0.01f;

            }
        }
        else if (isMoving == 2)
        {
            
            if (transform.position == charTarget)
            {
                if (charTarget != targetPositionLanding)
                {
                    charTarget = targetPositionLanding;
                }
                else
                {
                    isMoving = 0;
                }
                
            }
            else
            {
                cameraShouldZoomOut = true;
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);
            }
        }
        else if(isMoving == 3)
        {

            if (transform.position.x <= targetPositionAnvil.x)
            {
                isMoving = 0;
                isSmithing = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);
                camTarget = targetPositionAnvil;
                cameraShouldZoomIn = true;
                camSpeed = 0.02f;
                
            }

        }

        if (charTarget.x < transform.position.x)
        {

            transform.localScale = new Vector3(-5.5f, 5.5f, 5f);

        }
        else
        {
            transform.localScale = new Vector3(5.5f, 5.5f, 5f);
        }
    }

    private void ZoomIn(Vector3 target)
    {
        gameCamera.orthographicSize -= camSpeed;
        Vector3 cameraPosition;
        cameraPosition.x = cameraObj.transform.position.x;
        cameraPosition.y = cameraObj.transform.position.y;
        cameraPosition.z = -10;
        cameraObj.transform.position = Vector3.Lerp(cameraPosition, target, 0.01f);
    }

    private void ZoomOut(Vector3 target)
    {
        cameraObj.GetComponent<Camera>().orthographicSize += 0.02f;
        Vector3 cameraPosition;
        cameraPosition.x = cameraObj.transform.position.x;
        cameraPosition.y = cameraObj.transform.position.y;
        cameraPosition.z = -10;
        cameraObj.transform.position = Vector3.Lerp(cameraPosition, target, 0.01f);
    }

    
}
