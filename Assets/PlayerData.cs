using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
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

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetSliderValue(currentHealth);
	}

}


