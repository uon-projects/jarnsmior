using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextChoice
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public int id;
    public string text;
    public List<int> child;
    public int choice = -1;
    public bool choicePick;
}

[System.Serializable]
public class TextChoices
{
    public List<TextChoice> story_line;
}

public class TextScript : MonoBehaviour {

    private TextChoices textValues;
    int textToShow = 0;
    public bool isVisible = false;
    private TypeWritterEffect typeWritterEffect;
    private GameObject mChoice1;
    private GameObject mChoice2;
    private GameObject mChoice3;
    // Use this for initialization
    void Start ()
    {
        string path = "Assets/JSON/story.json";
        string contents = File.ReadAllText(path);
        textValues = JsonUtility.FromJson<TextChoices>(contents);

        GameObject textShop = GameObject.FindGameObjectWithTag("TextShop");
        mChoice1 = GameObject.FindGameObjectWithTag("Choice1");
        mChoice2 = GameObject.FindGameObjectWithTag("Choice2");
        mChoice3 = GameObject.FindGameObjectWithTag("Choice3");
        mChoice1.SetActive(false);
        mChoice2.SetActive(false);
        mChoice3.SetActive(false);
        typeWritterEffect = (TypeWritterEffect)textShop.GetComponent(typeof(TypeWritterEffect));

        if (textValues != null)
        {
            for (int i = 0; i < textValues.story_line.Capacity; i++)
            {
                //print(textValues.story_line[i].id + ", " + textValues.story_line[i].text);
            }
        }
        setVisibility();
    }

    public void setVisibility()
    {
        GetComponent<Renderer>().enabled = isVisible;
    }

    void OnMouseDown()
    {
        TextChoice mTextChoiceP = getItemByID(textToShow);
        if (isVisible)
        {
            if (typeWritterEffect.effectEnded && typeWritterEffect.fullText.Length == 0)
            {
                if (mTextChoiceP.child.Capacity == 1)
                {
                    mChoice1.SetActive(false);
                    mChoice2.SetActive(false);
                    mChoice3.SetActive(false);
                    TextChoice mTextChoice = getItemByID(mTextChoiceP.child[0]);
                    if (mTextChoice.choice != -1)
                    {
                        //text after choice
                        typeWritterEffect.fullText = mTextChoice.text;
                        typeWritterEffect.startEffect = true;
                        typeWritterEffect.effectEnded = false;
                        textToShow = mTextChoice.id;
                    }
                    else
                    {
                        //conversation text
                        typeWritterEffect.fullText = mTextChoice.text;
                        typeWritterEffect.startEffect = true;
                        typeWritterEffect.effectEnded = false;
                        textToShow = mTextChoice.id;
                    }
                }
                else if (mTextChoiceP.child.Capacity == 3)
                {
                    //choice options
                    TextChoice mTextChoice1 = getItemByID(mTextChoiceP.child[0]);
                    TextChoice mTextChoice2 = getItemByID(mTextChoiceP.child[1]);
                    TextChoice mTextChoice3 = getItemByID(mTextChoiceP.child[2]);
                    textToShow = mTextChoice2.id;
                    mChoice1.SetActive(true);
                    mChoice2.SetActive(true);
                    mChoice3.SetActive(true);

                    typeWritterEffect.fullText = " ";
                    typeWritterEffect.startEffect = true;
                    typeWritterEffect.effectEnded = false;
                    mChoice1.GetComponent<Text>().text = mTextChoice1.text;
                    mChoice2.GetComponent<Text>().text = mTextChoice2.text;
                    mChoice3.GetComponent<Text>().text = mTextChoice3.text;
                }
            }
        }
    }

    TextChoice getItemByID(int id)
    {
        bool found = false;
        int i = 0;
        while(!found && i<textValues.story_line.Capacity)
        {
            if(textValues.story_line[i].id == id)
            {
                found = true;
            }
            else
            {
                i++;
            }
        }
        return textValues.story_line[i];
    }

    // Update is called once per frame
    void Update () {
		if(isVisible)
        {
            if (!typeWritterEffect.startEffect)
            {
                typeWritterEffect.startEffect = true;
                typeWritterEffect.fullText = textValues.story_line[textToShow].text;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (collider.Raycast(ray, out hit, 100.0F))
            {
                if (hit.collider.gameObject.name == "YourGameObjectName")
                {
                    //Perform action here.
                }
                //Or use 
                if (hit.collider.CompareTag("YourGameObjectTag"))
                {
                    //Perform action here.
                }
            }
        }
    }

    public void MakeVisible(bool visibile)
    {
        isVisible = visibile;
        setVisibility();
    }
}
