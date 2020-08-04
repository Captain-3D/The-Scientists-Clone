/*
    Notes:
        This script is a C# script provides a simple GUI that interfaces with the state manager, you 
        will need the statemanager.cs script and should review the gamestart.cs script for information 
        on how to implement the state manager.
*/
using UnityEngine;
using System.Collections;

public class levelgui : MonoBehaviour {

	public SliderScript healthBar;
	public SliderScript manaBar;

	// Initialize level
	void Start () 
	{
		print ("Loaded: " + gamestate.Instance.getActiveLevel());

		healthBar.setMaxValue(gamestate.Instance.getMaxHP());
		manaBar.setMaxValue(gamestate.Instance.getMaxMP());
		healthBar.SetSliderValue(gamestate.Instance.getHP());
		manaBar.SetSliderValue(gamestate.Instance.getMP());
	}
	
	// ---------------------------------------------------------------------------------------------------
	// OnGUI()
	// --------------------------------------------------------------------------------------------------- 
	// Provides a GUI on level scenes
	// ---------------------------------------------------------------------------------------------------
	void OnGUI()
	{		
		healthBar.SetSliderValue(gamestate.Instance.getHP());
		manaBar.SetSliderValue(gamestate.Instance.getMP());

		// Create buttons to move between level 1 and level 2
		if (GUI.Button (new Rect (30, 30, 150, 30), "Ice Level"))
		{
			gamestate.Instance.setActiveLevel("Ice Level");
			Application.LoadLevel("Ice Level");
		}
		/*
		if (GUI.Button (new Rect (300, 30, 150, 30), "Load Level 2"))
		{
			print ("Moving to level 2");
			gamestate.Instance.setLevel("Level 2");
			Application.LoadLevel("level2");
		}*/
		
		
		// Output stats
		//GUI.Label(new Rect(30, 100, 400, 30), "Name: " + gamestate.Instance.getName());
		GUI.Label(new Rect(30, 130, 400, 30), "HP: " + gamestate.Instance.getHP().ToString());
		GUI.Label(new Rect(30, 160, 400, 30), "MP: " + gamestate.Instance.getMP().ToString());
		
	}
}