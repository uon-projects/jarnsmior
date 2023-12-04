using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    // Use this for initialization
    bool toMove;
    float moveTime;
    int numberOfTargets;
    Vector3[] targets = { new Vector3(0f, 0f, -10f), new Vector3(0f, 0f, -10f), new Vector3(0f, 0f, -10f) };

    Vector3 defaultPosition = new Vector3(11.45f, 7.31f, -10);

    float toZoom;
    bool zoomDir;


    private Camera gameCamera;

    GameObject beams;
    SpriteRenderer beamRenderer;

    void Start ()
    {

        beams = GameObject.FindGameObjectWithTag("beam");
        beamRenderer = beams.GetComponent<SpriteRenderer>();
        gameCamera = gameObject.GetComponent<Camera>();
        gameCamera.transform.position = new Vector3(3.02f, 11.05f, -10f);
        gameCamera.orthographicSize = 1.354f;
        SetTarget(new Vector3(11.45f, 7.31f, -10f), 6.31f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(toMove)
        {

            transform.position = Vector3.MoveTowards(transform.position, targets[numberOfTargets], 3f * Time.deltaTime);
            if(transform.position == targets[numberOfTargets])
            {

                numberOfTargets -= 1;
                if(numberOfTargets == 0)
                {

                    toMove = false;

                }

            }

        }
        if (Mathf.Abs(toZoom - gameCamera.orthographicSize) > 0.02f)
        {

            if(!zoomDir)
            {

                float opacity = gameCamera.orthographicSize / 6.3f;   
                beamRenderer.color = new Color(1f, 1f, 1f, opacity);              
                gameCamera.orthographicSize += 0.02f;

            }
            else
            {
                float opacity = gameCamera.orthographicSize / 6.3f;
                beamRenderer.color = new Color(1f, 1f, 1f, opacity);
                gameCamera.orthographicSize -= 0.02f;   
            }
        }
        else
        {
            gameCamera.orthographicSize = toZoom;
        }
	}

    public void SetTarget(Vector3 target, float zoom)
    {
        targets[1] = target;
        toMove = true;
        toZoom = zoom;
        if (toZoom > gameCamera.orthographicSize)
        {

            zoomDir = false;

        }
        else
        {

            zoomDir = true;

        }
        numberOfTargets = 1;
    }
    public void SetTarget(Vector3 target1, Vector3 target2, float zoom)
    {

        targets[1] = target2;
        targets[2] = target1;
        toMove = true;
        toZoom = zoom;
        if(toZoom > gameCamera.orthographicSize)
        {

            zoomDir = false;

        }
        else
        {

            zoomDir = true;

        }
        numberOfTargets = 2;
    }

    public void SetPosition(Vector3 position, float toZoom)
    {

        gameCamera.transform.position = position;
        gameCamera.orthographicSize = toZoom;

    }

}
