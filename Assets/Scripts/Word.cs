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
		button = ScaleUI.MakeButton(line, position, word.Length + 1);
		flagged = FlagCheck(word);
		pressed = false;
	}
	
	public int Press()
	{
		if (pressed)
			return 0;
		else
		{
			if (flagged)
				return 100;
			else
				return -100;
		}
	}
	
	bool FlagCheck(string word)
	{
		return true;
	}
	
	public override string ToString()
	{
		return word;
	}
}
