using UnityEngine;
using System.Collections;

public class ScaleUI
{
	static float maxChars = 36;	// Maximum number of characters per line.
	static float xScale = 24;	// Number of units the width of the screen is divided into.
	static float yScale = 16;	// Number of units the height of the screen is divided into.
	
	static float offsetX;		// The X offset of the GUI object.
	static float offsetY;		// The Y offset of the GUI object.
	static float width;			// Width of the GUI object.
	static float height;		// Height of the GUI object.
	
	// Main Menu
	
	/// <summary>
	/// First button in the main menu.
	/// </summary>
	public static Rect MenuButton1()
	{
		offsetX = 0f;
		offsetY  = 13f * Screen.height / yScale;
		width = 6f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;	
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Second button in the main menu.
	/// </summary>
	public static Rect MenuButton2()
	{
		offsetX = 5f * Screen.width / xScale;
		offsetY  = 13f * Screen.height / yScale;
		width = 6f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;	
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Third button in the main menu.
	/// </summary>
	public static Rect MenuButton3()
	{
		offsetX = 11f * Screen.width / xScale;
		offsetY  = 13f * Screen.height / yScale;
		width = 6f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;	
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Fourth button in the main menu.
	/// </summary>
	public static Rect MenuButton4()
	{
		offsetX = 17.5f * Screen.width / xScale;
		offsetY  = 13f * Screen.height / yScale;
		width = 6f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;	
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Background box of the main menu.
	/// </summary>
	public static Rect MenuBackground()
	{
		offsetX = 0;
		offsetY = 12.5f * Screen.height / yScale;
		width = Screen.width;
		height = 3.5f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}	
	
	// Game UI
	
	/// <summary>
	/// Creates a button using information about word placement.
	/// </summary>
	public static Rect MakeButton(int line, int character, int length)
	{
		float start = Screen.width / xScale;
		float end = 29 * Screen.width / xScale;
		float size = end - start;
		
		offsetX = start + character * size / maxChars;
		offsetY = (2f* line + 4) * Screen.height / yScale;
		width = length * size / maxChars;
		height = 1.45f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The Score label in the game UI.
	/// </summary>
	public static Rect Score()
	{
		offsetX = Screen.width / xScale;
		offsetY = Screen.height / (4 * yScale);
		width = 6f * Screen.width / xScale;
		height = 2 * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);	
	}
	
	/// <summary>
	/// The Time label in the game UI.
	/// </summary>	
	public static Rect Time()
	{
		offsetX = 18f * Screen.width / xScale;
		offsetY = Screen.height / (4 * yScale);
		width = 5f * Screen.width / xScale;
		height = Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);	
	}
	
	/// <summary>
	/// The Menu button in the game UI.
	/// </summary>
	public static Rect MenuButton()
	{
		offsetX = 10.5f * Screen.width / xScale;
		offsetY = Screen.height / (4 * yScale);
		width = 3 * Screen.width / xScale;
		height = Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The Send button in the game UI.
	/// </summary>
	public static Rect SendButton()
	{		
		offsetX = -1.1f * Screen.width / xScale;
		offsetY  = 14.5f * Screen.height / yScale;
		width = 1.1f * Screen.width;
		height = 1.5f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The top button in the pause menu.
	/// </summary>
	public static Rect PauseButton1()
	{
		offsetX = 6f * Screen.width / xScale;
		offsetY  = 3f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The middle button in the pause menu.
	/// </summary>
	public static Rect PauseButton2()
	{
		offsetX = 6f * Screen.width / xScale;
		offsetY  = 7f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The bottom button in the pause menu.
	/// </summary>
	public static Rect PauseButton3()
	{
		offsetX = 6f * Screen.width / xScale;
		offsetY  = 11f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The background for the top of the game UI.
	/// </summary>
	public static Rect TopBackground()
	{
		offsetX = -1.1f * Screen.width / xScale;
		offsetY  = 0;
		width = 1.1f * Screen.width;
		height = 1.5f * Screen.height / yScale;	
		
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The background for the bottom of the game UI.
	/// </summary>
	public static Rect BottomBackground()
	{
		offsetX = -1.1f * Screen.width / xScale;
		offsetY  = 14.5f * Screen.height / yScale;
		width = 1.1f * Screen.width;
		height = 1.5f * Screen.height / yScale;	
		
		return new Rect(offsetX, offsetY, width, height);	
	}
	
	/// <summary>
	/// The background for the pause menu.
	/// </summary>
	public static Rect PauseBackground()
	{
		offsetX = 0;
		offsetY  = 0;
		width = Screen.width;
		height = Screen.height;	
		
		return new Rect(offsetX, offsetY, width, height);	
	}
}