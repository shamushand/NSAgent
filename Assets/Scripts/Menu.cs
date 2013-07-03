using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public Font munro;
	
	void OnGUI () 
	{
		GUI.skin.font = munro;
		
		// Background box
		GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 125, 400, 400), "");
		
		// Menu buttons
		if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 150), "Intro")) 
		{
			Application.LoadLevel("Intro");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 150), "Reload")) 
		{
			Application.LoadLevel("Main Menu");
		}	
	}
}
