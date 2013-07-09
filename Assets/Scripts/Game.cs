using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	const int PLAYING = 1;		// TimeScale constant for when the game is running.
	const int PAUSED = 0;		// TimeScale constant for when the game is paused.
	
	int menuScale = 20;			// Coefficient of menu button font size to screen width. 
	int sendScale = 5;			// Coefficient of send button font size to screen width. 
	int score;
	
	string scoreText;
	string timeText;
	
	public Font munro;
	public Font digitalDream;
	public Font courier;

	// Called just before any of the Update methods is called the first time.
	void Start() 
	{
		score = 0;
	}
	
	// Called once per frame.
	void Update() 
	{
		// TODO: Gameloop.
		scoreText = score.ToString("0000000");
		timeText = Time.timeSinceLevelLoad.ToString("00.0");
	}
	
	// Called for rendering and handling GUI events.
	void OnGUI()
	{
		GUIStyle menuStyle = new GUIStyle(GUI.skin.label);
		menuStyle.fontSize =  Screen.width / menuScale;	
		menuStyle.alignment = TextAnchor.UpperCenter;
		menuStyle.font = munro;
		
		GUIStyle scoreStyle = new GUIStyle(GUI.skin.label);
		scoreStyle.fontSize =  Screen.width / menuScale;	
		scoreStyle.alignment = TextAnchor.UpperLeft;
		scoreStyle.font = munro;
		
		GUIStyle timeStyle = new GUIStyle(GUI.skin.label);
		timeStyle.fontSize =  Screen.width / menuScale;	
		timeStyle.alignment = TextAnchor.UpperRight;
		timeStyle.font = digitalDream;
		
		GUIStyle sendStyle = new GUIStyle(GUI.skin.label);
		sendStyle.fontSize =  Screen.width / sendScale;
		sendStyle.alignment = TextAnchor.UpperCenter;
		sendStyle.font = munro;
		
		GUIStyle gameStyle = new GUIStyle(GUI.skin.label);
		gameStyle.fontSize =  Screen.width / 16;
		gameStyle.font = courier;
		
		GUIStyle pauseStyle = new GUIStyle(GUI.skin.label);
		pauseStyle.fontSize =  Screen.width / 8;	
		pauseStyle.alignment = TextAnchor.UpperCenter;
		pauseStyle.font = munro;
		
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
			if (GUI.Button(ScaleUI.MenuButton(), "Menu", menuStyle))
				Time.timeScale = (Time.timeScale == PAUSED) ? PLAYING : PAUSED;
			
			GUI.Label(ScaleUI.Score(), scoreText, scoreStyle);
			GUI.Label(ScaleUI.Time(), timeText, timeStyle);
			
			GUI.Button(new Rect(Screen.width / 16, 4 * Screen.height / 24, 
								14 * Screen.width / 16, 2.5f * Screen.height / 24), 
								"This is the first line", gameStyle);
				
			GUI.Button(new Rect(Screen.width / 16, 5.5f * Screen.height / 24, 
								14 * Screen.width / 16, 2.5f * Screen.height / 24), 
								"This is another line.", gameStyle);
			
			GUI.Button(new Rect(Screen.width / 16, 7 * Screen.height / 24, 
								14 * Screen.width / 16, 2.5f * Screen.height / 24), 
								"One more line... Yeah.", gameStyle);
				
			GUI.Button(new Rect(Screen.width / 16, 8.5f * Screen.height / 24, 
								14 * Screen.width / 16, 2.5f * Screen.height / 24), 
								"Each lines fits a", gameStyle);
			
			GUI.Button(new Rect(Screen.width / 16, 10 * Screen.height / 24, 
								14 * Screen.width / 16, 2.5f * Screen.height / 24), 
								"maximum of 24 letters!", gameStyle);
			
			GUI.Button(new Rect(Screen.width / 16, 11.5f * Screen.height / 24, 
								14 * Screen.width / 16, 2.5f * Screen.height / 24), 
								"OOOOOOOOOOOOOOOOOOOOOO", gameStyle);
			
			if (GUI.Button(ScaleUI.SendButton(), "Send", sendStyle))
				score += 100;
		}
	}
}
