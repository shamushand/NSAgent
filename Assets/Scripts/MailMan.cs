using UnityEngine;
using System.Collections;

public static class MailMan
{
	// Stores a list of messages already used this session.
	static bool[] usedMessages = new bool[Strings.Messages().Length];
	
	// Fetches the next message.
	public static ArrayList NextMessage()
	{
		// Split the file into an array of strings, each containing one message.
		string[] messages = Strings.Messages();
		
		
		// Find a new, unused message at random.
		int next = Random.Range(0, messages.Length);
		while (usedMessages[next])
			next = Random.Range(0, messages.Length);
		usedMessages[next] = true;
		
		return ButtonFactory(messages[next]);
	}
	
	// Takes in a string (a message).
	// Returns an ArrayList of Word objects.
	static ArrayList ButtonFactory(string message)
	{
		int position = 0;		// Number of characters in the current line, spaces included.
		int currentWord = 0;	// Number of words in the current line.
		int currentLine = 0;	// Number of lines in the current message.
		int lineLength = 24;	// The maximum number of characters allowed each lines.
		
		// Initialize a 2D array of strings.
		string[][] wrapped = new string[10][];
		for (int i = 0; i < wrapped.Length; i++)
			wrapped[i] = new string[10];
		
		// Iterate through every word in the message.
		string[] words = message.Split(' ');
		for (int word = 0; word < words.Length; word++)
		{
			// Move to the next line if the word will not fit.
			if (position + words[word].Length > lineLength)
			{
				position = 0;
				currentWord = 0;
				currentLine++;
			}
			
			// Add the word to the current line.
			wrapped[currentLine][currentWord] = words[word];
			position += words[word].Length + 1;
			currentWord++;
		}
		
		// Iterate through the word wrapped message and 
		// populate the ArrayList with Word objects.
		ArrayList buttons = new ArrayList();		
		for (int line = 0; line < wrapped.Length; line++) 
		{
			position = 0;
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
