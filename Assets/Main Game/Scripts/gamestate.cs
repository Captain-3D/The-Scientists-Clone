using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	Inventory inventory;				// Our current inventory
	

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

		DontDestroyOnLoad(Inventory.Instance);
		inventory = Inventory.Instance;

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

		DontDestroyOnLoad(Inventory.Instance);
		inventory = Inventory.Instance;

		activeLevel = "Space Ship";
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

		if(hp == 0 || hp < 0)
		{
			hp = 0;
		}
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