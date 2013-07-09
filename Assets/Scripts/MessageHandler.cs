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
		ArrayList buttons = new ArrayList();
		string[][] wrapped = WordWrap(message);
		
		for (int line = 0; line < wrapped.Length; line++) 
		{
			int position = 0;
			for (int word = 0; word < wrapped.Length; word++)
			{
				if (wrapped[line][word] != null)
				{
					buttons.Add(new Word(wrapped[line][word], line, position));
					position += wrapped[line][word].Length + 1;
				}
				else
					break;
			}
		}
				
		return buttons;
	}
}