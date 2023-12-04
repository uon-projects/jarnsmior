using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SF_Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
 
	bool isChoice = false;

    private GameManager mGameManager;

	private int msgID;

	void Start ()
	{
        mGameManager = (GameManager)GameObject.FindGameObjectWithTag("SF_GameManager").GetComponent(typeof(GameManager));
	}
	

	public void setChoice(bool isChoice)
	{
		this.isChoice = isChoice;
	}
     public void OnPointerDown (PointerEventData eventData)
	 {
         // Do action
		if(isChoice)
		{
			mGameManager.OptionSelected(msgID);
        }
     }

	 public void SetID(int msgID)
	 {
		this.msgID = msgID;
	 }
 
     public void OnPointerUp (PointerEventData eventData)
	 {
		if(isChoice)
		{

		}
     }
 
     public void OnPointerEnter(PointerEventData eventData)
     {
		if(isChoice)
		{
			GetComponent<Text>().color = new Color(212.0f/255.0f, 105.0f/255.0f, 17.0f/255.0f);
		}
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
		if(isChoice)
		{
			GetComponent<Text>().color = new Color(240.0f/255.0f, 76.0f/255.0f, 31.0f/255.0f);
		}
     }

 }
