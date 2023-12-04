using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ElongateUI : MonoBehaviour {

    float speed;
    Vector3 bottomPosition;
    Vector3 topPosition;
    bool direction;

    float animationTimer;
    float timeToWait;

    bool slam;
    bool canSmith = true;

    float[] hitStore = new float[10];
    int counter = 0;

    float consistencyVal;
    float totalVal;
    float totalScore;

    public GameObject worldParticles;
    public GameObject UIParticles;
    public Sprite hammerUp;
    public Sprite hammerDown;
    bool particlesSpawned= false;

    SpriteRenderer hammerRenderer;

    GameObject heatUI;
    MCFurnace myFurnace;
    AudioSource myAudioSource;

    WallHanger myWallHanger;
    S_GameManager myGameManager;

    // Use this for initialization
    void Start ()
    {
        GameObject theWallHanger = GameObject.FindGameObjectWithTag("WallHanger");
        myWallHanger = (WallHanger)theWallHanger.GetComponent(typeof(WallHanger));
        myAudioSource = gameObject.GetComponent<AudioSource>();
        heatUI = GameObject.FindGameObjectWithTag("HeatUI");
        myFurnace = (MCFurnace)heatUI.GetComponentInChildren(typeof(MCFurnace));
        myGameManager = S_GameManager.GetGameManagerScript();

        topPosition = new Vector3(6.54f, 5.204f);
        bottomPosition = new Vector3(6.54f, 3.41f);

        SpriteRenderer[] uiSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer uiSprite in uiSprites)
        {
            if (uiSprite.gameObject.transform.parent != null)
            {
                hammerRenderer = uiSprite; //this gameObject is a child, because its transform.parent is not null
            }
        }


	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canSmith)
        {
            myGameManager.SetTutorialState(S_GameManager.TutorialState.Elongation);
            if (!slam)
            {
                CalculateSpeed();
                Move();
                if (counter >= 10)
                {

                    canSmith = false;

                }
            }
            else
            {

                SlamDown();

            }
        }
	}

    void CalculateSpeed()
    {

        float botdist = gameObject.transform.position.y - bottomPosition.y;
        float topdist = topPosition.y - gameObject.transform.position.y;

        if (botdist > topdist)
        {
            speed = topdist * 2;
        }
        else
        {
            speed = botdist * 2;
        }

        if (speed < 0.25f)
        {
            speed = 0.25f;
        }

    }

    void Move()
    {

        if (direction)
        {

            if (gameObject.transform.position.y < topPosition.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, topPosition, speed * Time.deltaTime);
            }
            else
            {
                direction = false;
            }
        }
        else if (gameObject.transform.position.y > bottomPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);
        }
        else
        {
            direction = true;
        }

    }

    void SlamDown()
    {
        animationTimer += Time.deltaTime;
        
        if (animationTimer >= timeToWait)
        {
            
            if (gameObject.transform.position.y > bottomPosition.y)
            {
                hammerRenderer.sprite = hammerDown;
                transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);
                
            }
            else if(!particlesSpawned)
            {
                
                particlesSpawned = true;
                Instantiate(worldParticles, new Vector3(8.6f, 4.49f, 0f), worldParticles.transform.rotation);
                Instantiate(UIParticles, new Vector3(6.54f, 4.41f, 0f), worldParticles.transform.rotation);
                //Instantiate(particles, new Vector3(7.68f, 4.31f, 0f), transform.rotation);
                //particles.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

            }

            if (animationTimer >= 0.63)
            {
                hammerRenderer.sprite = hammerUp;
                slam = false;
                animationTimer = 0;
                particlesSpawned = false;
                if (counter >= 10)
                {
                    myWallHanger.TriggerExit();

                }

            }

        }

    }

    public bool GetSlam()
    {

        return slam;

    }

    public float BeginSlam()
    {
        myAudioSource.Play();
        if (!slam)
        {
            slam = true;
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

            hitStore[counter] = botdist;
            myFurnace.CheckTemp();
            counter += 1;
            if (counter >= 10)
            {
                CalculateScore();               
            }
            return botdist;

        }

        return 0;
    }
    
    void CalculateScore()
    {
        float calculator = 0;
        float maxVal = 0;
        float minVal = 10000;
        float lengthVal = 0;
        for (int i = 0; i < 10; i++)
        {
            if (hitStore[i] > maxVal)
            {

                maxVal = hitStore[i];

            }
            if (hitStore[i] < minVal)
            {
                minVal = hitStore[i];
            }

            calculator += hitStore[i];

        }
        
        totalVal = calculator;
        calculator = totalVal / 10;
        consistencyVal += Mathf.Abs(calculator - minVal);
        consistencyVal += Mathf.Abs(calculator - maxVal);
        totalScore += 50 - (consistencyVal * 25);
        lengthVal = totalVal;
        lengthVal = lengthVal / 13f;
        if(lengthVal > 1f)
        {
            lengthVal = 1 / lengthVal;
        }
        lengthVal = lengthVal * 50;
        totalScore += lengthVal;

        print(totalVal);
        print(lengthVal);
        print(totalScore);
        S_GameManager mGameManager = S_GameManager.GetGameManagerScript();
        mGameManager.SetGameState(S_GameManager.GameState.BarElongated);
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        QuenchUI myQuenchUI = (QuenchUI)scoreManager.GetComponent(typeof(QuenchUI));
        GameObject sword = GameObject.FindGameObjectWithTag("Sword");
        PlayerPrefs.SetFloat("SwordLength", lengthVal/50);
        myQuenchUI.SetValues(0, totalScore, 100);
        


    } 

    public int GetCounter()
    {

        return counter;

    }


}
