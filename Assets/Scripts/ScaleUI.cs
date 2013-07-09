using UnityEngine;
using System.Collections;

public class ScaleUI
{
	static float xScale = 16;	// Number of units the width of the screen is divided into.
	static float yScale = 24;	// Number of units the height of the screen is divided into.
	
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
		offsetX = 2f * Screen.width / xScale;
		offsetY  = 9f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 2.5f * Screen.height / yScale;	
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Second button in the main menu.
	/// </summary>
	public static Rect MenuButton2()
	{
		offsetX = 2f * Screen.width / xScale;
		offsetY  = 12.5f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 2.5f * Screen.height / yScale;	
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Third button in the main menu.
	/// </summary>
	public static Rect MenuButton3()
	{
		offsetX = 2f * Screen.width / xScale;
		offsetY  = 16f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 2.5f * Screen.height / yScale;	
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Fourth button in the main menu.
	/// </summary>
	public static Rect MenuButton4()
	{
		offsetX = 2f * Screen.width / xScale;
		offsetY  = 19.5f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 2.5f * Screen.height / yScale;	
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Background box of the main menu.
	/// </summary>
	public static Rect MenuBackground()
	{
		offsetX = Screen.width / xScale;
		offsetY = 8f * Screen.height / yScale;
		width = 14f * Screen.width / xScale;
		height = 15f * Screen.height / yScale;
		return new Rect(offsetX, offsetY, width, height);
	}	
	
	// Game UI
	
	/// <summary>
	/// The Score label in the game UI.
	/// </summary>
	public static Rect Score()
	{
		offsetX = Screen.width / xScale;
		offsetY = Screen.height / (4 * yScale);
		width = 5f * Screen.width / xScale;
		height = Screen.height / yScale;
		return new Rect(offsetX, offsetY, width, height);	
	}
	
	/// <summary>
	/// The Time label in the game UI.
	/// </summary>	
	public static Rect Time()
	{
		offsetX = 10f * Screen.width / xScale;
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
		offsetX = 6.5f * Screen.width / xScale;
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
		offsetX = Screen.width / xScale;
		offsetY = 20 * Screen.height / yScale;
		width = 14 * Screen.width / xScale;
		height = 3 * Screen.height / yScale;
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The top button in the pause menu.
	/// </summary>
	public static Rect PauseButton1()
	{
		offsetX = 2f * Screen.width / xScale;
		offsetY  = 8f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// The bottom button in the pause menu.
	/// </summary>
	public static Rect PauseButton2()
	{
		offsetX = 2f * Screen.width / xScale;
		offsetY  = 13.5f * Screen.height / yScale;
		width = 12f * Screen.width / xScale;
		height = 3f * Screen.height / yScale;
		return new Rect(offsetX, offsetY, width, height);
	}
	
	/// <summary>
	/// Creates a button using information about word placement.
	/// </summary>
	public static Rect MakeButton(int line, int character, int length)
	{
		float start = Screen.width / xScale;
		float end = 15 * Screen.width / xScale;
		float size = end - start;
		
		offsetX = start + character * size / 24;
		offsetY = (4 + 1.5f * line) * Screen.height / yScale;
		width = length * size / 24;
		height = 1.45f * Screen.height / yScale;
		
		return new Rect(offsetX, offsetY, width, height);
	}
}
