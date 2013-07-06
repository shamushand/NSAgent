using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	float xScale = 16;			// How many units the width of the screen is divided into.
	float yScale = 24;			// How many units the height of the screen is divided into.
	float titleScale = 5.75f;	// Coefficient of title font size to screen width.
	float subtitleScale = 10f;	// Coefficient of subtitle font size to screen width.
	int menuScale = 8;			// Coefficient of menu font size to screen width.
	
	float buttonOffset;
	float buttonWidth;
	float buttonHeight;
	
	string button1Text;
	float button1Top;
	Rect button1;
	
	string button2Text;
	float button2Top;
	Rect button2;
	
	string button3Text;
	float button3Top;
	Rect button3;
	
	string button4Text;
	float button4Top;
	Rect button4;
	
	string backgroundText;
	float backgroundOffset;
	float backgroundTop;
	float backgroundWidth;
	float backgroundHeight;
	Rect background;
	
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
		
		// Menu buttons	
		buttonOffset = 2f * Screen.width / xScale;
		buttonWidth = 12f * Screen.width / xScale;
		buttonHeight = 2.5f * Screen.height / yScale;
		
		// Button 1 - Play
		button1Top  = 9f * Screen.height / yScale;
		button1Text = "Play";
		button1 = new Rect(buttonOffset, button1Top, buttonWidth, buttonHeight);
		
		// Button 2 - Word Bank
		button2Top  = 12.5f * Screen.height / yScale; 
		button2Text = "Word Bank";
		button2 = new Rect(buttonOffset, button2Top, buttonWidth, buttonHeight);
		
		// Button 3 - Settings
		button3Top  = 16f * Screen.height / yScale;
		button3Text = "Settings";
		button3 = new Rect(buttonOffset, button3Top, buttonWidth, buttonHeight);
		
		// Button 4 - Credits
		button4Top  = 19.5f * Screen.height / yScale;
		button4Text = "Credits";
		button4 = new Rect(buttonOffset, button4Top, buttonWidth, buttonHeight);
		
		// Background box
		backgroundOffset = Screen.width / xScale;
		backgroundTop = 8f * Screen.height / yScale;
		backgroundWidth = 14f * Screen.width / xScale;
		backgroundHeight = 15f * Screen.height / yScale;
		backgroundText = "";
		background = new Rect(backgroundOffset, backgroundTop, backgroundWidth, backgroundHeight);
	}
	
	// Called for rendering and handling GUI events.
	void OnGUI() 
	{
		// Background box
		GUI.Box(background, backgroundText);
				
		// Menu buttons
		// http://answers.unity3d.com/questions/344493/change-font-size-through-script.html
		GUIStyle scaled = new GUIStyle(GUI.skin.button);
		scaled.fontSize = Screen.width / menuScale;
		scaled.font = munro;
		
		if (GUI.Button(button1, button1Text, scaled)) 
		{
			Application.LoadLevel("Game");
		}
		if (GUI.Button(button2, button2Text, scaled)) 
		{
			Application.LoadLevel("Word Bank");
		}	
		if (GUI.Button(button3, button3Text, scaled)) 
		{
			Application.LoadLevel("Main Menu");
		}
		if (GUI.Button(button4, button4Text, scaled)) 
		{
			Application.LoadLevel("Credits");
		}	
	}
}