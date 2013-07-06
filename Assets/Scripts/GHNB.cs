using UnityEngine;
using System.Collections;

public class GHNB : MonoBehaviour 
{	
	float fontScale = 5.75f;	// Coefficient for font size to screen width.
	
	// Called just before any of the Update methods is called the first time.
	void Start() 
	{
		GameObject line1 = GameObject.Find("Line 1");
		GameObject line2 = GameObject.Find("Line 2");
		GameObject line3 = GameObject.Find("Line 3");
		
		line1.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / fontScale);
		line2.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / fontScale);
		line3.GetComponent<GUIText>().guiText.fontSize = (int) Mathf.Floor(Screen.width / fontScale);
		
		StartCoroutine(Intro());
	}
	
	IEnumerator Intro()
	{
		// Wait for Unity loading screen.
		// TODO: Find method of checking whether the loading screen is up,
		// since Application.isLoadingLevel does not work.
		yield return new WaitForSeconds(4.5f);
		audio.Play();
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Main Menu");
	}
}