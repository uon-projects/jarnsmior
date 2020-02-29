using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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

    // Use this for initialization
    void Start ()
    {
        string path = "Assets/JSON/story.json";
        string contents = File.ReadAllText(path);
        textValues = JsonUtility.FromJson<TextChoices>(contents);

        GameObject textShop = GameObject.FindGameObjectWithTag("TextShop");
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
        if (isVisible)
        {
            if (typeWritterEffect.effectEnded && typeWritterEffect.fullText.Length == 0)
            {
                TextChoice mTextChoiceP = getItemByID(textToShow);
                if (mTextChoiceP.child.Capacity == 1 && !mTextChoiceP.choicePick)
                {
                    //choice options
                    print("subchoice");
                    TextChoice mTextChoice = getItemByID(mTextChoiceP.child[0]);
                    typeWritterEffect.fullText = mTextChoice.text;
                    typeWritterEffect.startEffect = true;
                    typeWritterEffect.effectEnded = false;
                    textToShow = mTextChoice.id;
                }
                else if (mTextChoiceP.child.Capacity == 1)
                {
                    //simple conversation
                    print("text");
                    TextChoice mTextChoice = getItemByID(mTextChoiceP.child[0]);
                    typeWritterEffect.fullText = mTextChoice.text;
                    typeWritterEffect.startEffect = true;
                    typeWritterEffect.effectEnded = false;
                    textToShow = mTextChoice.id;
                }
                else if (mTextChoiceP.child.Capacity == 3)
                {
                    //choice options
                    TextChoice mTextChoice1 = getItemByID(mTextChoiceP.child[0]);
                    TextChoice mTextChoice2 = getItemByID(mTextChoiceP.child[1]);
                    TextChoice mTextChoice3 = getItemByID(mTextChoiceP.child[2]);
                    textToShow = mTextChoice2.id;
                    print("choice 1: " + mTextChoice1.text);
                    print("choice 2: " + mTextChoice2.text);
                    print("choice 3: " + mTextChoice3.text);
                } 

                /*if (textValues.story_line[textToShow + 1].choice == -1 && textValues.story_line[textToShow + 1].child.Capacity == 1)
                {
                    typeWritterEffect.fullText = textValues.story_line[textToShow].text;
                    textToShow = textValues.story_line[textToShow].child[0];
                }
                else if (textValues.story_line[textToShow].choicePick && textValues.story_line[textToShow].child.Capacity == 3)
                {
                    print("choice 1: " + textValues.story_line[textToShow + 1].text);
                    print("choice 2: " + textValues.story_line[textToShow + 2].text);
                    print("choice 3: " + textValues.story_line[textToShow + 3].text);
                }
                else if (!textValues.story_line[textToShow].choicePick)
                {
                    print("choice text 1: " + textValues.story_line[textToShow + 1].text);
                    print("choice text 2: " + textValues.story_line[textToShow + 2].text);
                    print("choice text 3: " + textValues.story_line[textToShow + 3].text);
                }*/
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
	}

    public void MakeVisible(bool visibile)
    {
        isVisible = visibile;
        setVisibility();
    }
}
