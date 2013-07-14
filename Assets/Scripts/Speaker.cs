using UnityEngine;
using System.Collections;

public class Speaker : MonoBehaviour {
	
	Vector3 currentSize;
	
	int rate = 5;
		
	// Update is called once per frame
	void Update() 
	{
		float difference = Mathf.Abs(Mathf.Clamp(-Mathf.Tan(Time.time * rate), -1, 1));
		
		if (difference < 0.01f)
			rate = Random.Range(5, 10);
		
		currentSize = new Vector3(0.15f + (0.05f * difference), 0.1f,
								  0.15f + (0.05f * difference));
		transform.localScale = currentSize;
		
		
	}
}
