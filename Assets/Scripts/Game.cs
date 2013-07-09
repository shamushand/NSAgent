using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	const int PLAYING = 1;		// TimeScale constant for when the game is running.
	const int PAUSED = 0;		// TimeScale constant for when the game is paused.
	
	int menuScale = 20;			// Coefficient of menu button font size to screen width. 
	int sendScale = 5;			// Coefficient of send button font size to screen width. 
	
	int actualScore;
	int rollingScore;
	string scoreText;
	string timeText;
	
	public Font font1;			// Orbitron
	public Font font2;			// Digital Dream	
	public Font font3;			// Courier Bold
	
	public TextAsset messageList;
	
	// Called just before any of the Update methods is called the first time.
	void Start() 
	{
		actualScore = rollingScore = 0;
	}
	
	// Called once per frame.
	void Update() 
	{
		// TODO: Gameloop.
		scoreText = rollingScore.ToString("000000");
		timeText = (30 - Time.timeSinceLevelLoad).ToString("00.00");
	}
	
	public GUISkin customSkin;
	
	// Called for rendering and handling GUI events.
	void OnGUI()
	{
		GUI.skin = customSkin;
		
		GUIStyle menuStyle = new GUIStyle(GUI.skin.label);
		menuStyle.fontSize =  Screen.width / menuScale;	
		menuStyle.alignment = TextAnchor.LowerCenter;
		menuStyle.font = font1;
		
		GUIStyle scoreStyle = new GUIStyle(GUI.skin.label);
		scoreStyle.fontSize =  Screen.width / menuScale;	
		scoreStyle.alignment = TextAnchor.UpperLeft;
		scoreStyle.font = font2;
		
		GUIStyle timeStyle = new GUIStyle(GUI.skin.label);
		timeStyle.fontSize =  Screen.width / menuScale;	
		timeStyle.alignment = TextAnchor.UpperRight;
		timeStyle.font = font2;
		
		GUIStyle sendStyle = new GUIStyle(GUI.skin.button);
		sendStyle.fontSize =  Screen.width / sendScale;
		sendStyle.alignment = TextAnchor.MiddleCenter;
		sendStyle.font = font1;
		
		GUIStyle gameStyle = new GUIStyle(GUI.skin.label);
		gameStyle.fontSize =  Screen.width / 16;
		gameStyle.font = font3;
		gameStyle.wordWrap = false;
		
		GUIStyle pauseStyle = new GUIStyle(GUI.skin.label);
		pauseStyle.fontSize =  Screen.width / 8;	
		pauseStyle.alignment = TextAnchor.UpperCenter;
		pauseStyle.font = font1;
		
		GUI.Box(new Rect(-1.1f * Screen.width/ 16, 0, 1.1f * Screen.width, 1.5f * Screen.height / 24), "");
		GUI.Label(ScaleUI.Score(), scoreText, scoreStyle);
		GUI.Label(ScaleUI.Time(), timeText, timeStyle);
		
		if (GUI.Button(ScaleUI.MenuButton(), "Menu", menuStyle))
				Time.timeScale = (Time.timeScale == PAUSED) ? PLAYING : PAUSED;
			
		if (Time.timeScale == PAUSED)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

			if (GUI.Button(ScaleUI.PauseButton1(), "Resume", pauseStyle)) 
			{
				Time.timeScale = PLAYING;
			}
			if (GUI.Button(ScaleUI.PauseButton2(), "Quit", pauseStyle)) 
			{
				Time.timeScale = PLAYING;
				Application.LoadLevel("Main Menu");
			}	
		}
		else
		{
			if (rollingScore < actualScore)
				rollingScore += 4;
			
			MessageHandler mailMan = new MessageHandler();
			ArrayList wordButtons = mailMan.NextMessage(messageList);
			
			foreach (Word word in wordButtons)
				if(GUI.Button(word.button, word.ToString(), gameStyle))
					actualScore += word.Press();
			
			if (GUI.Button(ScaleUI.SendButton(), "Send", sendStyle))
				actualScore += 100;
		}
	}
}
