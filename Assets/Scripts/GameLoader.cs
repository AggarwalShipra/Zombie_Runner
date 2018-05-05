using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MainMenu()
	{
		Time.timeScale = 0;
		Application.LoadLevel ("scene2");
	}
	public void PauseHit()
	{
		Time.timeScale = 0;
		Application.LoadLevelAdditive ("Pause_scene");
	}
	public void ResumeHit()
	{
		Application.UnloadLevel ("Pause_scene");
		Time.timeScale = 1;
	}
}
