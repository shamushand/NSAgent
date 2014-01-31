using UnityEngine;
using System.Collections;

public class Word
{
	public string word;		// The word itself.
	public Rect button;		// The Rect defining the button.
	public bool flagged;	// Is the word in the word bank?
	public bool pressed;	// Has the word been pressed yet?
		
	public Word(string word, int line, int position)
	{
		this.word = word;
		button = ScaleUI.MakeButton(line, position, word.Length);
		flagged = IsFlagged(word);
		pressed = false;
	}
	
	// Called when the word is pressed. Registers the word as pressed,
	// then returns 100 if the word is flagged, or -100 if it is not.
	public int Press()
	{
		pressed = true;
		
		if (flagged)
			return 100;
		else
			return -100;
	}
	
	// Takes in a string and returns whether it contains one of the
	// words in the flagged word bank.
	bool IsFlagged(string word)
	{
		bool isFlagged = false;
		
		foreach (string flaggedWord in Strings.WordBank())
						if (word.ToLower ().Contains (flaggedWord.ToLower ()))
								isFlagged = true;
		
		return isFlagged;
	}
	
	public override string ToString()
	{
		return word;
	}
}
