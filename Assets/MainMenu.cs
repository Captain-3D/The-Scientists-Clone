using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void PlayGame () 
	{
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		SceneManager.LoadScene(1);
	}

	public void LoadGame () 
	{
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		SceneManager.LoadScene(2);
	}
	 
	public void QuitGame ()
	{
	  	Debug.Log ("Game has been exited.");
	  	UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
}