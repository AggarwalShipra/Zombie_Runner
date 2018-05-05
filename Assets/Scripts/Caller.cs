using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caller : MonoBehaviour {
	public Text scoreText;
	public Text lifeText;
	public Text Finalscore;
	public Text Finalscore1;
	public GameObject panel;
	public GameObject panel2;
	// Use this for initialization
	void Start () {
		panel.SetActive (false);
		panel2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void endactivate()
	{
		Finalscore1.text = "Your Score is " + Variable.score;
		panel2.SetActive (true);
	}
	public void activate()
	{
		panel.SetActive (true);
	}
	public void printFinalScore()
	{
		Finalscore.text = "Your Score is " + Variable.score;
	}
	public void printLife()
	{
		lifeText.text = "" + Variable.players;
	}
	public void printScore()
	{
		scoreText.text = "" + Variable.score;
	}
}
