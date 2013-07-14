using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	int actualScore;			// Player's current score.
	int rollingScore;			// Player's displayed score.
	int combo;					// Player's current combo multiplier.
	
	float gameTimer;			// Time left in session.
	float bonusTime;			// Initial time + time earned from words.
	float comboTimer;			// Time left in current combo.
	
	bool fetchMessage;			// Is the game requesting another message?
	bool gameOver;				// Is the game over?
	
	ArrayList currentMessage;	// Game's copy of the current message.
		
	// Called just before any of the Update methods is called the first time.
	void Start() 
	{
		bonusTime = 15;
		fetchMessage = true;
		StartCoroutine(Tick());
	}
	
	IEnumerator Tick()
	{
		while (!gameOver)
		{
			audio.Play();
			yield return new WaitForSeconds(1f);
		}
	}
	
	// Called once per frame.
	void Update() 
	{
		// Update the time and check if the game has ended.
		gameTimer = bonusTime - Time.timeSinceLevelLoad;
		if (gameTimer <= 0)
		{	
			// TODO: Score screen.
			gameTimer = 0;
			gameOver = true;
			PlayerPrefs.SetInt("Highscore", actualScore);
		}
		
		// Decrement the combo timer and check if the combo has ended.
		comboTimer -= Time.deltaTime;
		if (comboTimer <= 0)
			combo = 0;
		
		// Check if a new message is needed.
		if (fetchMessage)
		{
			currentMessage = MailMan.NextMessage();
			fetchMessage = false;
		}		
	}
	
	const int PLAYING = 1;		// TimeScale constant for when the game is running.
	const int PAUSED = 0;		// TimeScale constant for when the game is paused. 
	
	public Font font1;			// Orbitron
	public Font font2;			// Digital Dream	
	public Font font3;			// Courier Bold
	
	public GUISkin customSkin;
	
	// Called for rendering and handling GUI events.
	void OnGUI()
	{
		// Set GUI skin and initialize GUIStyles
		//GUI.skin = customSkin;
		GUIStyle scoreStyle = new GUIStyle(GUI.skin.label);
		GUIStyle menuStyle = new GUIStyle(GUI.skin.label);
		GUIStyle timeStyle = new GUIStyle(GUI.skin.label);
		GUIStyle sendStyle = new GUIStyle(GUI.skin.label);
		GUIStyle gameStyle = new GUIStyle(GUI.skin.label);
		GUIStyle pauseStyle = new GUIStyle(GUI.skin.label);
		
		// Set fonts
		scoreStyle.font = font2;
		menuStyle.font = font1;
		timeStyle.font = font2;
		sendStyle.font = font1;
		gameStyle.font = font3;
		pauseStyle.font = font1;
		
		// Scale fonts
		scoreStyle.fontSize =  Screen.width / 40;
		menuStyle.fontSize =  Screen.width / 40;	
		timeStyle.fontSize =  Screen.width / 40;
		sendStyle.fontSize =  Screen.width / 36;
		gameStyle.fontSize =  Screen.width / 28;
		pauseStyle.fontSize =  Screen.width / 16;
		
		// Set alignments
		scoreStyle.alignment = TextAnchor.UpperLeft;
		menuStyle.alignment = TextAnchor.LowerCenter;
		timeStyle.alignment = TextAnchor.UpperRight;
		sendStyle.alignment = TextAnchor.MiddleCenter;
		pauseStyle.alignment = TextAnchor.UpperCenter;
		gameStyle.wordWrap = false;
		
		// Background boxes
		GUI.Box(ScaleUI.TopBackground(), "");
		GUI.Box(ScaleUI.BottomBackground(), "");
		
		// Score and time labels
		GUI.Label(ScaleUI.Score(), rollingScore.ToString("000000"), scoreStyle);
		GUI.Label(ScaleUI.Time(), gameTimer.ToString("00.00"), timeStyle);
		
		// Menu and send buttons
		if (GUI.Button(ScaleUI.MenuButton(), "Menu", menuStyle))
				Time.timeScale = (Time.timeScale == PAUSED) ? PLAYING : PAUSED;
		if (GUI.Button(ScaleUI.SendButton(), "Send", sendStyle) && Time.timeScale == PLAYING)
				fetchMessage = true;
			
		// Is the game paused?
		if (Time.timeScale == PAUSED)
		{
			// Dim the screen.
			GUI.Box(ScaleUI.PauseBackground(), "");
			
			// Display the "Resume" and "Quit" buttons.
			// TODO: Add "Restart" button.
			if (GUI.Button(ScaleUI.PauseButton1(), "Resume", pauseStyle)) 
			{
				Time.timeScale = PLAYING;
			}
			if (GUI.Button(ScaleUI.PauseButton2(), "Restart", pauseStyle)) 
			{
				Time.timeScale = PLAYING;
				Application.LoadLevel("Game Start");
			}	
			if (GUI.Button(ScaleUI.PauseButton3(), "Quit", pauseStyle)) 
			{
				Time.timeScale = PLAYING;
				Application.LoadLevel("Main Menu");
			}	
		}
		else
		{
			// Update the score to give it a "rolling" effect.
			if (rollingScore < actualScore)
				rollingScore += 5;
			else if (rollingScore > actualScore)
				rollingScore -= 5;
			
			// Iterate through every Word in the current message and
			// draw it on the screen.
			foreach (Word word in currentMessage)
			{
				// When a Word's button is pressed...
				if (GUI.Button(word.button, word.ToString(), gameStyle))
				{
					// Ensure it hasn't been pressed before.
					if (!word.pressed)
					{
						// If it is a flagged word, increment the current combo,
						// reset the combo timer, add time to the clock, then add
						// the appropriate amount of points to ther player's score.
						if (word.flagged)
						{
							combo++;
							comboTimer = 3;
							bonusTime += 2f;
							actualScore += combo * word.Press();
						}
						// If it's not a flagged word, end the current combo,
						// remove time from the clock, then remove 100 points
						// from the player's score.
						else
						{
							combo = 0;
							comboTimer = 0;
							bonusTime -= 3;
							actualScore += word.Press();	
						}
					}
				}
			}
		}
	}
}
