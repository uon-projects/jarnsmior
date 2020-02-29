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
    public int choice;
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
	
	// Update is called once per frame
	void Update () {
		if(isVisible && !typeWritterEffect.startEffect)
        {
            typeWritterEffect.startEffect = true;
            typeWritterEffect.fullText = textValues.story_line[textToShow].text;
            print(textValues.story_line[textToShow].text);
        }
	}

    public void MakeVisible(bool visibile)
    {
        isVisible = visibile;
        setVisibility();
    }
}
