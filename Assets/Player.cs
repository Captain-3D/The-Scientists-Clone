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

    public SliderScript healthBar;
	public SliderScript manaBar;

    void Start()
	{

		currentHealth = maxHealth;
		currentMana = maxMana;

		healthBar.setMaxValue(maxHealth);
		manaBar.setMaxValue(maxMana);

	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
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

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		transform.position = position;

	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetSliderValue(currentHealth);
	}

}




