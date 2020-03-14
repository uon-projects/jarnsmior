using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterSmithyScript : MonoBehaviour
{
    public int isMoving = 0;
    public Vector3 charTarget;
    private Vector3  camStart, targetPositionDoor, targetPositionStairs, targetPositionLanding, targetPositionAnvil, targetPositionBook;
    private int speed = 50;
    private GameObject cameraObj;
    private GameObject smithAnvil;
    private GameObject lengthenUI;
    
    private bool enableMultiplePress = false;
    private float rangeWaiting;
    private Animator mAnimator;
    
    bool isSmithing;

    CameraSmithyScript cameraScript;

    // Use this for initialization
    void Start()
    {
        isSmithing = false;
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
        targetPositionAnvil.y = -12.7f;
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
        //print(targetPositionLanding);

        GameObject bookShelf = GameObject.FindGameObjectWithTag("BookShelf");
        targetPositionBook.x = bookShelf.transform.position.x;
        targetPositionBook.y = -12.7f;
        targetPositionBook.z = transform.position.z;


        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraSmithyScript)cameraObj.GetComponent(typeof(CameraSmithyScript));


        GameObject screenCenter = GameObject.FindGameObjectWithTag("ScreenCenter");
        camStart.x = screenCenter.transform.position.x;
        camStart.y = screenCenter.transform.position.y;
        camStart.z = -10;


        transform.position = targetPositionDoor;
        isMoving = 2;
        charTarget = targetPositionStairs;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //print(cameraShouldZoomOut);

        if (isMoving != 0)
        {
            mAnimator.SetBool("Walking", true);
            Move();
            
        }
        else if (isSmithing)
        {
            GameObject bookShelf = GameObject.FindGameObjectWithTag("BookShelf");
            Collider2D toDisable = bookShelf.GetComponent<Collider2D>();
            toDisable.enabled = false;

            //cameraScript.setTarget(targetPositionAnvil, true);
            smithAnvil.SetActive(true);
            lengthenUI.SetActive(true);
            gameObject.SetActive(false);

            


        }
        else
        {
            mAnimator.SetBool("Walking", false);
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
                //print(charTarget);
                if (transform.position == targetPositionDoor)
                {

                    isMoving = 0;
                    SceneManager.LoadScene("ShopScene");

                }
                else if (charTarget == targetPositionLanding)
                {
                    
                    charTarget = targetPositionStairs;
                }
                else if(charTarget == targetPositionStairs)
                {
                    charTarget = targetPositionDoor;
                }
                

            }
            else if (charTarget != targetPositionLanding)
            {
                
                cameraScript.setTarget(targetPositionDoor, true);
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);


            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);
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
                cameraScript.setTarget(camStart, false);
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);
            }
        }
        else if(isMoving == 3)
        {

            if (transform.position.x <= targetPositionAnvil.x && transform.position.x >= targetPositionAnvil.x-0.1f)
            {
                isMoving = 0;
                isSmithing = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, charTarget, speed * Time.deltaTime);
                cameraScript.setTarget(targetPositionAnvil, true);
                
                
            }

        }
        else if(isMoving == 4)
        {
            if (transform.position.x <= targetPositionBook.x)
            {
                isMoving = 0;
                
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPositionBook, speed * Time.deltaTime);
                cameraScript.setTarget(targetPositionBook, true);
                charTarget = targetPositionBook;


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

    public void setIsSmithing(bool state)
    {

        isSmithing = state;
        cameraScript.setTarget(camStart, false);
        

    }

    

    
}
