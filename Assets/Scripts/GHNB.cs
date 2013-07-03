using UnityEngine;
using System.Collections;

public class GHNB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Intro());
	}
	
	IEnumerator Intro()
	{
		yield return new WaitForSeconds(4.5f);
		audio.Play();
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Main Menu");
	}
}