using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	Vector3 endPosition;	// Camera's final position (on game start).
	
	float totalSteps;		// Number of frames to draw when zooming into screen.

	void Awake() 
	{
		totalSteps = 200;
		
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
				StartCoroutine (WordBank ());
			}	
			if (GUI.Button(ScaleUI.MenuButton3(), "Settings", button)) 
			{
				Application.LoadLevel("Main Menu");
			}
			if (GUI.Button(ScaleUI.MenuButton4(), "High Score", button)) 
			{
				StartCoroutine(HighScore ());
			}
		}
	}
	
	IEnumerator StartGame()
	{
		CameraFade fader = GetComponent<CameraFade>();
		fader.StartFade(Color.black, 7f);
		
		endPosition = new Vector3(-1.5f, 3.75f, 8);
		for(int step = 0; step < totalSteps; step++)
		{
			audio.volume = (float) (totalSteps - step) / totalSteps;
			camera.transform.position = Vector3.Lerp(camera.transform.position, endPosition, Time.deltaTime);
			camera.transform.rotation = Quaternion.Lerp (camera.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		Application.LoadLevel("Game Start");
	}
	
	IEnumerator WordBank()
	{
		endPosition = new Vector3(-3.3f, 4.4f, 6.2f);
		
		for(int step = 0; step < totalSteps; step++)
		{
			camera.transform.position = Vector3.Lerp(camera.transform.position, endPosition, Time.deltaTime);
			camera.transform.rotation = Quaternion.Lerp (camera.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime);
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
	
	IEnumerator HighScore()
	{
		endPosition = new Vector3(3.8f, 4.4f, 6.2f);
		
		for(int step = 0; step < totalSteps; step++)
		{
			camera.transform.position = Vector3.Lerp (camera.transform.position, endPosition, Time.deltaTime);
			camera.transform.rotation = Quaternion.Lerp (camera.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}