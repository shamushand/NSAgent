using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	const int PLAYING = 1;		// TimeScale constant for when the game is running.
	const int PAUSED = 0;		// TimeScale constant for when the game is paused.
	
	float xScale = 16;			// How many units the width of the screen is divided into.
	float yScale = 24;			// How many units the height of the screen is divided into.
	int menuScale = 20;			// Coefficient of menu button font size to screen width. 
	int sendScale = 5;			// Coefficient of send button font size to screen width. 
	
	float menuButtonOffset;
	float menuButtonTop;
	float menuButtonWidth;
	float menuButtonHeight;
	string menuButtonText;
	Rect menuButton;
	
	float sendButtonOffset;
	float sendButtonTop;
	float sendButtonWidth;
	float sendButtonHeight;
	string sendButtonText;
	Rect sendButton;
	
	string scoreText;
	float scoreOffset;
	float scoreTop;
	float scoreWidth;
	float scoreHeight;
	Rect scoreLabel;
	
	string timeText;
	float timeOffset;
	float timeTop;
	float timeWidth;
	float timeHeight;
	Rect timeLabel;
	
	float pauseButtonOffset;
	float pauseButtonWidth;
	float pauseButtonHeight;
	
	float pauseButton1Top;
	string pauseButton1Text;
	Rect pauseButton1;

	float pauseButton2Top; 
	string pauseButton2Text;
	Rect pauseButton2;
	
	public Font munro;

	// Called just before any of the Update methods is called the first time.
	void Start() 
	{
		/////////////
		// Game UI //
		/////////////
		
		// Score label
		scoreOffset = Screen.width / xScale;
		scoreTop = Screen.height / (4 * yScale);
		scoreWidth = 5f * Screen.width / xScale;
		scoreHeight = Screen.height / yScale;
		scoreLabel = new Rect(scoreOffset, scoreTop, scoreWidth, scoreHeight);
		scoreText = "Score: 0000123";
		
		// Menu button
		menuButtonOffset = 6.5f * Screen.width / xScale;
		menuButtonTop = Screen.height / (4 * yScale);
		menuButtonWidth = 3 * Screen.width / xScale;
		menuButtonHeight = Screen.height / yScale;
		menuButtonText = "Menu";
		menuButton = new Rect(menuButtonOffset, menuButtonTop, menuButtonWidth, menuButtonHeight);
		
		// Time label
		timeOffset = 10 * Screen.width / xScale;
		timeTop = Screen.height / (4 * yScale);
		timeWidth = 5f * Screen.width / xScale;
		timeHeight = Screen.height / yScale;
		timeLabel = new Rect(timeOffset, timeTop, timeWidth, timeHeight);
		timeText = "0:30";
		
		// Send button
		sendButtonOffset = Screen.width / xScale;
		sendButtonTop = 20 * Screen.height / yScale;
		sendButtonWidth = 14 * Screen.width / xScale;
		sendButtonHeight = 3 * Screen.height / yScale;
		sendButtonText = "Send";
		sendButton = new Rect(sendButtonOffset, sendButtonTop, sendButtonWidth, sendButtonHeight);
		
		////////////////
		// Pause menu //
		////////////////
		
		// Pause menu buttons
		pauseButtonOffset = 2f * Screen.width / xScale;
		pauseButtonWidth = 12f * Screen.width / xScale;
		pauseButtonHeight = 2.5f * Screen.height / yScale;
		
		// Button 1 - Resume
		pauseButton1Top  = 9f * Screen.height / yScale;
		pauseButton1Text = "Resume";
		pauseButton1 = new Rect(pauseButtonOffset, pauseButton1Top, pauseButtonWidth, pauseButtonHeight);
			
		// Button 2 - Quit
		pauseButton2Top  = 12.5f * Screen.height / yScale; 
		pauseButton2Text = "Quit";
		pauseButton2 = new Rect(pauseButtonOffset, pauseButton2Top, pauseButtonWidth, pauseButtonHeight);
		
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		// TODO: Gameloop.
	}
	
	// Called for rendering and handling GUI events.
	void OnGUI()
	{
		GUIStyle menuStyle = new GUIStyle(GUI.skin.button);
		menuStyle.fontSize =  Screen.width / menuScale;	
		menuStyle.font = munro;
		
		GUIStyle sendStyle = new GUIStyle(GUI.skin.button);
		sendStyle.fontSize =  Screen.width / sendScale;	
		sendStyle.font = munro;
		
		if (GUI.Button(menuButton, menuButtonText, menuStyle))
			Time.timeScale = (Time.timeScale == PAUSED) ? PLAYING : PAUSED;
		
		
		if (Time.timeScale == PAUSED)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

			if (GUI.Button(pauseButton1, pauseButton1Text, menuStyle)) 
			{
				Time.timeScale = PLAYING;
			}
			if (GUI.Button(pauseButton2, pauseButton2Text, menuStyle)) 
			{
				Time.timeScale = PLAYING;
				Application.LoadLevel("Main Menu");
			}	
		}
		else
		{
			GUI.Label(scoreLabel, scoreText, menuStyle);
			GUI.Label(timeLabel, timeText, menuStyle);
			if (GUI.Button(sendButton, sendButtonText, sendStyle))
			; // TODO: the game!
		}
	}
}
