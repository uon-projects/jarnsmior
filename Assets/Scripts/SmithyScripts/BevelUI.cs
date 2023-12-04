using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevelUI : MonoBehaviour {

    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    public Vector3 _rotation;
    private bool _isRotating;

    Vector3 anchorPosition;
    float offset;
    float offsetDirection = 1;

    Transform hammerPivot;
    Transform hammerHead;

    bool canSmith = true;
    bool slam = false;
    bool slamComplete = false;
    int counter = 0;
    float timeToWait = 0.2f;
    float animationTimer;
    float speed = 2f;
    float[] hitStore = new float[10];

    bool particlesSpawned;
    public GameObject worldParticles;
    public GameObject UIParticles;
    GameObject heatUI;
    MCFurnace myFurnace;

    GameObject wedge;
    SpriteRenderer wedgeRenderer;
    public Sprite half;
    public Sprite full;

    AudioSource myAudioSource;

    WallHanger myWallHanger;
    S_GameManager myGameManager;

    // Use this for initialization
    void Start()
    {
        GameObject theWallHanger = GameObject.FindGameObjectWithTag("WallHanger");
        myWallHanger = (WallHanger)theWallHanger.GetComponent(typeof(WallHanger));
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myGameManager = S_GameManager.GetGameManagerScript();

        wedge = GameObject.FindGameObjectWithTag("Wedge");
        wedgeRenderer = wedge.GetComponent<SpriteRenderer>();
        heatUI = GameObject.FindGameObjectWithTag("HeatUI");
        myFurnace = (MCFurnace)heatUI.GetComponentInChildren(typeof(MCFurnace));
        _sensitivity = 0.2f;
        _rotation = Vector3.zero;
        Transform[] hammers = GetComponentsInChildren<Transform>();
        foreach (Transform hammer in hammers)
        {
            if (hammer.gameObject.transform.localPosition.y == 1.05f)
            {
                hammerPivot = hammer; //this gameObject is a child, because its transform.parent is not null
            }
        }
        Transform[] hammers2 = hammerPivot.GetComponentsInChildren<Transform>();
        foreach (Transform hammer2 in hammers2)
        {
            if (hammer2.gameObject.transform.localPosition.y > 4f)
            {
                hammerHead = hammer2; //this gameObject is a child, because its transform.parent is not null
            }
        }
    }

    void Update()
    {

        if(canSmith)
        {
            myGameManager.SetTutorialState(S_GameManager.TutorialState.Bevelling);
            if(slam)
            {
                SlamDown();
                
            }
            else
            {
                if (counter >= 10)
                {

                    canSmith = false;

                }
                CalculateRotation();
                hammerPivot.localRotation = transform.rotation;
            }
        }

    }
    void CalculateRotation()
    {

        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.z = (-_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            // rotate
            if (_rotation.z + gameObject.transform.rotation.eulerAngles.z > 45f)
            {
                transform.rotation = Quaternion.AngleAxis(44.9f, new Vector3(0f, 0f, 44.9f));
            }
            else if (_rotation.z + gameObject.transform.rotation.eulerAngles.z < 0f)
            {

                transform.rotation = new Quaternion(0f, 0f, 0.1f, 90f);

            }
            else
            {
                transform.Rotate(_rotation);
            }

            // store mouse
            _mouseReference = Input.mousePosition;
        }
        else
        {
            CalculateOffset();
            if (offset + anchorPosition.z < 45 && offset + anchorPosition.z > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, (anchorPosition.z + offset));
            }
            else
            {

                offsetDirection = -offsetDirection;

            }

        }
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
        offset = 0f;
        offsetDirection = 1f;
        anchorPosition = transform.rotation.eulerAngles;
    }

    void CalculateOffset()
    {
        float speed = (5 - Mathf.Abs(offset));
        if (offset > 3.75f)
        {
            offsetDirection = -1f;
        }
        else if (offset < -3.75f)
        {
            offsetDirection = 1f;
        }
        offset += offsetDirection * speed * Time.deltaTime;
    }

    public float BeginSlam()
    {
        myAudioSource.Play();
        if (!slam)
        {
            slam = true;

            hitStore[counter] = transform.rotation.eulerAngles.z;
            myFurnace.CheckTemp();
            Debug.Log(hitStore[counter]);
            counter += 1;
            
            if (counter >= 10)
            {
                CalculateScore();
            }
            return hitStore[counter-1];

        }

        return 0;
    }
    public bool GetSlam()
    {

        return slam;

    }
    void SlamDown()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer >= timeToWait)
        {

            if (hammerHead.transform.position != hammerPivot.transform.position && !slamComplete)
            {  
                hammerHead.transform.position = Vector3.MoveTowards(hammerHead.transform.position, hammerPivot.transform.position, 20 * Time.deltaTime);
                if (hammerHead.transform.position == hammerPivot.transform.position)
                {
                    slamComplete = true;
                    if (counter == 4)
                    {

                        wedgeRenderer.sprite = half;

                    }
                    else if (counter == 8)
                    {

                        wedgeRenderer.sprite = full;

                    }
                }
            }
            else if (!particlesSpawned)
            {

                particlesSpawned = true;
                Instantiate(worldParticles, new Vector3(9.93f, 4.49f, 0f), worldParticles.transform.rotation);
                Instantiate(UIParticles, hammerPivot.transform.position, worldParticles.transform.rotation);
                //Instantiate(particles, new Vector3(7.68f, 4.31f, 0f), transform.rotation);
                //particles.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

            }
            else if(animationTimer < 0.45f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0f, 0f, 0.01f, 90f), 0.05f);
                hammerHead.transform.position = Jitter(hammerHead.transform.position);
                transform.localPosition = Jitter(transform.localPosition);
            }
            else if(animationTimer > 0.55f)
            {
                if (hammerHead.transform.localPosition.y < 6.64f)
                {
                    
                    hammerHead.transform.localPosition += new Vector3(0f, 0.25f, 0f);
                }
            }
            else
            {

                transform.localPosition = new Vector3(0f, 0f, 0f);

            }

            if (animationTimer >= 1f)
            {
                anchorPosition = transform.rotation.eulerAngles;
                offset = 0;
                slamComplete = false;
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
    void CalculateScore()
    {
        float totalVal;
        float consistencyVal = 0;
        float totalScore = 0;
        float calculator = 0;
        float maxVal = 0;
        float minVal = 10000;
        float angleScore = 0;
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
        totalScore += 50 - consistencyVal;
        angleScore = Mathf.Abs(15 - calculator);
        angleScore = 50 - angleScore;
        totalScore += angleScore;
        print(consistencyVal);
        print(calculator);
        print(totalScore);
        

        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        QuenchUI myQuenchUI = (QuenchUI)scoreManager.GetComponent(typeof(QuenchUI));
        S_GameManager mGameManager = S_GameManager.GetGameManagerScript();
        mGameManager.SetGameState(S_GameManager.GameState.BarBevelled);
        myQuenchUI.SetValues(1, totalScore, 100);



    }

    Vector3 Jitter(Vector3 anchor)
    {

        Vector3 jitter = new Vector3(Random.Range(-0.02f, 0.02f), Random.Range(-0.05f, 0.05f), 0);
        return anchor + jitter;

    }
}
