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
	
	public TextAsset messageList;
	
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
		scoreStyle.font = digitalDream;
		
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
		gameStyle.wordWrap = false;
		
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
			
			MessageHandler mailMan = new MessageHandler();
			ArrayList buttons = mailMan.NextMessage(messageList);
			
			foreach (object[] button in buttons)
				GUI.Button((Rect) button[0], (string) button[1], gameStyle);
			
			if (GUI.Button(ScaleUI.SendButton(), "Send", sendStyle))
				score += 100;
		}
	}
}
