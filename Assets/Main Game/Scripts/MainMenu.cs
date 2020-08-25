using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void startNewGame()
	{
		print("Starting new game");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState();	
	}

	public void LoadGame () 
	{
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		//SceneManager.LoadScene(2);

		print("Loading game");

		DontDestroyOnLoad(gamestate.Instance);

		gamestate.Instance.loadState();	

	}

	public void QuitGame ()
	{
	  	Debug.Log ("Game has been exited.");
	  	UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
}