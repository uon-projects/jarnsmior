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
    GameObject hammer;
    SpriteRenderer hammerRenderer;
    GameObject metalLength;

    public Sprite upSprite;
    public Sprite downSprite;

    float lengthenAmount;

    char hitCounter;

    float hit1;
    float hit2;
    float hit3;
    float hit4;
    float hit5;
    float hit6;
    float hit7;
    float hit8;
    float hit9;
    float hit10;
    float[] hitStore = new float[10];


    // Use this for initialization
    void Start () 
    {
        hitStore[0] = hit1;
        hitStore[1] = hit2;
        hitStore[2] = hit3;
        hitStore[3] = hit4;
        hitStore[4] = hit5;
        hitStore[5] = hit6;
        hitStore[6] = hit7;
        hitStore[7] = hit8;
        hitStore[8] = hit9;
        hitStore[9] = hit10;

        metalLength = GameObject.FindGameObjectWithTag("MetalLength");
        hammer = GameObject.FindGameObjectWithTag("Hammer");
        hammerRenderer = hammer.GetComponent<SpriteRenderer>();
        particlesSpawned = false;
        SLAM = false;
        upOrDown = false;
        speed = 3;
        topPosition = new Vector3(40.74f, 28.63f, 0);
        bottomPosition = new Vector3(40.74f, 27.53f, 0); 
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
            hammerRenderer.sprite = upSprite;
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

            hammerRenderer.sprite = downSprite;
            if (gameObject.transform.position.y > bottomPosition.y)
            {
                //print("Working");
                transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);
            }
            else if(!particlesSpawned)
            {
                metalLength.transform.localScale += new Vector3(lengthenAmount, 0f, 0f);
                metalLength.transform.position += new Vector3(lengthenAmount / 2, 0f, 0f);
                lengthenAmount = 0;
                GameObject anvilSparks = Instantiate(Particles, new Vector3(39.34f, 29.4f, 0f), transform.rotation); 
                Particles.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
                GameObject UISparks = Instantiate(Particles, new Vector3(41.05f, 30.08f, 0f), transform.rotation);
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
            lengthenAmount += botdist;
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
