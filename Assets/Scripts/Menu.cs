using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	float xScale = 16;			// How many units the width of the screen is divided into.
	float yScale = 24;			// How many units the height of the screen is divided into.
	float titleScale = 5.75f;	// Coefficient of title font size to screen width.
	float subtitleScale = 10f;	// Coefficient of subtitle font size to screen width.
	int menuScale = 8;			// Coefficient of menu font size to screen width.
	
	public Font munro;
	
	// Called just before any of the Update methods is called the first time.
	void Start()
	{
		// Title text
		float titleHeight = 1 - (3 / yScale);
		float subtitleHeight = 1 - (4.5f / yScale);
		
		// Main title
		GameObject title = GameObject.Find("Title");
		title.GetComponent<GUIText>().transform.position = new Vector3(0.5f, titleHeight, 0);
		title.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / titleScale);
		title.GetComponent<GUIText>().guiText.text = "NSAgent";
		
		// Subtitle
		GameObject subtitle = GameObject.Find ("Subtitle");
		subtitle.GetComponent<GUIText>().transform.position = new Vector3(0.5f, subtitleHeight, 0);
		subtitle.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / subtitleScale);
		subtitle.GetComponent<GUIText>().guiText.text = "American Defender";
	}
	
	// Called for rendering and handling GUI events.
	void OnGUI() 
	{
		// Background box
		GUI.Box(ScaleUI.MenuBackground(), "");
				
		// Menu buttons
		// http://answers.unity3d.com/questions/344493/change-font-size-through-script.html
		GUIStyle scaled = new GUIStyle(GUI.skin.button);
		scaled.fontSize = Screen.width / menuScale;
		scaled.font = munro;
		
		if (GUI.Button(ScaleUI.MenuButton1(), "Start", scaled)) 
		{
			Application.LoadLevel("Game");
		}
		if (GUI.Button(ScaleUI.MenuButton2(), "Word Bank", scaled)) 
		{
			Application.LoadLevel("Word Bank");
		}	
		if (GUI.Button(ScaleUI.MenuButton3(), "Settings", scaled)) 
		{
			Application.LoadLevel("Main Menu");
		}
		if (GUI.Button(ScaleUI.MenuButton4(), "Credits", scaled)) 
		{
			Application.LoadLevel("Credits");
		}	
	}
}