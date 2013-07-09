using UnityEngine;
using System.Collections;

public class MessageHandler
{
	private string[][] words;
	private string[] messages;

	public int messageNum = 1;
	
	// Fetches the next message.
	public ArrayList NextMessage(TextAsset messageList)
	{
		// Split the file into an array of strings, each containing one message.
		messages = messageList.ToString().Split('\n');
		words = new string[messages.Length][];
		
		// Splint each message into a 2D array of strings, each containing one word.
		int i = 0;
		foreach (string message in messages)
			words[i++] = message.Split(' ');
		
		return ButtonFactory(words[messageNum]);
	}
	
	// Takes in an array of strings (a message).
	// Returns a word wrapped 2D array of strings, with each
	// sentence having a length less than or equal to maxChars.
	string[][] WordWrap(string[] message)
	{
		int currentChars = 0;	// Number of characters in the current line, spaces included.
		int currentWord = 0;	// Number of words in the current line.
		int currentLine = 0;	// Number of lines in the current message.
		int maxChars = 24;		// The maximum number of characters allowed each lines.
		
		// Initialize a 2D array of strings.
		string[][] wordWrapped = new string[10][];
		for (int i = 0; i < wordWrapped.Length; i++)
			wordWrapped[i] = new string[10];
		
		// Iterate through every word inthe message.
		for (int i = 0; i < message.Length; i++)
		{
			// Check if the word will fit in this line.
			if (currentChars + message[i].Length > maxChars)
			{
				currentChars = 0;
				currentWord = 0;
				currentLine++;
			}
				
			wordWrapped[currentLine][currentWord] = message[i];
			currentChars += message[i].Length + 1;
			currentWord++;
		}
	
		return wordWrapped;
	}
	
	// Takes in a word wrapped 2D array of strings.
	// Returns an array of Rect's.
	ArrayList ButtonFactory(string[] message)
	{
		// Initialize a 2D array of buttons.
		//Rect[] buttonArray = new Rect[30];
		int totalButtons = 0;
		ArrayList buttons = new ArrayList();
		
		string[][] wordWrapped = WordWrap(message);
		for (int i = 0; i < wordWrapped.Length; i++) 
		{
			int currentChar = 0;
			for (int j = 0; j < wordWrapped.Length; j++)
			{
				if (wordWrapped[i][j] != null)
				{
					object[] temp = new object[2];
					temp[0] = ScaleUI.MakeButton(i, currentChar, wordWrapped[i][j].Length + 1);
					temp[1] = wordWrapped[i][j];
					buttons.Add(temp);
					//buttonArray[totalButtons] = ScaleUI.MakeButton(i, currentChar, wordWrapped[i][j].Length + 1);
					currentChar += wordWrapped[i][j].Length + 1;
					totalButtons++;
				}
			}
		}
				
		return buttons;
	}
}