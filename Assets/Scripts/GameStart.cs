using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {
	
	int best;
	int shown;
	int increment;
	
	bool showLabel;
	bool showValue;
	
	public Font font;
	
	// Use this for initialization
	void Start() 
	{
		best = PlayerPrefs.GetInt("Highscore");
		increment = best / 50;
		StartCoroutine(Highscore());
	}
	
	// Called for rendering and handling GUI events.
	void OnGUI()
	{
		GUIStyle text = new GUIStyle(GUI.skin.label);
		text.font = font;
		text.fontSize =  Screen.width / 30;
		text.alignment = TextAnchor.UpperCenter;
		
		if (showLabel)
			GUI.Label(new Rect(0, Screen.height / 4, Screen.width, Screen.height / 3), "Previous best:", text);
		
		if (showValue)
			GUI.Label(new Rect(0, 2 * Screen.height / 4, Screen.width, Screen.height / 3), shown.ToString(), text);
	}
	
	IEnumerator Highscore()
	{
		yield return new WaitForSeconds(1f);
		showLabel = true;
		audio.Play();
		
		yield return new WaitForSeconds(1f);
		showValue = true;
		while (best > shown)
		{
			shown += increment;
			audio.Play();
			yield return new WaitForSeconds(0.038f);
		}
		
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Game");
	}
}
