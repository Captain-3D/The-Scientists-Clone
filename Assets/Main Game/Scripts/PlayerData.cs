using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public int level;
    public int xp;

    public int maxHealth;
    public int currentHealth;

    public int maxMana;
    public int currentMana;

    //public float[] position;

    public PlayerData (Player player)
	{
		level = player.level;
		xp = player.xp;
		maxHealth = player.maxHealth;
		currentHealth = player.currentHealth;
		maxMana = player.maxMana;
		currentMana = player.currentMana;

		//position = new float[3];
		//position[0] = player.transform.position.x;
		//position[1] = player.transform.position.y;
		//position[2] = player.transform.position.z;
	}
}
