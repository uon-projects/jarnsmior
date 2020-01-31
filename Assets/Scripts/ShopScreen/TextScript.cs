using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextChoice
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public int id;
    public string text;
    public List<int> child;
    public int choice;
    public bool choicePick;
}

public class TextChoices
{
    public List<TextChoice> story_line;
}

public class TextScript : MonoBehaviour {

    public TextChoices shipTypes;
    // Use this for initialization
    void Start ()
    {
        string path = "Assets/JSON/story.json";
        string contents = File.ReadAllText(path);
        shipTypes = JsonUtility.FromJson<TextChoices>(contents);
        
        for(int i=0; i<shipTypes.story_line.Capacity; i++)
        {
            print(shipTypes.story_line[i].id);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
