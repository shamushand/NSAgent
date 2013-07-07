using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	const int PLAYING = 1;		// TimeScale constant for when the game is running.
	const int PAUSED = 0;		// TimeScale constant for when the game is paused.
	
	int menuScale = 20;			// Coefficient of menu button font size to screen width. 
	int sendScale = 5;			// Coefficient of send button font size to screen width. 
	
	string scoreText;
	string timeText;
	
	public Font munro;

	// Called just before any of the Update methods is called the first time.
	void Start() 
	{
		
	}
	
	// Called once per frame.
	void Update() 
	{
		// TODO: Gameloop.
		scoreText = "0000123";
		timeText = Time.time.ToString();
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
		
		if (GUI.Button(ScaleUI.MenuButton(), "Menu", menuStyle))
			Time.timeScale = (Time.timeScale == PAUSED) ? PLAYING : PAUSED;
		
		
		if (Time.timeScale == PAUSED)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

			if (GUI.Button(ScaleUI.PauseButton1(), "Resume", menuStyle)) 
			{
				Time.timeScale = PLAYING;
			}
			if (GUI.Button(ScaleUI.PauseButton2(), "Quit", menuStyle)) 
			{
				Time.timeScale = PLAYING;
				Application.LoadLevel("Main Menu");
			}	
		}
		else
		{
			GUI.Label(ScaleUI.Score(), scoreText, menuStyle);
			GUI.Label(ScaleUI.Time(), timeText, menuStyle);
			if (GUI.Button(ScaleUI.SendButton(), "Send", sendStyle))
			; // TODO: the game!
		}
	}
}
