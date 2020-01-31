using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWritterEffect : MonoBehaviour {

    public float delay = 0.2f;
    public string fullText;
    private string currentText = "";
    public bool startEffect = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(startEffect)
        {
            StartCoroutine(ShowText());
        }
	}

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

}
