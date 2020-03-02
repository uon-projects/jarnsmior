using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthenBarSmithyScript : MonoBehaviour {

    Vector3 topPosition, bottomPosition;
    public  float speed;
    bool upOrDown;
    bool SLAM;
    AnvilSmithSmithyScript mainCharacterScript;
    float animationTimer;
    float timeToWait;
    bool particlesSpawned;
    public GameObject Particles;
    

    // Use this for initialization
    void Start () 
    {
        particlesSpawned = false;
        SLAM = false;
        upOrDown = false;
        speed = 3;
        topPosition = new Vector3(40.35f, 29.19f, 0);
        bottomPosition = new Vector3(40.35f, 28.52f, 0);
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterAnvil");
        mainCharacterScript = (AnvilSmithSmithyScript)mainCharacter.GetComponent(typeof(AnvilSmithSmithyScript));

    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!SLAM)
        {
            CalculateSpeed();
            Move();
        }
        else
        {
            SlamDown();
        }
	}

    void Move()
    {
        //print("Working");
        if (upOrDown)
        {
            if (gameObject.transform.position.y < topPosition.y)
            {
                //print("Working");
                transform.position = Vector3.MoveTowards(transform.position, topPosition, speed * Time.deltaTime);
            }
            else
            {
               // print("Working");
                upOrDown = false;
            }
        }
        else if (gameObject.transform.position.y > bottomPosition.y)
        {
            //print("Working");
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);

        }
        else
        {
            //print("Working");
            upOrDown = true;
        }

    }

    void CalculateSpeed()
    {

        float botdist = gameObject.transform.position.y - bottomPosition.y;
        float topdist = topPosition.y -gameObject.transform.position.y;

        if (botdist > topdist)
        {
            speed = topdist*2;
        }
        else
        {
            speed = botdist*2;
        }

        if (speed < 0.05f)
        {
            speed = 0.05f;
        }
        

    }

    void SlamDown()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer >= timeToWait)
        {
            if (gameObject.transform.position.y > bottomPosition.y)
            {
                //print("Working");
                transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);
            }
            else if(!particlesSpawned)
            {

                GameObject anvilSparks = Instantiate(Particles, new Vector3(39.34f, 29.4f, 0f), transform.rotation); 
                Particles.transform.localScale = new Vector3(0.58f, 0.58f, 0.58f);
                GameObject UISparks = Instantiate(Particles, new Vector3(40.52f, 30.05f, 0f), transform.rotation);
                Particles.transform.localScale = new Vector3(1f, 1f, 1f);
                Destroy(anvilSparks, 2f);
                Destroy(UISparks, 2f);
                particlesSpawned = true;

            }
            if(animationTimer >= 0.63)
            {
                SLAM = false;
                animationTimer = 0;
            }

        }
        //print("Working");
        
    }

    void OnMouseDown()
    {
        if (!SLAM)
        {
            particlesSpawned = false;
            SLAM = true;
            float botdist = gameObject.transform.position.y - bottomPosition.y;
            speed = botdist * 20;
            if (speed < 1)
            {
                timeToWait = 0.35f;
            }
            else
            {
                timeToWait = 0.25f;
            }
            mainCharacterScript.SetAnimation("ToSlam", true);
        }
    }
}
