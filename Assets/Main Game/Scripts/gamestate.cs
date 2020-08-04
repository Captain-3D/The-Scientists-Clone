/*

    Notes:
        This script is a C# game state manager for Unity 3D; you should review the gamestart.cs 
        script to help understand how to implement game states.
*/
using UnityEngine;
using System.Collections;

public class gamestate : MonoBehaviour {
	
	// Declare properties
	private static gamestate instance;
	private string activeLevel;			// Active level
	private string name;				// Characters name
	private int level; 					//charecter level
	private int maxHP;					// Max HP
	private int maxMP;					// Map MP
	private int hp;						// Current HP
	private int mp;						// Current MP
	private int exp;					// Characters Experience Points
	
	
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("gamestate").AddComponent<gamestate> ();
			}
 
			return instance;
		}
	}	

	public void OnApplicationQuit()
	{
		instance = null;
	}

	public void startState()
	{
		print ("Creating a new game state");
		
		// Set default properties:
		activeLevel = "Space Ship";
		level = 1;
		maxHP = 100;
		maxMP = 50;
		hp = maxHP;
		mp = maxMP;
		exp = 0;

		Application.LoadLevel("Space Ship");
	}
	
	public void loadState()
	{
		print ("Loading game data from previous states");

		PlayerData data = SaveSystem.LoadPlayer();

		level = data.level;
		exp = data.xp;
		maxHP = data.maxHealth;
		hp = data.currentHealth;
		maxMP = data.maxMana;
		mp = data.currentMana;

		Application.LoadLevel("Space Ship");
	}
	
	public string getActiveLevel()
	{
		return activeLevel;
	}
	
	public void setActiveLevel(string newLevel)
	{
		// Set activeLevel to newLevel
		activeLevel = newLevel;
	}
	
	public string getName()
	{
		return name;
	}
	
	public int getHP()
	{
		return hp;
	}

	public void setHP(int newHP)
	{
		hp = newHP;
	}

	public int getMP()
	{
		return mp;
	}

	public void setMP(int newMP)
	{
		mp = newMP;
	}

	public int getMaxHP()
	{
		return maxHP;
	}

	public int getMaxMP()
	{
		return maxMP;
	}
}