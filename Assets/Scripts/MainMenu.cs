using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	Vector3 startPosition;	// Camera's initial position (on menu).
	Vector3 endPosition;	// Camera's final position (on game start).
	
	float totalSteps;		// Number of frames to draw when zooming into screen.
	float xDiff;			// Amount to increment camera's X coordinate this frame.
	float yDiff;			// Amount to increment camera's Y coordinate this frame.
	float zDiff;			// Amount to increment camera's Z coordinate this frame.

	void Awake() 
	{
		startPosition = camera.transform.position;
		endPosition = new Vector3(-1.5f, 3.75f, 8);
		totalSteps = 100;
		
		xDiff = (endPosition.x - startPosition.x) / totalSteps;
		yDiff = (endPosition.y - startPosition.y) / totalSteps;
		zDiff = (endPosition.z - startPosition.z) / totalSteps;
	}
	
	public Font menuFont;	// Font used for menu buttons.
	public Font titleFont;	// Font used for the game title.
	bool startingGame;		// Is the game starting?
	
	// Called for rendering and handling GUI events.
	void OnGUI() 
	{
		// Hide the GUI if the game is starting.
		if (!startingGame)
		{
			// Title
			GUIStyle title = new GUIStyle(GUI.skin.label);
			title.fontSize = Screen.width / 9;
			title.alignment = TextAnchor.MiddleCenter;
			title.font = titleFont;
			
			GUI.Label(new Rect(Screen.width / 2, 0, 
							   Screen.width / 2, Screen.height / 4), 
							   "NSAgent", title);
		
			// Subtitle
			title.fontSize = Screen.width / 20;
			
			GUI.Label(new Rect(Screen.width / 2, 0, 
							   Screen.width / 2, Screen.height / 2), 
							   "American Defender", title);
			
			// Background box
			GUI.Box(ScaleUI.MenuBackground(), "");
			
			// Menu buttons
			// http://answers.unity3d.com/questions/344493/change-font-size-through-script.html
			GUIStyle button = new GUIStyle(GUI.skin.label);
			button.fontSize = Screen.width / 20;
			button.alignment = TextAnchor.MiddleCenter;
			button.font = menuFont;
			
			if (GUI.Button(ScaleUI.MenuButton1(), "Start", button)) 
			{
				startingGame = true;
				StartCoroutine(StartGame());
			}
			if (GUI.Button(ScaleUI.MenuButton2(), "Word Bank", button)) 
			{
				Application.LoadLevel("Word Bank");
			}	
			if (GUI.Button(ScaleUI.MenuButton3(), "Settings", button)) 
			{
				Application.LoadLevel("Main Menu");
			}
			if (GUI.Button(ScaleUI.MenuButton4(), "Credits", button)) 
			{
				Application.LoadLevel("Credits");
			}
		}
	}
	
	IEnumerator StartGame()
	{
		CameraFade fader = GetComponent<CameraFade>();
		fader.StartFade(Color.black, 4f);
		
		for(int step = 0; step < totalSteps; step++)
		{
			audio.volume = (float) (100 - step) / totalSteps;
			camera.transform.position = new Vector3(camera.transform.position.x + xDiff,
													camera.transform.position.y + yDiff,
													camera.transform.position.z + zDiff);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		Application.LoadLevel("Game Start");
	}
}