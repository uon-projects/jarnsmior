using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {



    public Sprite[] pages;

    int currentPage = 0;
    SpriteRenderer myRenderer;

    GameObject mainCharacter;

    CameraScript cameraScript;
    MainCharacterSmithy mainCharacterScript;
    AudioSource myAudioSource;
    AudioSource closeAudioSource;

    // Use this for initialization
    void Start ()
    {
        AudioSource[] bookArray = gameObject.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource book in bookArray)
        {
            if (book.gameObject.transform.parent.localPosition.x == 21.55f)
            {
                closeAudioSource = book;
            }
        }
        myAudioSource = GetComponent<AudioSource>();
        myRenderer = GetComponent<SpriteRenderer>();
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ModifyPage(int goToPage)
    {

        myRenderer.sprite = pages[goToPage];
        currentPage = goToPage;

    }

    public void GoToChapter(int chapter)
    {
        myAudioSource.Play();
        if (currentPage == 0)
        {
            myRenderer.sprite = pages[chapter];
            currentPage = chapter;
        } else if(chapter == 0 && currentPage != 0)
        {
            myRenderer.sprite = pages[chapter];
            currentPage = chapter;
        }
    }

    public void ModifyPage(bool switchPage)
    {
        
        if (switchPage && currentPage < pages.Length - 1)
        {
            myAudioSource.Play();
            currentPage += 1;

        }
        else if(!switchPage && currentPage > 0)
        {
            myAudioSource.Play();
            currentPage -= 1;

        }
        else if(!switchPage && currentPage == 0)
        {
            closeAudioSource.Play();
            mainCharacter.SetActive(true);
            mainCharacterScript.SetControl(true);
            cameraScript.SetPosition(new Vector3(2.56f, 5.49f, -10f), 0.68f);
            cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6);

        }

        myRenderer.sprite = pages[currentPage];
    }

    void OnMouseDown()
    {
        closeAudioSource.Play();
        mainCharacter.SetActive(true);
        mainCharacterScript.SetControl(true);
        cameraScript.SetPosition(new Vector3(2.56f, 5.49f, -10f), 0.68f);
        cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6);
    }
}
