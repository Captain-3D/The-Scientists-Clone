using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public int xp;

    public int maxHealth;
    public int currentHealth;

    public int maxMana;
    public int currentMana;

    public List<Item> inventory;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(10);
		}
	}

	public void SavePlayer ()
	{
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer()
	{
		PlayerData data = SaveSystem.LoadPlayer();

		level = data.level;
		xp = data.xp;
		maxHealth = data.maxHealth;
		currentHealth = data.currentHealth;
		maxMana = data.maxMana;
		currentMana = data.currentMana;
	}

	public void DeletePlayer()
	{
		SaveSystem.DeletePlayerSave();
	}

	void TakeDamage(int damage)
	{
		gamestate.Instance.setHP(gamestate.Instance.getHP() - damage);
	}

}




