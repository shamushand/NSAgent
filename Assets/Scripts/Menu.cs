using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	float xScale = 16;			// How many units the width of the screen is divided into.
	float yScale = 24;			// How many units the height of the screen is divided into.
	float titleScale = 5.75f;	// Coefficient of screen width to title font size.
	float subtitleScale = 10f;	// Coefficient of screen width to subtitle font size.
	
	float buttonOffset;
	float buttonWidth;
	float buttonHeight;
	
	float button1Top;
	float button2Top;
	float button3Top;
	float button4Top;
	
	string button1Text;
	string button2Text;
	string button3Text;
	string button4Text;
	
	float backgroundBoxOffset;
	float backgroundBoxTop;
	float backgroundBoxWidth;
	float backgroundBoxHeight;
	
	public Font munro;
	
	// Called just before any of the Update methods is called the first time.
	void Start()
	{
		// Title text
		GameObject title = GameObject.Find("Title");
		GameObject subtitle = GameObject.Find ("Subtitle");
		title.GetComponent<GUIText>().transform.position = new Vector3(0.5f, 1 - (3 / yScale), 0);
		title.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / titleScale);
		subtitle.GetComponent<GUIText>().transform.position = new Vector3(0.5f, 1 - (4.5f / yScale), 0);
		subtitle.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / subtitleScale);
		
		// Menu buttons	
		buttonOffset = 2f * Screen.width / xScale;
		buttonWidth = 12f * Screen.width / xScale;
		buttonHeight = 2.5f * Screen.height / yScale;
		
		// Button 1 - Play
		button1Top  = 9f * Screen.height / yScale;
		button1Text = "Play";
		
		// Button 2 - Word Bank
		button2Top  = 12.5f * Screen.height / yScale; 
		button2Text = "Word Bank";
		
		// Button 3 - Settings
		button3Top  = 16f * Screen.height / yScale;
		button3Text = "Settings";
		
		// Button 4 - Credits
		button4Top  = 19.5f * Screen.height / yScale;
		button4Text = "Credits";
		
		// Background box
		backgroundBoxOffset = Screen.width / xScale;
		backgroundBoxTop = 8f * Screen.height / yScale;
		backgroundBoxWidth = 14f * Screen.width / xScale;
		backgroundBoxHeight = 15f * Screen.height / yScale;
	}
	
	// Called for rendering and handling GUI events.
	void OnGUI () 
	{
		// Background box
		GUI.Box(new Rect(backgroundBoxOffset, backgroundBoxTop, backgroundBoxWidth, backgroundBoxHeight), "");
				
		// Menu buttons
		// http://answers.unity3d.com/questions/344493/change-font-size-through-script.html
		GUIStyle scaled = new GUIStyle(GUI.skin.button);
		scaled.fontSize = Screen.width / 8;
		scaled.font = munro;
		
		if (GUI.Button(new Rect(buttonOffset, button1Top, buttonWidth, buttonHeight), button1Text, scaled)) 
		{
			Application.LoadLevel("Intro");
		}
		if (GUI.Button(new Rect(buttonOffset, button2Top, buttonWidth, buttonHeight), button2Text, scaled)) 
		{
			Application.LoadLevel("Main Menu");
		}	
		if (GUI.Button(new Rect(buttonOffset, button3Top, buttonWidth, buttonHeight), button3Text, scaled)) 
		{
			Application.LoadLevel("Main Menu");
		}
		if (GUI.Button(new Rect(buttonOffset, button4Top, buttonWidth, buttonHeight), button4Text, scaled)) 
		{
			Application.LoadLevel("Main Menu");
		}	
	}
}
